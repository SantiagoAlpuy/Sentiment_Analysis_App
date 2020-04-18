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
        public void RegisterSentiments()
        {
            Sentiment happySentiment = new Sentiment()
            {
                Description = "Me gusta",
                Category = true,
            };
            Sentiment sadSentiment = new Sentiment()
            {
                Description = "Odio",
                Category = false,
            };
            happySentiment.AddSentiment(happySentiment);
            happySentiment.AddSentiment(sadSentiment);
            Assert.AreEqual(happySentiment, happySentiment.ObtainSentiment(happySentiment.Description));
            Assert.AreEqual(sadSentiment, happySentiment.ObtainSentiment(sadSentiment.Description));
        }
    }
}
