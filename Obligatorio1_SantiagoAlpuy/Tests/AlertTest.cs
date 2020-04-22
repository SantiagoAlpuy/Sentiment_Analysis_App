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
                Name = "Pepsi",
            };

            alert1 = new Alert()
            {
                Entity = entity1,
                Category = true,
                Posts = 10,
                Time = 12334,
            };

            alert2 = new Alert()
            {
                Entity = null,
                Category = true,
                Posts = 10,
                Time = 12334,
            };

            alert3 = new Alert()
            {
                Entity = entity1,
                Category = true,
                Posts = -2,
                Time = 12334,
            };

            alert4 = new Alert()
            {
                Entity = entity1,
                Category = true,
                Posts = 2,
                Time = -34,
            };

            alert5 = new Alert()
            {
                Entity = entity1,
                Category = true,
                Posts = 2,
                Time = 50000000,
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
        [ExpectedException(typeof(NegativeTimeException))]
        public void GenerateAlertWithNegativeTime()
        {
            alertController.AddAlert(alert4);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAlertException))]
        public void AddNullAlertToRepository()
        {
            alertController.AddAlert(null);
        }

        [TestMethod]
        public void PhraseTurnsAlertOn()
        {
            phrase1 = new Phrase()
            {
                Comment = "Me encanta tomar pepsi",
                Date = new DateTime(2020, 04, 01),
            };
            phrase2 = new Phrase()
            {
                Comment = "Amo tomar pepsi",
                Date = new DateTime(2020, 04, 01),
            };
            Sentiment sentiment1 = new Sentiment()
            {
                Description = "AMO",
                Category = true,
            };
            Sentiment sentiment2 = new Sentiment()
            {
                Description = "me encanta",
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
            alertController.CheckAlertsActivation();
            Assert.IsTrue(alert5.Activated);

        }
    }
}
