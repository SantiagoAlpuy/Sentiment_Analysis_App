using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace Tests
{
    [TestClass]
    public class SentimentTest
    {
        [TestMethod]
        public void RegisterSentiments()
        {
            Sentiment sentiment1 = new Sentiment()
            {
                Description = "Me gusta",
                Category = true,
            };
            Sentiment sentiment2 = new Sentiment()
            {
                Description = "Me encanta",
                Category = true,
            };
            Register register = new Register();
            register.AddSentiment(sentiment1);
            register.AddSentiment(sentiment2);
            Assert.AreEqual(sentiment1, register.ObtainSentiment(sentiment1.Description));
            Assert.AreEqual(sentiment2, register.ObtainSentiment(sentiment2.Description));
        }
    }
}
