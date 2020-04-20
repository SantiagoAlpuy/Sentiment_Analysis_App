using System;
using System.Linq;
using System.Collections.Generic;
using BusinessLogic.Exceptions;

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
            if (sentiment == null)
            {
                throw new NullSentimentException();
            }
            else if (sentiment.Description == null)
            {
                throw new NullAttributeInObjectException();
            }
            else if (sentiment.Description == "")
            {
                throw new LackOfObligatoryParametersException();
            }
            else if (!positiveSentiments.Contains(sentiment))
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
            if (sentiment == null)
            {
                throw new NullSentimentException();
            }
            else if (sentiment.Description == null)
            {
                throw new NullAttributeInObjectException();
            }
            else if (sentiment.Description == "")
            {
                throw new LackOfObligatoryParametersException();
            }
            else if (sentiment.Description.Any(letter => char.IsDigit(letter)))
            {
                throw new ContainsNumbersException();
            }
            else if (!negativeSentiments.Contains(sentiment))
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

        public void AddEntity(Entity entity1)
        {
            if (entity1 == null)
            {
                throw new NullEntityException();
            }
            else if (entity1.Name == null)
            {
                throw new NullAttributeInObjectException();
            }
            else if(entity1.Name == "")
            {
                throw new LackOfObligatoryParametersException();
            }
            else if (!entities.Contains(entity1))
            {
                entities.Add(entity1);
            }
            else
            {
                throw new EntityAlreadyExistsException();
            }
        }

        public Entity ObtainEntity(string name)
        {
            Entity ent = entities.Find(x => x.Name == name);
            if (ent != null)
            {
                return ent;
            }
            else
            {
                throw new EntityDoesNotExistsException();
            }
        }

        public void RemoveEntity(string name)
        {
            Entity ent = entities.Find(x => x.Name == name);
            if (ent != null)
            {
                entities.Remove(ent);
            }
            else
            {
                throw new EntityDoesNotExistsException();
            }
            
            
        }

        public void AddPhrase(Phrase phrase)
        {
            if (phrase == null)
            {
                throw new NullPhraseException();
            }
            else if (phrase.Comment == null)
            {
                throw new NullAttributeInObjectException();
            }
            else if (phrase.Comment == "")
            {
                throw new LackOfObligatoryParametersException();
            }
            else
            {
                this.phrases.Add(phrase);
            }
        }

        public Phrase ObtainPhrase(string comment, DateTime date)
        {
            return phrases.Find(x => x.Comment == comment && x.Date.Equals(date));
        }
    }
}