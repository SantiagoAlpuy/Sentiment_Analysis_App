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
        Phrase phrase1;
        Phrase phrase2;

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
        public void PhrasesTurnsAlertOn()
        {
            phrase1 = new Phrase()
            {
                Comment = "Me encanta tomar pepsi",
                Date = DateTime.Now.AddDays(-1),
            };
            phrase2 = new Phrase()
            {
                Comment = "Amo tomar pepsi",
                Date = DateTime.Now.AddDays(-1),
            };
            Sentiment sentiment1 = new Sentiment()
            {
                Description = "Amo",
                Category = true,
            };
            Sentiment sentiment2 = new Sentiment()
            {
                Description = "Me encanta",
                Category = true,
            };
            Entity entity1 = new Entity()
            {
                Name = "pepsi",
            };
            sentimentController.AddSentiment(sentiment1);
            sentimentController.AddSentiment(sentiment2);
            entityController.AddEntity(entity1);
            phraseController.AddPhrase(phrase1);
            phraseController.AddPhrase(phrase2);
            phraseController.AnalyzePhrase(phrase1);
            phraseController.AnalyzePhrase(phrase2);
            alertController.AddAlert(alert5);
            alertController.CheckAlertActivation();
            Assert.IsTrue(alert5.Activated);
        }
    }
}
