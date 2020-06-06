using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;

namespace Tests
{
    [TestClass]
    public class AlertATest
    {
        Repository repository;
        AlertAController alertController;
        IPhraseController phraseController;
        ISentimentController sentimentController;
        IEntityController entityController;

        Entity entity1;
        Entity entity2;
        AlertA alert;
        Phrase positive1PhraseEntity1;
        Phrase positive2PhraseEntity1;
        Phrase phrase1;
        Sentiment positive1;
        Sentiment positive2;

        Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };

        [TestInitialize]
        public void Setup()
        {
            repository = Repository.Instance;
            alertController = new AlertAController();
            phraseController = new PhraseController();
            sentimentController = new SentimentController();
            entityController = new EntityController();
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            repository.CleanLists();
        }

        [TestMethod]
        public void GenerateAlertToEntity()
        {
            entity1 = new Entity() { Name = "pepsi" };
            alert = new AlertA() { Entity = entity1.Name, Category = CategoryType.Positiva, Posts = 10, Days = 12 };
            alertController.AddAlert(alert);
            Assert.AreEqual(alert, alertController.ObtainAlert(alert));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GenerateAlertWithNullEntity()
        {
            alert = new AlertA() { Entity = null, Category = CategoryType.Positiva, Posts = 10, Days = 2 };
            alertController.AddAlert(alert);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithNegativePosts()
        {
            entity1 = new Entity() { Name = "pepsi" };
            alert = new AlertA() { Entity = entity1.Name, Category = CategoryType.Positiva, Posts = -2, Days = 3 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithNegativeDays()
        {
            entity1 = new Entity() { Name = "pepsi" };
            alert = new AlertA() { Entity = entity1.Name, Category = CategoryType.Positiva, Posts = 2, Days = -34 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithNegativeHours()
        {
            entity1 = new Entity() { Name = "pepsi" };
            alert = new AlertA() { Entity = entity1.Name, Category = CategoryType.Positiva, Posts = 2, Hours = -2 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
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
            positive1PhraseEntity1 = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            positive2PhraseEntity1 = new Phrase() { Comment = "Amo tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            alert = new AlertA() { Entity = entity1.Name, Category = CategoryType.Positiva, Posts = 2, Days = 2 };
            sentimentController.AddSentiment(positive1);
            sentimentController.AddSentiment(positive2);
            entityController.AddEntity(entity1);
            phraseController.AddPhraseToRepository(positive1PhraseEntity1);
            phraseController.AddPhraseToRepository(positive2PhraseEntity1);
            phraseController.AnalyzePhrase(positive1PhraseEntity1);
            phraseController.AnalyzePhrase(positive2PhraseEntity1);
            alertController.AddAlert(alert);

            alertController.EvaluateAlerts();

            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void DontIncreaseAlertCountIfPhraseDateIsOlderThanAnYear()
        {
            entity1 = new Entity() { Name = "pepsi" };
            entity2 = new Entity() { Name = "PEpSI" };
            positive1 = new Sentiment() { Description = "Me encanta", Category = true };
            positive1PhraseEntity1 = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddYears(-1), Author = author };
            alert = new AlertA() { Entity = entity1.Name, Category = CategoryType.Positiva, Posts = 1, Days = 2 };
            entityController.AddEntity(entity2);
            sentimentController.AddSentiment(positive1);            
            phraseController.AddPhraseToRepository(positive1PhraseEntity1);
            phraseController.AnalyzePhrase(positive1PhraseEntity1);
            alertController.AddAlert(alert);
            alertController.EvaluateAlerts();
            Assert.IsFalse(alert.Activated);
        }

        [TestMethod]
        public void ActivateAlertOfPhrasesWithEntityWithDifferentLetterFormat()
        {
            entity1 = new Entity() { Name = "pepsi" };
            entity2 = new Entity() { Name = "PEpSI" };
            positive1 = new Sentiment() { Description = "Me encanta", Category = true };
            positive1PhraseEntity1 = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            alert = new AlertA() { Entity = entity1.Name, Category = CategoryType.Positiva, Posts = 1, Days = 2 };
            entityController.AddEntity(entity2);
            sentimentController.AddSentiment(positive1);
            phraseController.AddPhraseToRepository(positive1PhraseEntity1);
            phraseController.AnalyzePhrase(positive1PhraseEntity1);
            alertController.AddAlert(alert);
            alertController.EvaluateAlerts();
            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void ActivateAlertOfPhrasesWithEntityWithSameNameButBlankSpacesInEdges()
        {
            entity1 = new Entity() { Name = "pepsi" };
            entity2 = new Entity() { Name = "  pepsi   " };
            positive1 = new Sentiment() { Description = "Me encanta", Category = true };
            positive1PhraseEntity1 = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            alert = new AlertA() { Entity = entity2.Name, Category = CategoryType.Positiva, Posts = 1, Days = 2 };
            entityController.AddEntity(entity1);
            sentimentController.AddSentiment(positive1);
            phraseController.AddPhraseToRepository(positive1PhraseEntity1);
            phraseController.AnalyzePhrase(positive1PhraseEntity1);
            alertController.AddAlert(alert);
            alertController.EvaluateAlerts();
            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void ActivateAlert()
        {
            entity1 = new Entity() { Name = "pepsi" };
            alert = new AlertA() { Entity = entity1.Name, Category = CategoryType.Positiva, Posts = 1, Days = 2 };
            phrase1 = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            positive1 = new Sentiment() { Description = "Me encanta", Category = true };
            sentimentController.AddSentiment(positive1);
            alertController.AddAlert(alert);
            phraseController.AddPhraseToRepository(phrase1);
            entityController.AddEntity(entity1);
            phraseController.AnalyzePhrase(phrase1);
            alertController.EvaluateAlerts();
            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void DeactivateAlert()
        {
            entity1 = new Entity() { Name = "pepsi" };
            alert = new AlertA() { Entity = entity1.Name, Category = CategoryType.Positiva, Posts = 1, Days = 2 };
            phrase1 = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            positive1 = new Sentiment() { Description = "Me encanta", Category = true };
            sentimentController.AddSentiment(positive1);
            alertController.AddAlert(alert);
            phraseController.AddPhraseToRepository(phrase1);
            entityController.AddEntity(entity1);
            phraseController.AnalyzePhrase(phrase1);
            alertController.EvaluateAlerts();
            entityController.RemoveEntity(entity1.Name);
            phraseController.AnalyzeAllPhrases();
            alertController.EvaluateAlerts();
            Assert.IsFalse(alert.Activated);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithEmptyEntityField()
        {
            entity1 = new Entity() { Name = "" };
            alert = new AlertA() { Entity = entity1.Name, Category = CategoryType.Positiva, Posts = 2, Hours = 2 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithMultipleBlankSpacesInEntityField()
        {
            entity1 = new Entity() { Name = "    " };
            alert = new AlertA() { Entity = entity1.Name, Category = CategoryType.Positiva, Posts = 2, Hours = 2 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithNeutroCategory()
        {
            entity1 = new Entity() { Name = "pepsi" };
            alert = new AlertA() { Entity = entity1.Name, Category = CategoryType.Neutro, Posts = 2, Hours = 2 };
            alertController.AddAlert(alert);
        }

    }
}
