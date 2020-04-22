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
            alerts = new List<Alert>();
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
            alerts.Clear();
        }

        public void AddAlert(Alert alert)
        {
            if (alert.Entity == null)
                throw new NullEntityException();
            else if (alert.Posts < 0)
                throw new NegativePostCountException();
            else
                alerts.Add(alert);
        }

        public Alert ObtainAlert(Alert alert)
        {
            return alerts.Find(x => x.Equals(alert));
        }
    }
}