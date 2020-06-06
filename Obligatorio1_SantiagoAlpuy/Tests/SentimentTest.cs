using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;
using System;

namespace Tests
{
    [TestClass]
    public class SentimentTest
    {

        ISentimentController sentimentController;

        [TestInitialize]
        public void Setup()
        {
            sentimentController = new SentimentController();
            sentimentController.RemoveAllSentiments();
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            sentimentController.RemoveAllSentiments();
        }

        [TestMethod]
        public void RegisterPositiveSentiments()
        {
            Sentiment sentiment1 = new Sentiment() { Description = "Me gusta", Category = true };
            Sentiment sentiment2 = new Sentiment() { Description = "Me encanta", Category = true };
            sentimentController.AddSentiment(sentiment1);
            sentimentController.AddSentiment(sentiment2);
            Sentiment sentiment3 = sentimentController.ObtainSentiment(sentiment1.Description, sentiment1.Category);
            Sentiment sentiment4 = sentimentController.ObtainSentiment(sentiment2.Description, sentiment2.Category);
            Assert.AreEqual(sentiment1.SentimentId, sentiment3.SentimentId);
            Assert.AreEqual(sentiment2.SentimentId, sentiment4.SentimentId);
        }

        [TestMethod]
        public void RegisterNegativeSentiments()
        {
            Sentiment sentiment1 = new Sentiment() { Description = "Lo odio", Category = false };
            Sentiment sentiment2 = new Sentiment() { Description = "Me enfurece", Category = false };
            sentimentController.AddSentiment(sentiment1);
            sentimentController.AddSentiment(sentiment2);
            Sentiment sentiment3 = sentimentController.ObtainSentiment(sentiment1.Description, sentiment1.Category);
            Sentiment sentiment4 = sentimentController.ObtainSentiment(sentiment2.Description, sentiment2.Category);
            Assert.AreEqual(sentiment1.SentimentId, sentiment3.SentimentId);
            Assert.AreEqual(sentiment2.SentimentId, sentiment4.SentimentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterPositiveSentimentThatWasAlreadyRegisteredAsNegative()
        {
            Sentiment sentiment1 = new Sentiment() { Description = "Lo Odio", Category = false };
            Sentiment sentiment2 = new Sentiment() { Description = "Lo Odio", Category = true };
            sentimentController.AddSentiment(sentiment1);
            sentimentController.AddSentiment(sentiment2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterNegativeSentimentThatWasAlreadyRegisteredAsPositive()
        {
            Sentiment sentiment1 = new Sentiment() { Description = "Lo Odio", Category = true };
            Sentiment sentiment2 = new Sentiment() { Description = "Lo Odio", Category = false };
            sentimentController.AddSentiment(sentiment1);
            sentimentController.AddSentiment(sentiment2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterAlreadyRegisteredNegativeSentiment()
        {
            Sentiment sentiment1 = new Sentiment() { Description = "No me gusta", Category = false };
            Sentiment sentiment2 = new Sentiment() { Description = "No me gusta", Category = false };
            sentimentController.AddSentiment(sentiment1);
            sentimentController.AddSentiment(sentiment2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterAlreadyRegisteredPositiveSentiment()
        {
            Sentiment sentiment1 = new Sentiment() { Description = "Me gusta", Category = true };
            Sentiment sentiment2 = new Sentiment() { Description = "Me gusta", Category = true };
            sentimentController.AddSentiment(sentiment1);
            sentimentController.AddSentiment(sentiment2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterAlreadyRegisteredSentimentWithoutSpaceTrim()
        {
            Sentiment sentiment1 = new Sentiment() { Description = "   Me gusta   ", Category = true };
            Sentiment sentiment2 = new Sentiment() { Description = "Me gusta", Category = true };
            sentimentController.AddSentiment(sentiment1);
            sentimentController.AddSentiment(sentiment2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterAlreadyRegisteredSentimentWithDifferentMayusMinusFormat()
        {
            Sentiment sentiment1 = new Sentiment() { Description = "ME gUStA", Category = true };
            Sentiment sentiment2 = new Sentiment() { Description = "Me gusta", Category = true };
            sentimentController.AddSentiment(sentiment1);
            sentimentController.AddSentiment(sentiment2);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RemoveExistantPositiveSentimentFromRegister()
        {
            Sentiment sentiment = new Sentiment() { Description = "Me gusta", Category = true };
            sentimentController.AddSentiment(sentiment);
            sentimentController.RemoveSentiment(sentiment.Description, sentiment.Category);
            Sentiment sent = sentimentController.ObtainSentiment(sentiment.Description, sentiment.Category);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RemoveNonExistantPositiveSentimentFromRegister()
        {
            sentimentController.RemoveSentiment("sentimiento que no existe", true);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RemoveExistantNegativeSentimentFromRegister()
        {
            Sentiment sentiment = new Sentiment() { Description = "Lo odio", Category = false };
            sentimentController.AddSentiment(sentiment);
            sentimentController.RemoveSentiment(sentiment.Description, sentiment.Category);
            Sentiment sent = sentimentController.ObtainSentiment(sentiment.Description, sentiment.Category);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RemoveNonExistantNegativeSentimentFromRegister()
        {
            sentimentController.RemoveSentiment("sentimiento que no existe", false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterSentimentWithEmptyDescription()
        {
            Sentiment sentiment = new Sentiment() { Description = "" };
            sentimentController.AddSentiment(sentiment);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterSentimentWithManyBlankSpace()
        {

            Sentiment sentiment = new Sentiment() { Description = "  ", Category = true};
            sentimentController.AddSentiment(sentiment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RegisterNullSentiment()
        {
            sentimentController.AddSentiment(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterSentimentWithNumbersInItsDescriptionException()
        {
            Sentiment sentiment = new Sentiment() { Description = "1337" };
            sentimentController.AddSentiment(sentiment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RegisterSentimentWithNullDescription()
        {
            Sentiment sentiment = new Sentiment();
            sentimentController.AddSentiment(sentiment);
        }

    }
}
