﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace Tests
{
    [TestClass]
    public class SentimentTest
    {

        Sentiment positiveSentiment1;
        Sentiment positiveSentiment2;
        Sentiment negativeSentiment1;
        Sentiment negativeSentiment2;

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
        }

        [TestMethod]
        public void RegisterPositiveSentiments()
        {
            
            Register register = new Register();
            register.AddPositiveSentiment(positiveSentiment1);
            register.AddPositiveSentiment(positiveSentiment2);
            Assert.AreEqual(positiveSentiment1, register.ObtainPositiveSentiment(positiveSentiment1.Description));
            Assert.AreEqual(positiveSentiment2, register.ObtainPositiveSentiment(positiveSentiment2.Description));
        }

        [TestMethod]
        public void RegisterNegativeSentiments()
        {
            Register register = new Register();
            register.AddNegativeSentiment(negativeSentiment1);
            register.AddNegativeSentiment(negativeSentiment2);
            Assert.AreEqual(negativeSentiment1, register.ObtainNegativeSentiment(negativeSentiment1.Description));
            Assert.AreEqual(negativeSentiment2, register.ObtainNegativeSentiment(negativeSentiment2.Description));
        }
    }
}
