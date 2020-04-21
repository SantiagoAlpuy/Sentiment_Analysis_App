using System;
using System.Linq;
using System.Collections.Generic;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Repository
    {
        private List<Sentiment> positiveSentiments;
        private List<Sentiment> negativeSentiments;
        private List<Entity> entities;
        private List<Phrase> phrases;

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
            get{
                if (instance == null)
                {
                    instance = new Repository();
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

        public void addSentiment(Sentiment sentiment)
        {
            validateSentiment(sentiment);
            addSentimentToRepository(sentiment);
        }

        private void addSentimentToRepository(Sentiment sentiment)
        {
            if (sentiment.Category)
            {
                positiveSentiments.Add(sentiment);
            }
            else
            {
                negativeSentiments.Add(sentiment);
            }
        }

        private void validateSentiment(Sentiment sentiment)
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
            else if (sentiment.Category && positiveSentiments.Contains(sentiment))
            {
                throw new SentimentAlreadyExistsException();
            }
            else if (!sentiment.Category && negativeSentiments.Contains(sentiment))
            {
                throw new SentimentAlreadyExistsException();
            }
        }

        public Sentiment obtainSentiment(string description, bool category)
        {
            Sentiment sentiment = null;
            if (category)
                sentiment = obtainPositiveSentiment(description);
            else
                sentiment = obtainNegativeSentiment(description);
            return sentiment;
        }

        private Sentiment obtainPositiveSentiment(string description)
        {
            Sentiment sentiment = positiveSentiments.Find(x => x.Description == description);
            if (sentiment != null)
                return sentiment;
            else
                throw new SentimentDoesNotExistsException();
        }

        private Sentiment obtainNegativeSentiment(string description)
        {
            Sentiment sentiment = negativeSentiments.Find(x => x.Description == description);
            if (sentiment != null)
                return sentiment;
            else
                throw new SentimentDoesNotExistsException();
        }


        public void removeSentiment(string description, bool category)
        {
            if (category)
                removePositiveSentiment(description);
            else
                removeNegativeSentiment(description);
        }

        private void removePositiveSentiment(string description)
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

        private void removeNegativeSentiment(string description)
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