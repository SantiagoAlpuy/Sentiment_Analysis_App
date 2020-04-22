using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace Tests
{
    [TestClass]
    public class SentimentTest
    {
        Repository repository;
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
            repository.CleanLists();
        }

        [TestMethod]
        public void RegisterPositiveSentiments()
        {
            repository.addSentiment(positiveSentiment1);
            repository.addSentiment(positiveSentiment2);
            Assert.AreEqual(positiveSentiment1, repository.obtainSentiment(positiveSentiment1.Description, positiveSentiment1.Category));
            Assert.AreEqual(positiveSentiment2, repository.obtainSentiment(positiveSentiment2.Description, positiveSentiment1.Category));
        }

        [TestMethod]
        public void RegisterNegativeSentiments()
        {
            repository.addSentiment(negativeSentiment1);
            repository.addSentiment(negativeSentiment2);
            Assert.AreEqual(negativeSentiment1, repository.obtainSentiment(negativeSentiment1.Description, negativeSentiment1.Category));
            Assert.AreEqual(negativeSentiment2, repository.obtainSentiment(negativeSentiment2.Description, negativeSentiment2.Category));
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentAlreadyExistsException))]
        public void RegisterAlreadyRegisteredPositiveSentiment()
        {
            repository.addSentiment(positiveSentiment1);
            repository.addSentiment(positiveSentiment1);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentAlreadyExistsException))]
        public void RegisterAlreadyRegisteredNegativeSentiment()
        {
            repository.addSentiment(negativeSentiment1);
            repository.addSentiment(negativeSentiment1);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveExistantPositiveSentimentFromRegister()
        {
            repository.addSentiment(positiveSentiment1);
            repository.removeSentiment(positiveSentiment1.Description, positiveSentiment1.Category);
            Sentiment sent = repository.obtainSentiment(positiveSentiment1.Description, positiveSentiment1.Category);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveNonExistantPositiveSentimentFromRegister()
        {
            repository.removeSentiment("sentimiento que no existe", true);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveExistantNegativeSentimentFromRegister()
        {
            repository.addSentiment(negativeSentiment1);
            repository.removeSentiment(negativeSentiment1.Description, negativeSentiment1.Category);
            Sentiment sent = repository.obtainSentiment(negativeSentiment1.Description, negativeSentiment1.Category);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveNonExistantNegativeSentimentFromRegister()
        {
            repository.removeSentiment("sentimiento que no existe", false);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterSentimentWithEmptyDescription()
        {
            repository.addSentiment(noDescriptionSentiment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullSentimentException))]
        public void RegisterNullSentiment()
        {
            repository.addSentiment(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ContainsNumbersException))]
        public void RegisterSentimentWithNumbersInItsDescriptionException()
        {
            repository.addSentiment(containsNumberSentiment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAttributeInObjectException))]
        public void RegisterSentimentWithNullDescription()
        {
            repository.addSentiment(nullDescriptionSentiment);
        }

    }
}
