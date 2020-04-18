using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusinessLogic;

namespace Tests
{
    [TestClass]
    public class SentimientoTest
    {
        [TestMethod]
        public void RegisterSentiment()
        {
            Sentiment sentiment = new Sentiment()
            {
                Description = "Me gusta",
                Category = true,
            };
            sentiment.AddSentiment(sentiment);
            Assert.AreEqual(sentiment, sentiment.ObtainSentiment(sentiment.Description));
        }
    }
}
