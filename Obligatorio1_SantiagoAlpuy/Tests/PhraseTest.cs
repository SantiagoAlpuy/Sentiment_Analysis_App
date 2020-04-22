using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace Tests
{
    [TestClass]
    public class PhraseTest
    {
        Phrase phrase1;
        Phrase phrase2;
        Phrase phraseWithEmptyComment;
        Phrase nullCommentPhrase;
        Phrase phraseWith3Entities;
        Entity entity;
        Entity entity1;
        Entity entity2;
        Sentiment positiveSentiment1;


        [TestInitialize]
        public void Setup()
        {
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

            phraseWith3Entities = new Phrase()
            {
                Comment = "Me gusta la Coca, la Nix, y la Pepsi",
                Date = now,
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
        }

        [TestMethod]
        public void RegisterPhrase()
        {
            
            Repository repository = Repository.Instance;
            repository.addPhrase(phrase1);
            repository.addPhrase(phrase2);
            Assert.AreEqual(phrase1, repository.obtainPhrase(phrase1.Comment, phrase1.Date));
            Assert.AreEqual(phrase2, repository.obtainPhrase(phrase2.Comment, phrase2.Date));
        }

        [TestMethod]
        [ExpectedException(typeof(NullPhraseException))]
        public void RegisterNullPhrase()
        {
            Repository repository = Repository.Instance;
            repository.addPhrase(null);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterPhraseWithEmptyDescription()
        {
            Repository repository = Repository.Instance;
            repository.addPhrase(phraseWithEmptyComment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAttributeInObjectException))]
        public void RegisterPhraseWithNullComment()
        {
            Repository repository = Repository.Instance;
            repository.addPhrase(nullCommentPhrase);
        }


        [TestMethod]
        public void AnalyzeEntityOfPhraseWithNoRegisteredEntityInEntitiesList()
        {
            Repository repository = Repository.Instance;
            repository.analyzePhrase(phrase1);
            Assert.AreEqual("", phrase1.Entity);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithOnlyOneEntityInEntitiesList()
        {
            
            Repository repository = Repository.Instance;
            repository.addEntity(entity);
            repository.analyzePhrase(phrase1);
            Assert.AreEqual("Pepsi", phrase1.Entity);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithMultipleEntities()
        {
            
            Repository repository = Repository.Instance;
            repository.addEntity(entity);
            repository.addEntity(entity1);
            repository.addEntity(entity2);
            repository.analyzePhrase(phrase1);
            Assert.AreEqual("Pepsi", phrase1.Entity);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithOnePositiveSentiment()
        {
            Repository repository = Repository.Instance;
            repository.addSentiment(positiveSentiment1);
            repository.analyzePhrase(phrase1);
            Assert.IsTrue(phrase1.Category);
        }
    }
}
