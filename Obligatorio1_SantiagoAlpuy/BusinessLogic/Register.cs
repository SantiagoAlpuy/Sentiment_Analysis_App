using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Register
    {
        private List<Sentiment> positiveSentiments;
        private List<Sentiment> negativeSentiments;
        private List<Entity> entities;
        private List<Phrase> phrases;

        private static Register instance = null;

        private Register()
        {
            positiveSentiments = new List<Sentiment>();
            negativeSentiments = new List<Sentiment>();
            entities = new List<Entity>();
            phrases = new List<Phrase>();
        }

        public static Register Instance
        {
            get{
                if (instance == null)
                {
                    instance = new Register();
                }
                return instance;
            }
        }

        public void AddPositiveSentiment(Sentiment sentiment)
        {
            positiveSentiments.Add(sentiment);
        }

        public Sentiment ObtainPositiveSentiment(string description)
        {
            return positiveSentiments.Find(x => x.Description == description);
        }

        public void AddNegativeSentiment(Sentiment sentiment)
        {
            negativeSentiments.Add(sentiment);
        }

        public Sentiment ObtainNegativeSentiment(string description)
        {
            return negativeSentiments.Find(x => x.Description == description);
        }

        public void AddEntity(Entity entity1)
        {
            entities.Add(entity1);
        }

        public Entity ObtainEntity(string name)
        {
            return entities.Find(x => x.Name == name);
        }

        public void AddPhrase(Phrase phrase)
        {
            this.phrases.Add(phrase);
        }

        public Phrase ObtainPhrase(string comment, DateTime date)
        {
            return phrases.Find(x => x.Comment == comment && x.Date.Equals(date));
        }

    }
}