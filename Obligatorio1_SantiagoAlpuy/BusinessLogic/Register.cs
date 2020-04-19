using System;
using System.Collections.Generic;
using Exceptions;

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

        public void CleanLists()
        {
            positiveSentiments.Clear();
            negativeSentiments.Clear();
            entities.Clear();
            phrases.Clear();
        }


        public void AddPositiveSentiment(Sentiment sentiment)
        {
            if (!positiveSentiments.Contains(sentiment))
            {
                positiveSentiments.Add(sentiment);
            }
            else
            {
                throw new SentimentAlreadyExistsException();
            }
            
        }

        public Sentiment ObtainPositiveSentiment(string description)
        {
            Sentiment sentiment = positiveSentiments.Find(x => x.Description == description);
            if (sentiment != null)
            {
                return sentiment;
            }
            else
            {
                throw new SentimentDoesNotExistsException();
            }
        }

        public void RemovePositiveSentiment(string description)
        {
            Sentiment sentiment = positiveSentiments.Find(x => x.Description == description);
            if (sentiment != null)
            {
                positiveSentiments.Remove(sentiment);
            }
            else
            {
                throw new SentimentDoesNotExistsException();
            }
        }

        public void AddNegativeSentiment(Sentiment sentiment)
        {

            if (!negativeSentiments.Contains(sentiment))
            {
                negativeSentiments.Add(sentiment);
            }
            else
            {
                throw new SentimentAlreadyExistsException();
            }
        }

        public Sentiment ObtainNegativeSentiment(string description)
        {
            Sentiment sentiment = negativeSentiments.Find(x => x.Description == description);
            if (sentiment != null)
            {
                return sentiment;
            }
            else
            {
                throw new SentimentDoesNotExistsException();
            }
        }

        public void AddEntity(Entity entity1)
        {
            if (!entities.Contains(entity1))
            {
                entities.Add(entity1);
            }
            else
            {
                throw new EntityAlreadyExistsException();
            }
        }

        public void RemoveNegativeSentiment(string description)
        {
            Sentiment sentiment = negativeSentiments.Find(x => x.Description == description);
            if (sentiment != null)
            {
                negativeSentiments.Remove(sentiment);
            }
            else
            {
                throw new SentimentDoesNotExistsException();
            }
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