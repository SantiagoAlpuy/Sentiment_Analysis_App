﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class AlertATest
    {
        AlertAController alertController;
        IPhraseController phraseController;
        ISentimentController sentimentController;
        IEntityController entityController;
        IAuthorController authorController;

        [TestInitialize]
        public void Setup()
        {
            InitializeControllers();
            ClearDatabase();
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
            entityController = new EntityController();
            authorController = new AuthorController();
            alertController = new AlertAController();
        }

        private void ClearDatabase()
        {
            sentimentController.RemoveAllSentiments();
            phraseController.RemoveAllPhrases();
            entityController.RemoveAllEntities();
            authorController.RemoveAllAuthors();
            alertController.RemoveAllAlerts();
        }

        [TestMethod]
        public void GenerateAlertToEntity()
        {
            Entity entity = new Entity() { Name = "pepsi" };
            AlertA alert1 = new AlertA() { Entity = entity.Name, Category = CategoryType.Positiva, Posts = 10, Days = 12 };
            alertController.AddAlert(alert1);
            AlertA alert2 = alertController.ObtainAlert(alert1.AlertAId);
            Assert.AreEqual(alert1.AlertAId, alert2.AlertAId);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GenerateAlertWithNullEntity()
        {
            AlertA alert = new AlertA() { Entity = null, Category = CategoryType.Positiva, Posts = 10, Days = 2 };
            alertController.AddAlert(alert);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithNegativePosts()
        {
            Entity entity = new Entity() { Name = "pepsi" };
            AlertA alert = new AlertA() { Entity = entity.Name, Category = CategoryType.Positiva, Posts = -2, Days = 3 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithNegativeDays()
        {
            Entity entity = new Entity() { Name = "pepsi" };
            AlertA alert = new AlertA() { Entity = entity.Name, Category = CategoryType.Positiva, Posts = 2, Days = -34 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithNegativeHours()
        {
            Entity entity = new Entity() { Name = "pepsi" };
            AlertA alert = new AlertA() { Entity = entity.Name, Category = CategoryType.Positiva, Posts = 2, Hours = -2 };
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
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Sentiment sentiment1 = new Sentiment() { Description = "Amo", Category = true };
            Sentiment sentiment2 = new Sentiment() { Description = "Me encanta", Category = true };
            Entity entity = new Entity() { Name = "pepsi" };
            Phrase phrase1 = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            Phrase phrase2 = new Phrase() { Comment = "Amo tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            AlertA alert = new AlertA() { Entity = entity.Name, Category = CategoryType.Positiva, Posts = 2, Days = 2 };

            sentimentController.AddSentiment(sentiment1);
            sentimentController.AddSentiment(sentiment2);            
            entityController.AddEntity(entity);
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase1);
            phraseController.AddPhrase(phrase2);
            alertController.AddAlert(alert);

            alertController.EvaluateAlerts();

            alert = alertController.ObtainAlert(alert.AlertAId);

            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void ActivateAlertOfPhrasesWithEntityWithDifferentLetterFormat()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Entity entity1 = new Entity() { Name = "pepsi" };
            Entity entity2 = new Entity() { Name = "PEpSI" };
            Sentiment sentiment = new Sentiment() { Description = "Me encanta", Category = true };
            Phrase phrase = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            AlertA alert = new AlertA() { Entity = entity1.Name, Category = CategoryType.Positiva, Posts = 1, Days = 2 };

            entityController.AddEntity(entity2);
            sentimentController.AddSentiment(sentiment);
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);

            alertController.AddAlert(alert);

            alertController.EvaluateAlerts();

            alert = alertController.ObtainAlert(alert.AlertAId);

            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void ActivateAlertOfPhrasesWithEntityWithSameNameButBlankSpacesInEdges()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Entity entity1 = new Entity() { Name = "pepsi" };
            Entity entity2 = new Entity() { Name = "  pepsi   " };
            Sentiment sentiment = new Sentiment() { Description = "Me encanta", Category = true };
            Phrase phrase = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            AlertA alert = new AlertA() { Entity = entity2.Name, Category = CategoryType.Positiva, Posts = 1, Days = 2 };

            entityController.AddEntity(entity1);
            sentimentController.AddSentiment(sentiment);
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);

            alertController.AddAlert(alert);

            alertController.EvaluateAlerts();
            alert = alertController.ObtainAlert(alert.AlertAId);

            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void ActivateAlert()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Entity entity = new Entity() { Name = "pepsi" };
            AlertA alert = new AlertA() { Entity = entity.Name, Category = CategoryType.Positiva, Posts = 1, Days = 2 };
            Phrase phrase = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            Sentiment sentiment = new Sentiment() { Description = "Me encanta", Category = true };

            entityController.AddEntity(entity);
            sentimentController.AddSentiment(sentiment);
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);

            alertController.AddAlert(alert);

            alertController.EvaluateAlerts();

            alert = alertController.ObtainAlert(alert.AlertAId);
            
            Assert.IsTrue(alert.Activated);
        }

        [TestMethod]
        public void DeactivateAlert()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Entity entity = new Entity() { Name = "pepsi" };
            Sentiment sentiment = new Sentiment() { Description = "Me encanta", Category = true };
            Phrase phrase = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now.AddDays(-1), Author = author };
            AlertA alert = new AlertA() { Entity = entity.Name, Category = CategoryType.Positiva, Posts = 1, Days = 2 };

            entityController.AddEntity(entity);
            sentimentController.AddSentiment(sentiment);
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);            

            alertController.AddAlert(alert);
            alertController.EvaluateAlerts();

            entityController.RemoveEntity(entity.Name);

            phraseController.AnalyzeAllPhrases();

            alertController.EvaluateAlerts();

            alert = alertController.ObtainAlert(alert.AlertAId);

            Assert.IsFalse(alert.Activated);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithEmptyEntityField()
        {
            Entity entity = new Entity() { Name = "" };
            AlertA alert = new AlertA() { Entity = entity.Name, Category = CategoryType.Positiva, Posts = 2, Hours = 2 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithMultipleBlankSpacesInEntityField()
        {
            Entity entity = new Entity() { Name = "    " };
            AlertA alert = new AlertA() { Entity = entity.Name, Category = CategoryType.Positiva, Posts = 2, Hours = 2 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithNeutroCategory()
        {
            Entity entity = new Entity() { Name = "pepsi" };
            AlertA alert = new AlertA() { Entity = entity.Name, Category = CategoryType.Neutro, Posts = 2, Hours = 2 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateAlertWithZeroPostCount()
        {
            Entity entity = new Entity() { Name = "pepsi" };
            AlertA alert = new AlertA() { Entity = entity.Name, Category = CategoryType.Positiva, Posts = 0, Hours = 2 };
            alertController.AddAlert(alert);
        }

        [TestMethod]
        public void GetAllTheActivatedAlerts()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Entity entity1 = new Entity() { Name = "pepsi" };
            Entity entity2 = new Entity() { Name = "cocacola" };
            Entity entity3 = new Entity() { Name = "fanta" };
            AlertA alert1 = new AlertA() { Entity = entity1.Name, Category = CategoryType.Positiva, Posts = 1, Days = 12 };
            AlertA alert2 = new AlertA() { Entity = entity2.Name, Category = CategoryType.Positiva, Posts = 1, Days = 12 };
            AlertA alert3 = new AlertA() { Entity = entity3.Name, Category = CategoryType.Positiva, Posts = 1, Days = 12 };
            Sentiment sentiment = new Sentiment() { Description = "Me encanta", Category = true };
            Phrase phrase1 = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now, Author = author };
            Phrase phrase2 = new Phrase() { Comment = "Me encanta tomar cocacola", Date = DateTime.Now, Author = author };
            authorController.AddAuthor(author);
            entityController.AddEntity(entity1);
            entityController.AddEntity(entity2);
            entityController.AddEntity(entity3);
            sentimentController.AddSentiment(sentiment);
            phraseController.AddPhrase(phrase1);
            phraseController.AddPhrase(phrase2);
            alertController.AddAlert(alert1);
            alertController.AddAlert(alert2);
            alertController.AddAlert(alert3);
            alertController.EvaluateAlerts();
            ICollection<AlertA> alerts = alertController.GetActivatedAlerts();
            Assert.AreEqual(2, alerts.Count);
        }

        [TestMethod]
        public void GetAllTheAlerts()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Entity entity1 = new Entity() { Name = "pepsi" };
            Entity entity2 = new Entity() { Name = "cocacola" };
            Entity entity3 = new Entity() { Name = "fanta" };
            AlertA alert1 = new AlertA() { Entity = entity1.Name, Category = CategoryType.Positiva, Posts = 1, Days = 12 };
            AlertA alert2 = new AlertA() { Entity = entity2.Name, Category = CategoryType.Positiva, Posts = 1, Days = 12 };
            AlertA alert3 = new AlertA() { Entity = entity3.Name, Category = CategoryType.Positiva, Posts = 1, Days = 12 };
            Sentiment sentiment = new Sentiment() { Description = "Me encanta", Category = true };
            Phrase phrase1 = new Phrase() { Comment = "Me encanta tomar pepsi", Date = DateTime.Now, Author = author };
            Phrase phrase2 = new Phrase() { Comment = "Me encanta tomar cocacola", Date = DateTime.Now, Author = author };
            authorController.AddAuthor(author);
            entityController.AddEntity(entity1);
            entityController.AddEntity(entity2);
            entityController.AddEntity(entity3);
            sentimentController.AddSentiment(sentiment);
            phraseController.AddPhrase(phrase1);
            phraseController.AddPhrase(phrase2);
            alertController.AddAlert(alert1);
            alertController.AddAlert(alert2);
            alertController.AddAlert(alert3);
            alertController.EvaluateAlerts();
            ICollection<AlertA> alerts = alertController.GetAllAlerts();
            Assert.AreEqual(3, alerts.Count);
        }
    }
}
