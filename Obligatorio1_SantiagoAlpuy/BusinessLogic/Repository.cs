using System;
using System.Linq;
using System.Collections.Generic;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Repository
    {
        public List<Sentiment> PositiveSentiments { get; set; }
        public List<Sentiment> NegativeSentiments { get; set; }
        public List<Entity> Entities { get; set; }
        public List<Phrase> Phrases { get; set; }

        public List<Alert> Alerts { get; set; }

        private static Repository instance = null;

        private Repository()
        {
            PositiveSentiments = new List<Sentiment>();
            NegativeSentiments = new List<Sentiment>();
            Entities = new List<Entity>();
            Phrases = new List<Phrase>();
            Alerts = new List<Alert>();
        }

        public static Repository Instance
        {
            get
            {
                if (instance == null)
                    instance = new Repository();
                return instance;
            }
        }

        public void CleanLists()
        {
            PositiveSentiments.Clear();
            NegativeSentiments.Clear();
            Entities.Clear();
            Phrases.Clear();
            Alerts.Clear();
        }
    }
}