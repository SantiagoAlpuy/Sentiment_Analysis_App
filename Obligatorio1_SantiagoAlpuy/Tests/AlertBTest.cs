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
        Repository repository;
        IAlertController alertController;
        IPhraseController phraseController;
        ISentimentController sentimentController;

        [TestInitialize]
        public void Setup()
        {
            repository = Repository.Instance;
            alertController = new AlertAController();
            phraseController = new PhraseController();
            sentimentController = new SentimentController();
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            repository.CleanLists();
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
            IAlert alert = new AlertB() { Category = CategoryType.Positiva, Posts = 1, Days = 2 };
            Author author = new Author { Username = "username1", Name = "name1", Surname = "surname1", Born = new DateTime(1960, 01, 01) };
            Phrase phrase = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            Sentiment sentiment = new Sentiment() { Description = "Me encanta", Category = true };
            sentimentController.AddSentiment(sentiment);
            alertController.AddAlert(alert);
            phraseController.AddPhrase(phrase);
            phraseController.AnalyzePhrase(phrase);
            alertController.EvaluateAlerts();
            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void DeactivateAlert()
        {
            IAlert alert = new AlertB() { Category = CategoryType.Positiva, Posts = 1, Days = 2 };
            Author author = new Author { Username = "username1", Name = "name1", Surname = "surname1", Born = new DateTime(1960, 01, 01) };
            Phrase phrase = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            Sentiment sentiment = new Sentiment() { Description = "Me encanta", Category = true };
            sentimentController.AddSentiment(sentiment);
            alertController.AddAlert(alert);
            phraseController.AddPhrase(phrase);
            phraseController.AnalyzePhrase(phrase);
            alertController.EvaluateAlerts();
            sentimentController.RemoveSentiment(sentiment.Description, true);
            phraseController.AnalyzeAllPhrases();
            alertController.EvaluateAlerts();
            Assert.IsFalse(alert.Activated);
        }

        [TestMethod]
        public void DontIncreaseAlertCountIfPhraseDateIsOlderThanAnYear()
        {
            Author author = new Author { Username = "username1", Name = "name1", Surname = "surname1", Born = new DateTime(1960, 01, 01) };
            Sentiment sentiment = new Sentiment() { Description = "Me encanta", Category = true };
            Phrase phrase = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddYears(-1), Author = author };
            IAlert alert = new AlertB() { Category = CategoryType.Positiva, Posts = 1, Days = 2 };
            sentimentController.AddSentiment(sentiment);
            phraseController.AddPhrase(phrase);
            phraseController.AnalyzePhrase(phrase);
            alertController.AddAlert(alert);
            alertController.EvaluateAlerts();
            Assert.IsFalse(alert.Activated);
        }



    }
}
