using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Register
    {
        public List<Sentiment> positiveSentiments;
        public List<Sentiment> negativeSentiments;
        public List<Entity> entities;
        public List<Phrase> phrase;

        public Register()
        {
            positiveSentiments = new List<Sentiment>();
            negativeSentiments = new List<Sentiment>();
            entities = new List<Entity>();
            phrase = new List<Phrase>();

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
            this.phrase.Add(phrase);
        }

        public Phrase ObtainPhrase(string comment, DateTime date)
        {
            return phrase.Find(x => x.Comment == comment && x.Date.Equals(date));
        }

    }
}