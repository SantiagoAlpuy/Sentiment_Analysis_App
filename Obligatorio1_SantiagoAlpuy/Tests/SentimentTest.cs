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
            sentimentController.addSentiment(positiveSentiment1);
            sentimentController.addSentiment(positiveSentiment2);
            Assert.AreEqual(positiveSentiment1, sentimentController.obtainSentiment(positiveSentiment1.Description, positiveSentiment1.Category));
            Assert.AreEqual(positiveSentiment2, sentimentController.obtainSentiment(positiveSentiment2.Description, positiveSentiment1.Category));
        }

        [TestMethod]
        public void RegisterNegativeSentiments()
        {
            sentimentController.addSentiment(negativeSentiment1);
            sentimentController.addSentiment(negativeSentiment2);
            Assert.AreEqual(negativeSentiment1, sentimentController.obtainSentiment(negativeSentiment1.Description, negativeSentiment1.Category));
            Assert.AreEqual(negativeSentiment2, sentimentController.obtainSentiment(negativeSentiment2.Description, negativeSentiment2.Category));
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentAlreadyExistsException))]
        public void RegisterAlreadyRegisteredPositiveSentiment()
        {
            sentimentController.addSentiment(positiveSentiment1);
            sentimentController.addSentiment(positiveSentiment1);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentAlreadyExistsException))]
        public void RegisterAlreadyRegisteredNegativeSentiment()
        {
            sentimentController.addSentiment(negativeSentiment1);
            sentimentController.addSentiment(negativeSentiment1);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveExistantPositiveSentimentFromRegister()
        {
            sentimentController.addSentiment(positiveSentiment1);
            sentimentController.removeSentiment(positiveSentiment1.Description, positiveSentiment1.Category);
            Sentiment sent = sentimentController.obtainSentiment(positiveSentiment1.Description, positiveSentiment1.Category);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveNonExistantPositiveSentimentFromRegister()
        {
            sentimentController.removeSentiment("sentimiento que no existe", true);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveExistantNegativeSentimentFromRegister()
        {
            sentimentController.addSentiment(negativeSentiment1);
            sentimentController.removeSentiment(negativeSentiment1.Description, negativeSentiment1.Category);
            Sentiment sent = sentimentController.obtainSentiment(negativeSentiment1.Description, negativeSentiment1.Category);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveNonExistantNegativeSentimentFromRegister()
        {
            sentimentController.removeSentiment("sentimiento que no existe", false);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterSentimentWithEmptyDescription()
        {
            sentimentController.addSentiment(noDescriptionSentiment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullSentimentException))]
        public void RegisterNullSentiment()
        {
            sentimentController.addSentiment(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ContainsNumbersException))]
        public void RegisterSentimentWithNumbersInItsDescriptionException()
        {
            sentimentController.addSentiment(containsNumberSentiment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAttributeInObjectException))]
        public void RegisterSentimentWithNullDescription()
        {
            sentimentController.addSentiment(nullDescriptionSentiment);
        }

    }
}
