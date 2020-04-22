using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Exceptions;
using BusinessLogic.Controllers;

namespace Tests
{
    [TestClass]
    public class PhraseTest
    {
        Repository repository;
        SentimentController sentimentController;
        PhraseController phraseController;
        EntityController entityController;
        Phrase phrase1;
        Phrase phrase2;
        Phrase phraseWithEmptyComment;
        Phrase nullCommentPhrase;
        Phrase oldPhrase;
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


        [TestInitialize]
        public void Setup()
        {
            repository = Repository.Instance;
            sentimentController = new SentimentController();
            phraseController = new PhraseController();
            entityController = new EntityController();

            DateTime now = DateTime.Now;
            phrase1 = new Phrase()
            {
                Comment = "Me gusta la Pepsi",
                Date = now,
            };

            phrase2 = new Phrase()
            {
                Comment = "Odio la Limol",
                Date = now,
            };

            phraseWithEmptyComment = new Phrase()
            {
                Comment = "",
                Date = now,
            };

            nullCommentPhrase = new Phrase();

            oldPhrase = new Phrase()
            {
                Comment = "Frase con fecha inferior a un año",
                Date = new DateTime(2019,01,01),
            };

            phraseWithNoSent = new Phrase()
            {
                Comment = "Mike Tyson",
            };

            phraseWith3Entities = new Phrase()
            {
                Comment = "Me gusta la Coca, la Nix, y la Pepsi",
                Date = now,
            };

            neutroPhrase = new Phrase()
            {
                Comment = "Me gusta, Me encanta la Coca pero Odio la Nix y la detesto",
            };

            entity = new Entity()
            {
                Name = "Pepsi",
            };
            
            entity1 = new Entity()
            {
                Name = "Coca",
            };

            entity2 = new Entity()
            {
                Name = "Nix",
            };

            positiveSentiment1 = new Sentiment()
            {
                Description = "Me gusta",
                Category = true,
            };

            negativeSentiment1 = new Sentiment()
            {
                Description = "Odio",
                Category = false,
            };

            positiveSentiment2 = new Sentiment()
            {
                Description = "Me encanta",
                Category = true,
            };

            negativeSentiment2 = new Sentiment()
            {
                Description = "detesto",
                Category = false,
            };
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            repository.cleanLists();
        }

        [TestMethod]
        public void RegisterPhrase()
        {
            phraseController.addPhrase(phrase1);
            phraseController.addPhrase(phrase2);
            Assert.AreEqual(phrase1, phraseController.obtainPhrase(phrase1.Comment, phrase1.Date));
            Assert.AreEqual(phrase2, phraseController.obtainPhrase(phrase2.Comment, phrase2.Date));
        }

        [TestMethod]
        [ExpectedException(typeof(NullPhraseException))]
        public void RegisterNullPhrase()
        {
            phraseController.addPhrase(null);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterPhraseWithEmptyDescription()
        {
            phraseController.addPhrase(phraseWithEmptyComment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAttributeInObjectException))]
        public void RegisterPhraseWithNullComment()
        {
            phraseController.addPhrase(nullCommentPhrase);
        }

        [TestMethod]
        [ExpectedException(typeof(DateOlderThanOneYearException))]
        public void RegisterPhraseWithDateOlderThanOneYear()
        {
            phraseController.addPhrase(oldPhrase);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithNoRegisteredEntityInEntitiesList()
        {
            phraseController.analyzePhrase(phrase1);
            Assert.AreEqual("", phrase1.Entity);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithOnlyOneEntityInEntitiesList()
        {
            entityController.addEntity(entity);
            phraseController.analyzePhrase(phrase1);
            Assert.AreEqual("Pepsi", phrase1.Entity);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithMultipleEntities()
        {
            entityController.addEntity(entity);
            entityController.addEntity(entity1);
            entityController.addEntity(entity2);
            phraseController.analyzePhrase(phrase1);
            Assert.AreEqual("Pepsi", phrase1.Entity);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithNoSentiments()
        {
            phraseController.analyzePhrase(phraseWithNoSent);
            Assert.AreEqual("neutro", phraseWithNoSent.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithOnePositiveSentiment()
        {
            sentimentController.addSentiment(positiveSentiment1);
            phraseController.analyzePhrase(phrase1);
            Assert.AreEqual("positive", phrase1.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithOneNegativeSentiment()
        {
            sentimentController.addSentiment(negativeSentiment1);
            phraseController.analyzePhrase(phrase2);
            Assert.AreEqual("negative", phrase2.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithMultipleNegativeAndOPositiveSentiments()
        {
            sentimentController.addSentiment(negativeSentiment1);
            sentimentController.addSentiment(positiveSentiment1);
            sentimentController.addSentiment(negativeSentiment2);
            sentimentController.addSentiment(positiveSentiment2);
            phraseController.analyzePhrase(neutroPhrase);
            Assert.AreEqual("neutro", neutroPhrase.Category);
        }
    }
}
