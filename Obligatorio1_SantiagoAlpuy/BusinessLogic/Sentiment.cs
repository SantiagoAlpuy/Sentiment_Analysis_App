using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Sentiment
    {
        public string Description { get; set; }
        public bool Category { get; set; }

        public List<Sentiment> sentiment;

        public Sentiment()
        {
            sentiment = new List<Sentiment>();
        }

        public void AddSentiment(Sentiment sentimiento)
        {
            sentiment.Add(sentimiento);
        }

        public Sentiment ObtainSentiment(string description)
        {
            return sentiment.Find(x => x.Description == description);
        }
    }
}