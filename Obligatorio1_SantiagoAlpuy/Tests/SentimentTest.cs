using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace Tests
{
    [TestClass]
    public class SentimentTest
    {

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

        [TestMethod]
        public void RegisterPositiveSentiments()
        {
            Repository repository = Repository.Instance;
            repository.AddPositiveSentiment(positiveSentiment1);
            repository.AddPositiveSentiment(positiveSentiment2);
            Assert.AreEqual(positiveSentiment1, repository.ObtainPositiveSentiment(positiveSentiment1.Description));
            Assert.AreEqual(positiveSentiment2, repository.ObtainPositiveSentiment(positiveSentiment2.Description));
            repository.CleanLists();
        }

        [TestMethod]
        public void RegisterNegativeSentiments()
        {
            Repository repository = Repository.Instance;
            repository.AddNegativeSentiment(negativeSentiment1);
            repository.AddNegativeSentiment(negativeSentiment2);
            Assert.AreEqual(negativeSentiment1, repository.ObtainNegativeSentiment(negativeSentiment1.Description));
            Assert.AreEqual(negativeSentiment2, repository.ObtainNegativeSentiment(negativeSentiment2.Description));
            repository.CleanLists();
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentAlreadyExistsException))]
        public void RegisterAlreadyRegisteredPositiveSentiment()
        {
            Repository repository = Repository.Instance;
            repository.AddPositiveSentiment(positiveSentiment1);
            repository.AddPositiveSentiment(positiveSentiment1);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentAlreadyExistsException))]
        public void RegisterAlreadyRegisteredNegativeSentiment()
        {
            Repository repository = Repository.Instance;
            repository.AddNegativeSentiment(negativeSentiment1);
            repository.AddNegativeSentiment(negativeSentiment1);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveExistantPositiveSentimentFromRegister()
        {
            Repository repository = Repository.Instance;
            repository.CleanLists();
            repository.AddPositiveSentiment(positiveSentiment1);
            repository.RemovePositiveSentiment(positiveSentiment1.Description);
            Sentiment sent = repository.ObtainPositiveSentiment(positiveSentiment1.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveNonExistantPositiveSentimentFromRegister()
        {
            Repository repository = Repository.Instance;
            repository.CleanLists();
            repository.RemovePositiveSentiment("sentimiento que no existe");
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveExistantNegativeSentimentFromRegister()
        {
            Repository repository = Repository.Instance;
            repository.CleanLists();
            repository.AddNegativeSentiment(negativeSentiment1);
            repository.RemoveNegativeSentiment(negativeSentiment1.Description);
            Sentiment sent = repository.ObtainNegativeSentiment(negativeSentiment1.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveNonExistantNegativeSentimentFromRegister()
        {
            Repository repository = Repository.Instance;
            repository.CleanLists();
            repository.RemoveNegativeSentiment("sentimiento que no existe");
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterSentimentWithEmptyDescription()
        {
            Repository repository = Repository.Instance;
            repository.AddNegativeSentiment(noDescriptionSentiment);
            repository.AddPositiveSentiment(noDescriptionSentiment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullSentimentException))]
        public void RegisterNullSentiment()
        {
            Repository repository = Repository.Instance;
            repository.AddPositiveSentiment(null);
            repository.AddNegativeSentiment(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ContainsNumbersException))]
        public void RegisterSentimentWithNumbersInItsDescriptionException()
        {
            Repository repository = Repository.Instance;
            repository.AddNegativeSentiment(containsNumberSentiment);
            repository.AddPositiveSentiment(containsNumberSentiment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAttributeInObjectException))]
        public void RegisterSentimentWithNullDescription()
        {
            Repository repository = Repository.Instance;
            repository.AddPositiveSentiment(nullDescriptionSentiment);
            repository.AddNegativeSentiment(nullDescriptionSentiment);
        }

    }
}
