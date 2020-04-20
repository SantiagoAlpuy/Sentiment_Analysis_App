using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using Exceptions;

namespace Tests
{
    [TestClass]
    public class SentimentTest
    {

        Sentiment positiveSentiment1;
        Sentiment positiveSentiment2;
        Sentiment negativeSentiment1;
        Sentiment negativeSentiment2;
        Sentiment emptySentiment;

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

            emptySentiment = new Sentiment();
        }

        [TestMethod]
        public void RegisterPositiveSentiments()
        {
            Register register = Register.Instance;
            register.AddPositiveSentiment(positiveSentiment1);
            register.AddPositiveSentiment(positiveSentiment2);
            Assert.AreEqual(positiveSentiment1, register.ObtainPositiveSentiment(positiveSentiment1.Description));
            Assert.AreEqual(positiveSentiment2, register.ObtainPositiveSentiment(positiveSentiment2.Description));
            register.CleanLists();
        }

        [TestMethod]
        public void RegisterNegativeSentiments()
        {
            Register register = Register.Instance;
            register.AddNegativeSentiment(negativeSentiment1);
            register.AddNegativeSentiment(negativeSentiment2);
            Assert.AreEqual(negativeSentiment1, register.ObtainNegativeSentiment(negativeSentiment1.Description));
            Assert.AreEqual(negativeSentiment2, register.ObtainNegativeSentiment(negativeSentiment2.Description));
            register.CleanLists();
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentAlreadyExistsException))]
        public void RegisterAlreadyRegisteredPositiveSentiment()
        {
            Register register = Register.Instance;
            register.AddPositiveSentiment(positiveSentiment1);
            register.AddPositiveSentiment(positiveSentiment1);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentAlreadyExistsException))]
        public void RegisterAlreadyRegisteredNegativeSentiment()
        {
            Register register = Register.Instance;
            register.AddNegativeSentiment(negativeSentiment1);
            register.AddNegativeSentiment(negativeSentiment1);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveExistantPositiveSentimentFromRegister()
        {
            Register register = Register.Instance;
            register.CleanLists();
            register.AddPositiveSentiment(positiveSentiment1);
            register.RemovePositiveSentiment(positiveSentiment1.Description);
            Sentiment sent = register.ObtainPositiveSentiment(positiveSentiment1.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveNonExistantPositiveSentimentFromRegister()
        {
            Register register = Register.Instance;
            register.CleanLists();
            register.RemovePositiveSentiment("sentimiento que no existe");
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveExistantNegativeSentimentFromRegister()
        {
            Register register = Register.Instance;
            register.CleanLists();
            register.AddNegativeSentiment(negativeSentiment1);
            register.RemoveNegativeSentiment(negativeSentiment1.Description);
            Sentiment sent = register.ObtainNegativeSentiment(negativeSentiment1.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(SentimentDoesNotExistsException))]
        public void RemoveNonExistantNegativeSentimentFromRegister()
        {
            Register register = Register.Instance;
            register.CleanLists();
            register.RemoveNegativeSentiment("sentimiento que no existe");
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterSentimentWithEmptyDescription()
        {
            Register register = Register.Instance;
            register.AddNegativeSentiment(emptySentiment);
            register.AddPositiveSentiment(emptySentiment);
        }

    }
}
