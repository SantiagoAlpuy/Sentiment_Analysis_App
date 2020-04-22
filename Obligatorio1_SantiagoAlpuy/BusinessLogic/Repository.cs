using System;
using System.Linq;
using System.Collections.Generic;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Repository
    {
        public List<Sentiment> positiveSentiments { get; set; }
        public List<Sentiment> negativeSentiments { get; set; }
        public List<Entity> entities { get; set; }
        public List<Phrase> phrases { get; set; }

        public List<Alert> alerts { get; set; }

        private static Repository instance = null;

        private Repository()
        {
            positiveSentiments = new List<Sentiment>();
            negativeSentiments = new List<Sentiment>();
            entities = new List<Entity>();
            phrases = new List<Phrase>();
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

        public void cleanLists()
        {
            positiveSentiments.Clear();
            negativeSentiments.Clear();
            entities.Clear();
            phrases.Clear();
        }

        public void AddAlert(Alert positiveAlert)
        {
            throw new NotImplementedException();
        }

        public Alert ObtainAlert(Alert positiveAlert)
        {
            throw new NotImplementedException();
        }
    }
}