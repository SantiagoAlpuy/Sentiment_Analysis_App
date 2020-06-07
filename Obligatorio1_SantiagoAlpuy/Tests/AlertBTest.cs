using System;
using System.Collections.Generic;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AlertBTest
    {
        AlertBController alertController;
        IPhraseController phraseController;
        ISentimentController sentimentController;
        IAuthorController authorController;

        [TestInitialize]
        public void Setup()
        {
            InitializeControllers();
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            ClearDatabase();
        }

        private void InitializeControllers()
        {
            sentimentController = new SentimentController();
            phraseController = new PhraseController();
            authorController = new AuthorController();
            alertController = new AlertBController();
        }

        private void ClearDatabase()
        {
            sentimentController.RemoveAllSentiments();
            phraseController.RemoveAllPhrases();
            authorController.RemoveAllAuthors();
            alertController.RemoveAllAlerts();
        }

        [TestMethod]
        public void GenerateAlertB()
        {
            IAlert alert = new AlertB { Category = CategoryType.Positiva, Posts = 10, Days = 10, Hours = 5, Activated = false };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertBWithNegativePostCount()
        {
            IAlert alert = new AlertB { Category = CategoryType.Positiva, Posts = -4, Days = 10, Hours = 5, Activated = false };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertBWithNegativeDays()
        {
            IAlert alert = new AlertB { Category = CategoryType.Positiva, Posts = 4, Days = -2, Hours = 5, Activated = false };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertBWithNegativeHours()
        {
            IAlert alert = new AlertB { Category = CategoryType.Positiva, Posts = 4, Days = 2, Hours = -5, Activated = false };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithNeutroCategory()
        {
            IAlert alert = new AlertB() { Category = CategoryType.Neutro, Posts = 2, Hours = 2 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithPostCountBiggerThanUpperBound()
        {
            IAlert alert = new AlertB { Category = CategoryType.Positiva, Posts = 1001, Days = 10, Hours = 5, Activated = false };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        public void ActivateAlert()
        {
            AlertB alert = new AlertB() { Category = CategoryType.Positiva, Posts = 1, Days = 2 };
            Author author = new Author { Username = "username1", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Phrase phrase = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            Sentiment sentiment = new Sentiment() { Description = "Me encanta", Category = true };
            sentimentController.AddSentiment(sentiment);
            alertController.AddAlert(alert);
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            phraseController.AnalyzePhrase(phrase);
            alertController.EvaluateAlerts();
            alert = alertController.ObtainAlert(alert.AlertBId);
            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void DeactivateAlert()
        {
            IAlert alert = new AlertB() { Category = CategoryType.Positiva, Posts = 1, Days = 2 };
            Author author = new Author { Username = "username1", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Phrase phrase = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            Sentiment sentiment = new Sentiment() { Description = "Me encanta", Category = true };
            sentimentController.AddSentiment(sentiment);
            alertController.AddAlert(alert);
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            phraseController.AnalyzePhrase(phrase);
            alertController.EvaluateAlerts();
            sentimentController.RemoveSentiment(sentiment.Description, true);
            phraseController.AnalyzeAllPhrases();
            alertController.EvaluateAlerts();
            Assert.IsFalse(alert.Activated);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithZeroPostCount()
        {
            Entity entity = new Entity() { Name = "pepsi" };
            AlertB alert = new AlertB() { Category = CategoryType.Positiva, Posts = 0, Hours = 2 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        public void SetAuthorsOfActivatedPhrases()
        {
            AlertB alert = new AlertB() { Category = CategoryType.Positiva, Posts = 1, Days = 2 };
            Author author = new Author { Username = "username1", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Phrase phrase = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            Sentiment sentiment = new Sentiment() { Description = "Me encanta", Category = true };
            sentimentController.AddSentiment(sentiment);
            alertController.AddAlert(alert);
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            phraseController.AnalyzePhrase(phrase);
            alertController.EvaluateAlerts();
            alert = alertController.ObtainAlert(alert.AlertBId);
            Assert.AreEqual(1,alert.AuthorsOfActivatedPhrases.Count());
        }
    }
}
