using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Register
    {
        public List<Sentiment> sentiment;
        public List<Entity> entities;
        public List<Phrase> phrase;

        public Register()
        {
            sentiment = new List<Sentiment>();
            entities = new List<Entity>();
            phrase = new List<Phrase>();

        }

        public void AddSentiment(Sentiment sentimiento)
        {
            sentiment.Add(sentimiento);
        }

        public Sentiment ObtainSentiment(string description)
        {
            return sentiment.Find(x => x.Description == description);
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