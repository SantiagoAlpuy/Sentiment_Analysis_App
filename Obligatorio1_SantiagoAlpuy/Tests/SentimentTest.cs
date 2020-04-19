using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace Tests
{
    [TestClass]
    public class SentimentTest
    {
        [TestMethod]
        public void RegisterPositiveSentiments()
        {
            Sentiment positiveSentiment1 = new Sentiment()
            {
                Description = "Me gusta",
                Category = true,
            };
            Sentiment positiveSentiment2 = new Sentiment()
            {
                Description = "Me encanta",
                Category = true,
            };
            Register register = new Register();
            register.AddPositiveSentiment(positiveSentiment1);
            register.AddPositiveSentiment(positiveSentiment2);
            Assert.AreEqual(positiveSentiment1, register.ObtainSentiment(positiveSentiment1.Description));
            Assert.AreEqual(positiveSentiment2, register.ObtainSentiment(positiveSentiment2.Description));
        }

        [TestMethod]
        public void RegisterNegativeSentiments()
        {
            Sentiment negativeSentiment1 = new Sentiment()
            {
                Description = "Me gusta",
                Category = true,
            };
            Sentiment negativeSentiment2 = new Sentiment()
            {
                Description = "Me encanta",
                Category = true,
            };
            Register register = new Register();
            register.AddNegativeSentiment(negativeSentiment1);
            register.AddNegativeSentiment(negativeSentiment2);
            Assert.AreEqual(negativeSentiment1, register.ObtainSentiment(negativeSentiment1.Description));
            Assert.AreEqual(negativeSentiment2, register.ObtainSentiment(negativeSentiment2.Description));
        }
    }
}
