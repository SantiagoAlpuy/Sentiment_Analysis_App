using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Exceptions;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;

namespace Tests
{
    [TestClass]
    public class PhraseTest
    {
        Repository repository;
        ISentimentController sentimentController;
        IPhraseController phraseController;
        IEntityController entityController;
        Phrase phrase1;
        Phrase phrase2;
        Phrase phraseWithUpperAndLower1;
        Phrase phraseWithUpperAndLower2;
        Phrase phraseWithEmptyComment;
        Phrase nullCommentPhrase;
        Phrase oldPhrase;
        Phrase futurePhrase;
        Phrase phraseWith3Entities;
        Phrase phraseWithNoSent;
        Phrase neutroPhrase;
        Entity entity;
        Entity entity1;
        Entity entity2;
        Sentiment positiveSentiment1;
        Sentiment negativeSentiment1;
        Sentiment positiveSentiment2;
        Sentiment negativeSentiment2;
        DateTime currentDate;


        [TestInitialize]
        public void Setup()
        {
            repository = Repository.Instance;
            sentimentController = new SentimentController();
            phraseController = new PhraseController();
            entityController = new EntityController();
            currentDate = DateTime.Now;
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            repository.CleanLists();
        }

        [TestMethod]
        public void RegisterPhrase()
        {
            phrase1 = new Phrase() { Comment = "Me gusta la Pepsi", Date = currentDate };
            phrase2 = new Phrase() { Comment = "Odio la Limol", Date = currentDate };
            phraseController.AddPhraseToRepository(phrase1);
            phraseController.AddPhraseToRepository(phrase2);
            Assert.AreEqual(phrase1, phraseController.ObtainPhrase(phrase1.Comment, phrase1.Date));
            Assert.AreEqual(phrase2, phraseController.ObtainPhrase(phrase2.Comment, phrase2.Date));
        }

        [TestMethod]
        [ExpectedException(typeof(NullPhraseException))]
        public void RegisterNullPhrase()
        {
            phraseController.AddPhraseToRepository(null);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterPhraseWithEmptyDescription()
        {
            phraseWithEmptyComment = new Phrase() { Comment = "", Date = currentDate };
            phraseController.AddPhraseToRepository(phraseWithEmptyComment);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterPhraseWhoseDescriptionHasManyBlankSpaces()
        {
            phraseWithEmptyComment = new Phrase() { Comment = "   ", Date = currentDate };
            phraseController.AddPhraseToRepository(phraseWithEmptyComment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAttributeInObjectException))]
        public void RegisterPhraseWithNullComment()
        {
            nullCommentPhrase = new Phrase();
            phraseController.AddPhraseToRepository(nullCommentPhrase);
        }

        [TestMethod]
        [ExpectedException(typeof(DateOlderThanOneYearException))]
        public void RegisterPhraseWithDateOlderThanOneYear()
        {
            oldPhrase = new Phrase() { Comment = "Frase con fecha inferior a un año", Date = new DateTime(2019, 01, 01) };
            phraseController.AddPhraseToRepository(oldPhrase);
        }

        [TestMethod]
        [ExpectedException(typeof(DateFromFutureException))]
        public void RegisterPhraseWithDateFromFuture()
        {
            futurePhrase = new Phrase() { Comment = "Frase con fecha del futuro", Date = new DateTime(2025, 01, 1) };
            phraseController.AddPhraseToRepository(futurePhrase);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithNoRegisteredEntityInEntitiesList()
        {
            phrase1 = new Phrase() { Comment = "Me gusta la Pepsi", Date = currentDate };
            phraseController.AnalyzePhrase(phrase1);
            Assert.AreEqual("", phrase1.Entity);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithOnlyOneEntityInEntitiesList()
        {
            phrase1 = new Phrase() { Comment = "Me gusta la Pepsi", Date = currentDate };
            entity = new Entity()  { Name = "Pepsi" };
            entityController.AddEntity(entity);
            phraseController.AnalyzePhrase(phrase1);
            Assert.AreEqual("Pepsi", phrase1.Entity);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithMultipleDifferentEntities()
        {
            entity = new Entity() { Name = "Pepsi" };
            entity1 = new Entity() { Name = "Coca" };
            entity2 = new Entity() { Name = "Nix" };
            entityController.AddEntity(entity);
            entityController.AddEntity(entity1);
            entityController.AddEntity(entity2);
            phraseWith3Entities = new Phrase() { Comment = "Me gusta la Pepsi la Coca y la Nix", Date = currentDate };
            phraseController.AnalyzePhrase(phraseWith3Entities);
            Assert.AreEqual("Pepsi", phraseWith3Entities.Entity);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithDifferentUpperAndLowerLettersFormat()
        {
            entity = new Entity() { Name = "Pepsi" };
            phraseWithUpperAndLower1 = new Phrase() { Comment = "mE GUsTa La pEPsI", Date = currentDate };
            entityController.AddEntity(entity);
            phraseController.AnalyzePhrase(phraseWithUpperAndLower1);
            Assert.AreEqual("Pepsi", phraseWithUpperAndLower1.Entity);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithNoSentiments()
        {
            phraseWithNoSent = new Phrase() { Comment = "Mike Tyson" };
            phraseController.AnalyzePhrase(phraseWithNoSent);
            Assert.AreEqual(CategoryType.Neutro, phraseWithNoSent.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithOnePositiveSentiment()
        {
            positiveSentiment1 = new Sentiment() { Description = "Me gusta", Category = true };
            phrase1 = new Phrase() { Comment = "Me gusta la Pepsi",  Date = currentDate };
            sentimentController.AddSentiment(positiveSentiment1);
            phraseController.AnalyzePhrase(phrase1);
            Assert.AreEqual(CategoryType.Positive, phrase1.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithOneNegativeSentiment()
        {
            negativeSentiment1 = new Sentiment() { Description = "Odio", Category = false };
            phrase2 = new Phrase() { Comment = "Odio la Limol", Date = currentDate };
            sentimentController.AddSentiment(negativeSentiment1);
            phraseController.AnalyzePhrase(phrase2);
            Assert.AreEqual(CategoryType.Negative, phrase2.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithMultipleNegativeAndOPositiveSentiments()
        {
            positiveSentiment1 = new Sentiment() { Description = "Me gusta", Category = true };
            positiveSentiment2 = new Sentiment() { Description = "Me encanta", Category = true };
            negativeSentiment2 = new Sentiment() { Description = "detesto", Category = false };
            negativeSentiment1 = new Sentiment() { Description = "Odio", Category = false };
            sentimentController.AddSentiment(negativeSentiment1);
            sentimentController.AddSentiment(positiveSentiment1);
            sentimentController.AddSentiment(negativeSentiment2);
            sentimentController.AddSentiment(positiveSentiment2);
            neutroPhrase = new Phrase() { Comment = "Me gusta, Me encanta la Coca pero Odio la Nix y la detesto" };
            phraseController.AnalyzePhrase(neutroPhrase);
            Assert.AreEqual(CategoryType.Neutro, neutroPhrase.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithDifferentUpperAndLowerLettersFormatPositiveSentiment()
        {
            positiveSentiment1 = new Sentiment() { Description = "Me gusta", Category = true };
            phraseWithUpperAndLower1 = new Phrase() { Comment = "mE GUsTa La pEPsI", Date = currentDate };
            sentimentController.AddSentiment(positiveSentiment1);
            phraseController.AddPhraseToRepository(phraseWithUpperAndLower1);

            phraseController.AnalyzePhrase(phraseWithUpperAndLower1);

            Assert.AreEqual(CategoryType.Positive, phraseWithUpperAndLower1.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithDifferentUpperAndLowerLettersFormatNegativeSentiment()
        {
            negativeSentiment1 = new Sentiment() { Description = "Odio", Category = false };
            phraseWithUpperAndLower2 = new Phrase() { Comment = "oDIo la guaRaNA", Date = currentDate };
            sentimentController.AddSentiment(negativeSentiment1);
            phraseController.AddPhraseToRepository(phraseWithUpperAndLower2);
            phraseController.AnalyzePhrase(phraseWithUpperAndLower2);
            Assert.AreEqual(CategoryType.Negative, phraseWithUpperAndLower2.Category);
        }
    }
}
