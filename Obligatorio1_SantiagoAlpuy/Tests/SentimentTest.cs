using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Exceptions;
using BusinessLogic.Controllers;

namespace Tests
{
    [TestClass]
    public class SentimentTest
    {
        Repository repository;
        SentimentController sentimentController;
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

            positiveSentiment1 = new Sentiment()
            {
                Description = "Me gusta",
                Category = true,
            };
            positiveSentiment2 = new Sentiment()
            {
                Description = "Me encanta",
                Category = true,
            };

            negativeSentiment1 = new Sentiment()
            {
                Description = "Lo odio",
                Category = false,
            };
            negativeSentiment2 = new Sentiment()
            {
                Description = "Me enfurece",
                Category = false,
            };

            noDescriptionSentiment = new Sentiment()
            {
                Description = "",
            };

            containsNumberSentiment = new Sentiment()
            {
                Description = "1337",
            };

            nullDescriptionSentiment = new Sentiment();
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            repository.cleanLists();
        }

        [TestMethod]
        public void RegisterPositiveSentiments()
        {
            sentimentController.AddSentiment(positiveSentiment1);
            sentimentController.AddSentiment(positiveSentiment2);
            Assert.AreEqual(positiveSentiment1, sentimentController.ObtainSentiment(positiveSentiment1.Description, positiveSentiment1.Category));
            Assert.AreEqual(positiveSentiment2, sentimentController.ObtainSentiment(positiveSentiment2.Description, positiveSentiment1.Category));
        }

        [TestMethod]
        public void RegisterNegativeSentiments()
        {
            sentimentController.AddSentiment(negativeSentiment1);
            sentimentController.AddSentiment(negativeSentiment2);
            Assert.AreEqual(negativeSentiment1, sentimentController.ObtainSentiment(negativeSentiment1.Description, negativeSentiment1.Category));
            Assert.AreEqual(negativeSentiment2, sentimentController.ObtainSentiment(negativeSentiment2.Description, negativeSentiment2.Category));
        }


        [TestMethod]
        [ExpectedException(typeof(SentimentAlreadyExistsException))]
        public void RegisterAlreadyRegisteredNegativeSentiment()
        {
            negativeSentiment1 = new Sentiment() { Description = "No me gusta", Category = false };
            negativeSentiment2 = new Sentiment() { Description = "No me gusta", Category = false };
            sentimentController.AddSentiment(negativeSentiment1);
            sentimentController.AddSentiment(negativeSentiment2);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentAlreadyExistsException))]
        public void RegisterAlreadyRegisteredPositiveSentiment()
        {
            positiveSentiment1 = new Sentiment() { Description = "Me gusta", Category = true };
            positiveSentiment2 = new Sentiment() { Description = "Me gusta", Category = true };
            sentimentController.AddSentiment(positiveSentiment1);
            sentimentController.AddSentiment(positiveSentiment2);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentAlreadyExistsException))]
        public void RegisterAlreadyRegisteredSentimentWithoutSpaceTrim()
        {
            positiveSentiment1 = new Sentiment() { Description = "   Me gusta   ", Category = true };
            positiveSentiment2 = new Sentiment() { Description = "Me gusta", Category = true };
            sentimentController.AddSentiment(positiveSentiment1);
            sentimentController.AddSentiment(positiveSentiment2);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentAlreadyExistsException))]
        public void RegisterAlreadyRegisteredSentimentWithDifferentMayusMinusFormat()
        {
            positiveSentiment1 = new Sentiment() { Description = "ME gUStA", Category = true };
            positiveSentiment2 = new Sentiment() { Description = "Me gusta", Category = true };
            sentimentController.AddSentiment(positiveSentiment1);
            sentimentController.AddSentiment(positiveSentiment2);
        }


        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveExistantPositiveSentimentFromRegister()
        {
            sentimentController.AddSentiment(positiveSentiment1);
            sentimentController.RemoveSentiment(positiveSentiment1.Description, positiveSentiment1.Category);
            Sentiment sent = sentimentController.ObtainSentiment(positiveSentiment1.Description, positiveSentiment1.Category);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveNonExistantPositiveSentimentFromRegister()
        {
            sentimentController.RemoveSentiment("sentimiento que no existe", true);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveExistantNegativeSentimentFromRegister()
        {
            sentimentController.AddSentiment(negativeSentiment1);
            sentimentController.RemoveSentiment(negativeSentiment1.Description, negativeSentiment1.Category);
            Sentiment sent = sentimentController.ObtainSentiment(negativeSentiment1.Description, negativeSentiment1.Category);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveNonExistantNegativeSentimentFromRegister()
        {
            sentimentController.RemoveSentiment("sentimiento que no existe", false);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterSentimentWithEmptyDescription()
        {
            sentimentController.AddSentiment(noDescriptionSentiment);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterSentimentWithManyBlankSpace()
        {
            Sentiment blankSpacedSentiment = new Sentiment() { Description = "  ", Category = true};
            sentimentController.AddSentiment(blankSpacedSentiment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullSentimentException))]
        public void RegisterNullSentiment()
        {
            sentimentController.AddSentiment(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ContainsNumbersException))]
        public void RegisterSentimentWithNumbersInItsDescriptionException()
        {
            sentimentController.AddSentiment(containsNumberSentiment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAttributeInObjectException))]
        public void RegisterSentimentWithNullDescription()
        {
            sentimentController.AddSentiment(nullDescriptionSentiment);
        }

    }
}
