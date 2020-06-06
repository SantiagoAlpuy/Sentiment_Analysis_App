using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
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
        Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };


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
            phrase1 = new Phrase() { Comment = "Me gusta la Pepsi", Date = currentDate, Author = author };
            phrase2 = new Phrase() { Comment = "Odio la Limol", Date = currentDate, Author = author };
            phraseController.AddPhrase(phrase1);
            phraseController.AddPhrase(phrase2);
            Assert.AreEqual(phrase1, phraseController.ObtainPhrase(phrase1.Comment, phrase1.Date));
            Assert.AreEqual(phrase2, phraseController.ObtainPhrase(phrase2.Comment, phrase2.Date));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RegisterNullPhrase()
        {
            phraseController.AddPhrase(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterPhraseWithEmptyDescription()
        {
            phraseWithEmptyComment = new Phrase() { Comment = "", Date = currentDate, Author = author };
            phraseController.AddPhrase(phraseWithEmptyComment);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterPhraseWhoseDescriptionHasManyBlankSpaces()
        {
            phraseWithEmptyComment = new Phrase() { Comment = "   ", Date = currentDate, Author = author };
            phraseController.AddPhrase(phraseWithEmptyComment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RegisterPhraseWithNullComment()
        {
            nullCommentPhrase = new Phrase();
            phraseController.AddPhrase(nullCommentPhrase);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterPhraseWithDateOlderThanOneYear()
        {
            oldPhrase = new Phrase() { Comment = "Frase con fecha inferior a un año", Date = new DateTime(2019, 01, 01) };
            phraseController.AddPhrase(oldPhrase);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterPhraseWithDateFromFuture()
        {
            futurePhrase = new Phrase() { Comment = "Frase con fecha del futuro", Date = new DateTime(2025, 01, 1), Author = author };
            phraseController.AddPhrase(futurePhrase);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithNoRegisteredEntityInEntitiesList()
        {
            phrase1 = new Phrase() { Comment = "Me gusta la Pepsi", Date = currentDate, Author = author };
            phraseController.AnalyzePhrase(phrase1);
            Assert.AreEqual("", phrase1.Entity);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithOnlyOneEntityInEntitiesList()
        {
            phrase1 = new Phrase() { Comment = "Me gusta la Pepsi", Date = currentDate, Author = author };
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
            phraseWith3Entities = new Phrase() { Comment = "Me gusta la Pepsi la Coca y la Nix", Date = currentDate, Author = author };
            phraseController.AnalyzePhrase(phraseWith3Entities);
            Assert.AreEqual("Pepsi", phraseWith3Entities.Entity);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithDifferentUpperAndLowerLettersFormat()
        {
            entity = new Entity() { Name = "Pepsi" };
            phraseWithUpperAndLower1 = new Phrase() { Comment = "mE GUsTa La pEPsI", Date = currentDate, Author = author };
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
            phrase1 = new Phrase() { Comment = "Me gusta la Pepsi",  Date = currentDate, Author = author };
            sentimentController.AddSentiment(positiveSentiment1);
            phraseController.AnalyzePhrase(phrase1);
            Assert.AreEqual(CategoryType.Positiva, phrase1.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithOneNegativeSentiment()
        {
            negativeSentiment1 = new Sentiment() { Description = "Odio", Category = false };
            phrase2 = new Phrase() { Comment = "Odio la Limol", Date = currentDate, Author = author };
            sentimentController.AddSentiment(negativeSentiment1);
            phraseController.AnalyzePhrase(phrase2);
            Assert.AreEqual(CategoryType.Negativa, phrase2.Category);
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
            neutroPhrase = new Phrase() { Comment = "Me gusta, Me encanta la Coca pero Odio la Nix y la detesto", Author = author };
            phraseController.AnalyzePhrase(neutroPhrase);
            Assert.AreEqual(CategoryType.Neutro, neutroPhrase.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithDifferentUpperAndLowerLettersFormatPositiveSentiment()
        {
            positiveSentiment1 = new Sentiment() { Description = "Me gusta", Category = true };
            phraseWithUpperAndLower1 = new Phrase() { Comment = "mE GUsTa La pEPsI", Date = currentDate, Author = author };
            sentimentController.AddSentiment(positiveSentiment1);
            phraseController.AddPhrase(phraseWithUpperAndLower1);

            phraseController.AnalyzePhrase(phraseWithUpperAndLower1);

            Assert.AreEqual(CategoryType.Positiva, phraseWithUpperAndLower1.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithDifferentUpperAndLowerLettersFormatNegativeSentiment()
        {
            negativeSentiment1 = new Sentiment() { Description = "Odio", Category = false };
            phraseWithUpperAndLower2 = new Phrase() { Comment = "oDIo la guaRaNA", Date = currentDate, Author = author };
            sentimentController.AddSentiment(negativeSentiment1);
            phraseController.AddPhrase(phraseWithUpperAndLower2);
            phraseController.AnalyzePhrase(phraseWithUpperAndLower2);
            Assert.AreEqual(CategoryType.Negativa, phraseWithUpperAndLower2.Category);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterPhraseWithoutAuthor()
        {
            
            Phrase phrase = new Phrase() { Comment = "me gusta la hamburguesa", Date = currentDate};
            phraseController.AddPhrase(phrase);
        }
    }
}
