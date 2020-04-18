using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            sentimentReturned = sentiment.ObtainSentiment(sentiment);
            Assert.AreEqual(sentiment, sentimentReturned);
        }
    }
}
