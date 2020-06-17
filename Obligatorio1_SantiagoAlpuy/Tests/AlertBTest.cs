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
        AlertBAuthorRelationController alertBAuthorController;
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
            alertBAuthorController = new AlertBAuthorRelationController();
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
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithZeroPostCount()
        {
            AlertB alert = new AlertB() { Category = CategoryType.Positiva, Posts = 0, Hours = 2 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        public void ActivateAlert()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Phrase phrase = new Phrase { Author = author, Category = CategoryType.Positiva, Comment = "me gusta la pepsi", Date = DateTime.Now, Entity = null};
            AlertB alert = new AlertB() { Category = CategoryType.Negativa, Posts = 1, Hours = 2 };
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);          
            alert.EvaluateAlert();
            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void DontActivateAlertAsThereAreNotEnoughPhrasesFromAnAutor()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Phrase phrase = new Phrase { Author = author, Category = CategoryType.Positiva, Comment = "me gusta la pepsi", Date = DateTime.Now, Entity = null };
            AlertB alert = new AlertB() { Category = CategoryType.Negativa, Posts = 2, Hours = 2 };
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            alert.EvaluateAlert();
            Assert.IsFalse(alert.Activated);
        }


    }
}
