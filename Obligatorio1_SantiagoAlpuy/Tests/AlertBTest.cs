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
        AlertBAuthorController alertBAuthorController;
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
            alertBAuthorController = new AlertBAuthorController();
        }

        private void ClearDatabase()
        {
            sentimentController.RemoveAllSentiments();
            phraseController.RemoveAllPhrases();
            authorController.RemoveAllAuthors();
            alertController.RemoveAllAlerts();
            alertBAuthorController.RemoveAll();
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
            Sentiment sentiment = new Sentiment { Category = true, Description = "me gusta" };
            Phrase phrase = new Phrase { Author = author, Comment = "me gusta la pepsi", Date = DateTime.Now};
            AlertB alert = new AlertB() { Category = CategoryType.Positiva, Posts = 1, Hours = 2 };
            authorController.AddAuthor(author);
            sentimentController.AddSentiment(sentiment);
            phraseController.AddPhrase(phrase);
            alertController.AddAlert(alert);
            alert.EvaluateAlert();
            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void DontActivateAlertAsThereAreNotEnoughPhrasesFromAnAutor()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Sentiment sentiment = new Sentiment { Category = false, Description = "odio" };
            Phrase phrase = new Phrase { Author = author, Comment = "odio la cocacola", Date = DateTime.Now };
            AlertB alert = new AlertB() { Category = CategoryType.Negativa, Posts = 2, Hours = 2 };
            authorController.AddAuthor(author);
            sentimentController.AddSentiment(sentiment);
            phraseController.AddPhrase(phrase);
            alertController.AddAlert(alert);
            alert.EvaluateAlert();
            Assert.IsFalse(alert.Activated);
        }

        [TestMethod]
        public void DontActivateAlertIfEnoughPostsFromAuthorButNotOfSameCategoryAsAlert()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Sentiment sentiment1 = new Sentiment { Category = true, Description = "me gusta" };
            Sentiment sentiment2 = new Sentiment { Category = false, Description = "odio" };
            Phrase phrase1 = new Phrase { Author = author, Comment = "me gusta la pepsi", Date = DateTime.Now };
            Phrase phrase2 = new Phrase { Author = author, Comment = "odio la cocacola", Date = DateTime.Now };
            AlertB alert = new AlertB() { Category = CategoryType.Negativa, Posts = 2, Hours = 2 };
            authorController.AddAuthor(author);
            sentimentController.AddSentiment(sentiment1);
            sentimentController.AddSentiment(sentiment2);
            phraseController.AddPhrase(phrase1);
            phraseController.AddPhrase(phrase2);
            alertController.AddAlert(alert);
            alert.EvaluateAlert();
            Assert.IsFalse(alert.Activated);
        }

        [TestMethod]
        public void DontActivateAlertIfEnoughPostsFromAuthorButNotOutOfTimeRange()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Sentiment sentiment1 = new Sentiment { Category = true, Description = "me gusta" };
            Sentiment sentiment2 = new Sentiment { Category = true, Description = "me encanta" };
            Phrase phrase1 = new Phrase { Author = author, Comment = "me gusta la pepsi", Date = new DateTime(2019, 12, 12) };
            Phrase phrase2 = new Phrase { Author = author, Comment = "me encanta la cocacola", Date = DateTime.Now };
            AlertB alert = new AlertB() { Category = CategoryType.Positiva, Posts = 2, Hours = 2 };
            authorController.AddAuthor(author);
            sentimentController.AddSentiment(sentiment1);
            sentimentController.AddSentiment(sentiment2);
            phraseController.AddPhrase(phrase1);
            phraseController.AddPhrase(phrase2);
            alertController.AddAlert(alert);
            alert.EvaluateAlert();
            Assert.IsFalse(alert.Activated);
        }

        [TestMethod]
        public void SaveAuthorsThatActivatedTheAlarm()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Sentiment sentiment1 = new Sentiment { Category = true, Description = "me gusta" };
            Sentiment sentiment2 = new Sentiment { Category = true, Description = "me encanta" };
            Phrase phrase1 = new Phrase { Author = author, Comment = "me gusta la pepsi", Date = DateTime.Now };
            Phrase phrase2 = new Phrase { Author = author, Comment = "me encanta la cocacola", Date = DateTime.Now };
            AlertB alert = new AlertB() { Category = CategoryType.Positiva, Posts = 2, Hours = 2 };
            authorController.AddAuthor(author);
            sentimentController.AddSentiment(sentiment1);
            sentimentController.AddSentiment(sentiment2);
            phraseController.AddPhrase(phrase1);
            phraseController.AddPhrase(phrase2);
            alertController.AddAlert(alert);
            alert.EvaluateAlert();
            ICollection<AlertBAuthor> alertAuthors = alertBAuthorController.GetAllRelationsByAlertId(alert.AlertBId);
            Assert.AreEqual(1, alertAuthors.Count);
        }

        [TestMethod]
        public void DeactivateAlarmThatWasPreviouslyActivated()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Sentiment sentiment = new Sentiment { Category = true, Description = "me gusta" };
            Phrase phrase = new Phrase { Author = author, Comment = "me gusta la pepsi", Date = DateTime.Now };
            AlertB alert = new AlertB() { Category = CategoryType.Positiva, Posts = 1, Hours = 2 };
            authorController.AddAuthor(author);
            sentimentController.AddSentiment(sentiment);
            phraseController.AddPhrase(phrase);
            alertController.AddAlert(alert);
            alert.EvaluateAlert();
            phraseController.RemoveAllPhrases();
            alert.EvaluateAlert();
            Assert.IsFalse(alert.Activated);
        }

        [TestMethod]
        public void FinishAssociationBetweenAlertAndAuthorThatNoLongerAreAssociated()
        {
            AlertBAuthorController alertAuthorController = new AlertBAuthorController();
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Sentiment sentiment = new Sentiment { Category = true, Description = "me gusta" };
            Phrase phrase = new Phrase { Author = author, Comment = "me gusta la pepsi", Date = DateTime.Now };
            AlertB alert = new AlertB() { Category = CategoryType.Positiva, Posts = 1, Hours = 2 };
            authorController.AddAuthor(author);
            sentimentController.AddSentiment(sentiment);
            phraseController.AddPhrase(phrase);
            alertController.AddAlert(alert);
            alert.EvaluateAlert();
            alertAuthorController.RemoveAssociationAlertAuthor(alert, author);
            ICollection<AlertBAuthor> alertAuthors = alertBAuthorController.GetAllRelationsByAlertId(alert.AlertBId);
            Assert.AreEqual(0, alertAuthors.Count);
        }

    }
}
