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
        Entity entity2;
        Alert alert;
        Phrase positive1PhraseEntity1;
        Phrase positive2PhraseEntity1;
        Phrase phrase1;
        Sentiment positive1;
        Sentiment positive2;

        [TestInitialize]
        public void Setup()
        {
            repository = Repository.Instance;
            alertController = new AlertController();
            phraseController = new PhraseController();
            sentimentController = new SentimentController();
            entityController = new EntityController();
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            repository.cleanLists();
        }

        [TestMethod]
        public void GenerateAlertToEntity()
        {
            entity1 = new Entity() { Name = "pepsi" };
            alert = new Alert() { Entity = entity1.Name, Category = CategoryType.Positive, Posts = 10, Days = 12 };
            alertController.AddAlert(alert);
            Assert.AreEqual(alert, alertController.ObtainAlert(alert));
        }

        [TestMethod]
        [ExpectedException(typeof(NullEntityException))]
        public void GenerateAlertWithNullEntity()
        {
            alert = new Alert() { Entity = null, Category = CategoryType.Positive, Posts = 10, Days = 2 };
            alertController.AddAlert(alert);
        }


        [TestMethod]
        [ExpectedException(typeof(NegativePostCountException))]
        public void GenerateAlertWithNegativePosts()
        {
            entity1 = new Entity() { Name = "pepsi" };
            alert = new Alert() { Entity = entity1.Name, Category = CategoryType.Positive, Posts = -2, Days = 3 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeDayException))]
        public void GenerateAlertWithNegativeDays()
        {
            entity1 = new Entity() { Name = "pepsi" };
            alert = new Alert() { Entity = entity1.Name, Category = CategoryType.Positive, Posts = 2, Days = -34 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeHourException))]
        public void GenerateAlertWithNegativeHours()
        {
            entity1 = new Entity() { Name = "pepsi" };
            alert = new Alert() { Entity = entity1.Name, Category = CategoryType.Positive, Posts = 2, Hours = -2 };
            alertController.AddAlert(alert);
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
            positive2 = new Sentiment() { Description = "Amo", Category = true };
            positive1 = new Sentiment() { Description = "Me encanta", Category = true };
            entity1 = new Entity() { Name = "pepsi" };
            positive1PhraseEntity1 = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1) };
            positive2PhraseEntity1 = new Phrase() { Comment = "Amo tomar pepsi", Date = DateTime.Now.AddDays(-1) };
            alert = new Alert() { Entity = entity1.Name, Category = CategoryType.Positive, Posts = 2, Days = 2 };
            sentimentController.AddSentiment(positive1);
            sentimentController.AddSentiment(positive2);
            entityController.AddEntity(entity1);
            phraseController.AddPhraseToRepository(positive1PhraseEntity1);
            phraseController.AddPhraseToRepository(positive2PhraseEntity1);
            phraseController.AnalyzePhrase(positive1PhraseEntity1);
            phraseController.AnalyzePhrase(positive2PhraseEntity1);
            alertController.AddAlert(alert);

            alertController.CheckAlertActivation();

            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void ActivateAlertIfDateNotInActivationRange()
        {
            entity1 = new Entity() { Name = "pepsi" };
            entity2 = new Entity() { Name = "PEpSI" };
            positive1 = new Sentiment() { Description = "Me encanta", Category = true };
            positive1PhraseEntity1 = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddYears(-1) };
            alert = new Alert() { Entity = entity1.Name, Category = CategoryType.Positive, Posts = 1, Days = 2 };
            entityController.AddEntity(entity2);
            sentimentController.AddSentiment(positive1);            
            phraseController.AddPhraseToRepository(positive1PhraseEntity1);
            phraseController.AnalyzePhrase(positive1PhraseEntity1);
            alertController.AddAlert(alert);
            alertController.CheckAlertActivation();
            Assert.IsFalse(alert.Activated);
        }

        [TestMethod]
        public void ActivateAlertOfPhrasesWithNeutroCategory()
        {
            entity1 = new Entity() { Name = "pepsi" };
            phrase1 = new Phrase() { Comment = "nacanaca pepsi", Date = DateTime.Now.AddDays(-1) };
            alert = new Alert() { Entity = entity1.Name, Category = CategoryType.Neutro, Posts = 2, Days = 5 };
            entityController.AddEntity(entity1);
            phraseController.AddPhraseToRepository(phrase1);
            phraseController.AnalyzePhrase(phrase1);
            alertController.AddAlert(alert);
            alertController.CheckAlertActivation();
            Assert.IsFalse(alert.Activated);
        }

        [TestMethod]
        public void ActivateAlertOfPhrasesWithEntityWithDifferentLetterFormat()
        {
            entity1 = new Entity() { Name = "pepsi" };
            entity2 = new Entity() { Name = "PEpSI" };
            positive1 = new Sentiment() { Description = "Me encanta", Category = true };
            positive1PhraseEntity1 = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1) };
            alert = new Alert() { Entity = entity1.Name, Category = CategoryType.Positive, Posts = 1, Days = 2 };
            entityController.AddEntity(entity2);
            sentimentController.AddSentiment(positive1);
            phraseController.AddPhraseToRepository(positive1PhraseEntity1);
            phraseController.AnalyzePhrase(positive1PhraseEntity1);
            alertController.AddAlert(alert);
            alertController.CheckAlertActivation();
            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void ActivateAlertOfPhrasesWithEntityWithSameNameButBlankSpacesInEdges()
        {
            entity1 = new Entity() { Name = "pepsi" };
            entity2 = new Entity() { Name = "  pepsi   " };
            positive1 = new Sentiment() { Description = "Me encanta", Category = true };
            positive1PhraseEntity1 = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1) };
            alert = new Alert() { Entity = entity2.Name, Category = CategoryType.Positive, Posts = 1, Days = 2 };
            entityController.AddEntity(entity1);
            sentimentController.AddSentiment(positive1);
            phraseController.AddPhraseToRepository(positive1PhraseEntity1);
            phraseController.AnalyzePhrase(positive1PhraseEntity1);
            alertController.AddAlert(alert);
            alertController.CheckAlertActivation();
            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void ActivateAlertAndThenTurnItOff()
        {
            entity1 = new Entity() { Name = "pepsi" };
            alert = new Alert() { Entity = entity1.Name, Category = CategoryType.Positive, Posts = 1, Days = 2 };
            phrase1 = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1) };
            positive1 = new Sentiment() { Description = "Me encanta", Category = true };
            sentimentController.AddSentiment(positive1);
            alertController.AddAlert(alert);
            phraseController.AddPhraseToRepository(phrase1);
            entityController.AddEntity(entity1);
            phraseController.AnalyzePhrase(phrase1);
            alertController.CheckAlertActivation();
            Assert.IsTrue(alert.Activated);
            entityController.RemoveEntity(entity1.Name);

            phraseController.AnalyzeAllPhrases();
            alertController.CheckAlertActivation();

            Assert.IsFalse(alert.Activated);
        }
    }
}
