using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace Tests
{
    [TestClass]
    public class PhraseTest
    {
        Repository repository;
        Phrase phrase1;
        Phrase phrase2;
        Phrase phraseWithEmptyComment;
        Phrase nullCommentPhrase;
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
            repository.CleanLists();
        }

        [TestMethod]
        public void RegisterPhrase()
        {
            repository.addPhrase(phrase1);
            repository.addPhrase(phrase2);
            Assert.AreEqual(phrase1, repository.obtainPhrase(phrase1.Comment, phrase1.Date));
            Assert.AreEqual(phrase2, repository.obtainPhrase(phrase2.Comment, phrase2.Date));
        }

        [TestMethod]
        [ExpectedException(typeof(NullPhraseException))]
        public void RegisterNullPhrase()
        {
            repository.addPhrase(null);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterPhraseWithEmptyDescription()
        {
            repository.addPhrase(phraseWithEmptyComment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAttributeInObjectException))]
        public void RegisterPhraseWithNullComment()
        {
            repository.addPhrase(nullCommentPhrase);
        }


        [TestMethod]
        public void AnalyzeEntityOfPhraseWithNoRegisteredEntityInEntitiesList()
        {
            repository.analyzePhrase(phrase1);
            Assert.AreEqual("", phrase1.Entity);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithOnlyOneEntityInEntitiesList()
        {
            repository.addEntity(entity);
            repository.analyzePhrase(phrase1);
            Assert.AreEqual("Pepsi", phrase1.Entity);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithMultipleEntities()
        {
            repository.addEntity(entity);
            repository.addEntity(entity1);
            repository.addEntity(entity2);
            repository.analyzePhrase(phrase1);
            Assert.AreEqual("Pepsi", phrase1.Entity);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithNoSentiments()
        {
            repository.analyzePhrase(phraseWithNoSent);
            Assert.AreEqual("neutro", phraseWithNoSent.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithOnePositiveSentiment()
        {
            repository.addSentiment(positiveSentiment1);
            repository.analyzePhrase(phrase1);
            Assert.AreEqual("positive", phrase1.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithOneNegativeSentiment()
        {
            repository.addSentiment(negativeSentiment1);
            repository.analyzePhrase(phrase2);
            Assert.AreEqual("negative", phrase2.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithMultipleNegativeAndOPositiveSentiments()
        {
            repository.addSentiment(negativeSentiment1);
            repository.addSentiment(positiveSentiment1);
            repository.addSentiment(negativeSentiment2);
            repository.addSentiment(positiveSentiment2);
            repository.analyzePhrase(neutroPhrase);
            Assert.AreEqual("neutro", neutroPhrase.Category);
        }
    }
}
