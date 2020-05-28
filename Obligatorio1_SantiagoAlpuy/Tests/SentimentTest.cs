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
        Repository repository;
        ISentimentController sentimentController;
        Sentiment positiveSentiment1;
        Sentiment positiveSentiment2;
        Sentiment negativeSentiment1;
        Sentiment negativeSentiment2;
        Sentiment noDescriptionSentiment;
        Sentiment containsNumberSentiment;
        Sentiment nullDescriptionSentiment;

        [TestInitialize]
        public void Setup()
        {
            repository = Repository.Instance;
            sentimentController = new SentimentController();
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            repository.CleanLists();
        }

        [TestMethod]
        public void RegisterPositiveSentiments()
        {
            positiveSentiment1 = new Sentiment() { Description = "Me gusta", Category = true };
            positiveSentiment2 = new Sentiment() { Description = "Me encanta", Category = true };
            sentimentController.AddSentiment(positiveSentiment1);
            sentimentController.AddSentiment(positiveSentiment2);
            Assert.AreEqual(positiveSentiment1, sentimentController.ObtainSentiment(positiveSentiment1.Description, positiveSentiment1.Category));
            Assert.AreEqual(positiveSentiment2, sentimentController.ObtainSentiment(positiveSentiment2.Description, positiveSentiment1.Category));
        }

        [TestMethod]
        public void RegisterNegativeSentiments()
        {
            negativeSentiment1 = new Sentiment() { Description = "Lo odio", Category = false };
            negativeSentiment2 = new Sentiment() { Description = "Me enfurece", Category = false };
            sentimentController.AddSentiment(negativeSentiment1);
            sentimentController.AddSentiment(negativeSentiment2);
            Assert.AreEqual(negativeSentiment1, sentimentController.ObtainSentiment(negativeSentiment1.Description, negativeSentiment1.Category));
            Assert.AreEqual(negativeSentiment2, sentimentController.ObtainSentiment(negativeSentiment2.Description, negativeSentiment2.Category));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterPositiveSentimentThatWasAlreadyRegisteredAsNegative()
        {
            negativeSentiment1 = new Sentiment() { Description = "Lo Odio", Category = false };
            positiveSentiment1 = new Sentiment() { Description = "Lo Odio", Category = true };
            sentimentController.AddSentiment(negativeSentiment1);
            sentimentController.AddSentiment(positiveSentiment1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterNegativeSentimentThatWasAlreadyRegisteredAsPositive()
        {
            negativeSentiment1 = new Sentiment() { Description = "Lo Odio", Category = false };
            positiveSentiment1 = new Sentiment() { Description = "Lo Odio", Category = true };
            sentimentController.AddSentiment(positiveSentiment1);
            sentimentController.AddSentiment(negativeSentiment1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterAlreadyRegisteredNegativeSentiment()
        {
            negativeSentiment1 = new Sentiment() { Description = "No me gusta", Category = false };
            negativeSentiment2 = new Sentiment() { Description = "No me gusta", Category = false };
            sentimentController.AddSentiment(negativeSentiment1);
            sentimentController.AddSentiment(negativeSentiment2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterAlreadyRegisteredPositiveSentiment()
        {
            positiveSentiment1 = new Sentiment() { Description = "Me gusta", Category = true };
            positiveSentiment2 = new Sentiment() { Description = "Me gusta", Category = true };
            sentimentController.AddSentiment(positiveSentiment1);
            sentimentController.AddSentiment(positiveSentiment2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterAlreadyRegisteredSentimentWithoutSpaceTrim()
        {
            positiveSentiment1 = new Sentiment() { Description = "   Me gusta   ", Category = true };
            positiveSentiment2 = new Sentiment() { Description = "Me gusta", Category = true };
            sentimentController.AddSentiment(positiveSentiment1);
            sentimentController.AddSentiment(positiveSentiment2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterAlreadyRegisteredSentimentWithDifferentMayusMinusFormat()
        {
            positiveSentiment1 = new Sentiment() { Description = "ME gUStA", Category = true };
            positiveSentiment2 = new Sentiment() { Description = "Me gusta", Category = true };
            sentimentController.AddSentiment(positiveSentiment1);
            sentimentController.AddSentiment(positiveSentiment2);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RemoveExistantPositiveSentimentFromRegister()
        {
            positiveSentiment1 = new Sentiment() { Description = "Me gusta", Category = true };
            sentimentController.AddSentiment(positiveSentiment1);
            sentimentController.RemoveSentiment(positiveSentiment1.Description, positiveSentiment1.Category);
            Sentiment sent = sentimentController.ObtainSentiment(positiveSentiment1.Description, positiveSentiment1.Category);
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
            negativeSentiment1 = new Sentiment() { Description = "Lo odio", Category = false };
            sentimentController.AddSentiment(negativeSentiment1);
            sentimentController.RemoveSentiment(negativeSentiment1.Description, negativeSentiment1.Category);
            Sentiment sent = sentimentController.ObtainSentiment(negativeSentiment1.Description, negativeSentiment1.Category);
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
            noDescriptionSentiment = new Sentiment() { Description = "" };
            sentimentController.AddSentiment(noDescriptionSentiment);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterSentimentWithManyBlankSpace()
        {

            Sentiment blankSpacedSentiment = new Sentiment() { Description = "  ", Category = true};
            sentimentController.AddSentiment(blankSpacedSentiment);
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
            containsNumberSentiment = new Sentiment() { Description = "1337" };
            sentimentController.AddSentiment(containsNumberSentiment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RegisterSentimentWithNullDescription()
        {
            nullDescriptionSentiment = new Sentiment();
            sentimentController.AddSentiment(nullDescriptionSentiment);
        }

    }
}
