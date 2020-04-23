using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Exceptions;
using BusinessLogic.Controllers;

namespace Tests
{
    [TestClass]
    public class AlertTest
    {
        Repository repository;
        AlertController alertController;
        PhraseController phraseController;
        SentimentController sentimentController;
        EntityController entityController;
        Entity entity1;
        Alert alert1;
        Alert alert2;
        Alert alert3;
        Alert alert4;
        Alert alert5;
        Alert alert6;
        Alert alert7;
        Phrase positive1PhraseEntity1;
        Phrase positive2PhraseEntity1;
        Phrase neutroPhrase1;
        Phrase neutroPhrase2;
        Sentiment positive2;
        Sentiment positive1;

        [TestInitialize]
        public void Setup()
        {
            repository = Repository.Instance;
            alertController = new AlertController();
            phraseController = new PhraseController();
            sentimentController = new SentimentController();
            entityController = new EntityController();

            entity1 = new Entity()
            {
                Name = "pepsi",
            };

            alert1 = new Alert()
            {
                Entity = entity1.Name,
                Category = CategoryType.Positive,
                Posts = 10,
                Days = 12,
            };

            alert2 = new Alert()
            {
                Entity = null,
                Category = CategoryType.Positive,
                Posts = 10,
                Days = 2,
            };

            alert3 = new Alert()
            {
                Entity = entity1.Name,
                Category = CategoryType.Positive,
                Posts = -2,
                Days = 3,
            };

            alert4 = new Alert()
            {
                Entity = entity1.Name,
                Category = CategoryType.Positive,
                Posts = 2,
                Days = -34,
            };

            alert5 = new Alert()
            {
                Entity = entity1.Name,
                Category = CategoryType.Positive,
                Posts = 2,
                Days = 2,
            };

            alert6 = new Alert()
            {
                Entity = entity1.Name,
                Category = CategoryType.Positive,
                Posts = 2,
                Hours = -2,
            };

            alert7 = new Alert()
            {
                Entity = entity1.Name,
                Category = CategoryType.Neutro,
                Posts = 2,
                Days = 5,
            };

            positive1PhraseEntity1 = new Phrase()
            {
                Comment = "Me encanta tomar pepsi",
                Date = DateTime.Now.AddDays(-1),
            };

            positive2PhraseEntity1 = new Phrase()
            {
                Comment = "Amo tomar pepsi",
                Date = DateTime.Now.AddDays(-1),
            };

            neutroPhrase1 = new Phrase()
            {
                Comment = "nacanaca pepsi",
                Date = DateTime.Now.AddDays(-1),
            };

            neutroPhrase2 = new Phrase()
            {
                Comment = "noconoco pepsi",
                Date = DateTime.Now.AddDays(-1),
            };

            positive2 = new Sentiment()
            {
                Description = "Amo",
                Category = true,
            };

            positive1 = new Sentiment()
            {
                Description = "Me encanta",
                Category = true,
            };

            entity1 = new Entity()
            {
                Name = "pepsi",
            };
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            repository.cleanLists();
        }

        [TestMethod]
        public void GenerateAlertToEntity()
        {
            alertController.AddAlert(alert1);
            Assert.AreEqual(alert1, alertController.ObtainAlert(alert1));
        }

        [TestMethod]
        [ExpectedException(typeof(NullEntityException))]
        public void GenerateAlertWithNullEntity()
        {
            alertController.AddAlert(alert2);
        }


        [TestMethod]
        [ExpectedException(typeof(NegativePostCountException))]
        public void GenerateAlertWithNegativePosts()
        {
            alertController.AddAlert(alert3);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeDayException))]
        public void GenerateAlertWithNegativeDays()
        {
            alertController.AddAlert(alert4);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeHourException))]
        public void GenerateAlertWithNegativeHours()
        {
            alertController.AddAlert(alert6);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAlertException))]
        public void AddNullAlertToRepository()
        {
            alertController.AddAlert(null);
        }

        [TestMethod]
        public void ActivateAlertIfDateInActivationRange()
        {
            sentimentController.AddSentiment(positive1);
            sentimentController.AddSentiment(positive2);
            entityController.AddEntity(entity1);
            phraseController.AddPhrase(positive1PhraseEntity1);
            phraseController.AddPhrase(positive2PhraseEntity1);
            alertController.AddAlert(alert5);
            alertController.CheckAlertActivation();
            Assert.IsTrue(alert5.Activated);
        }

        [TestMethod]
        public void ActivateAlertOfPhrasesWithNeutroCategory()
        {
            entityController.AddEntity(entity1);
            phraseController.AddPhrase(neutroPhrase1);
            alertController.AddAlert(alert7);
            alertController.CheckAlertActivation();
            Assert.IsFalse(alert7.Activated);
        }
    }
}
