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
            get
            {
                if (instance == null)
                    instance = new Repository();
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
                positiveSentiments.Add(sentiment);
            else
                negativeSentiments.Add(sentiment);
        }

        private void validateSentiment(Sentiment sentiment)
        {
            if (sentiment == null)
                throw new NullSentimentException();
            else if (sentiment.Description == null)
                throw new NullAttributeInObjectException();
            else if (sentiment.Description == "")
                throw new LackOfObligatoryParametersException();
            else if (sentiment.Description.Any(letter => char.IsDigit(letter)))
                throw new ContainsNumbersException();
            else if (sentiment.Category && positiveSentiments.Contains(sentiment))
                throw new SentimentAlreadyExistsException();
            else if (!sentiment.Category && negativeSentiments.Contains(sentiment))
                throw new SentimentAlreadyExistsException();
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
            Sentiment sentiment = obtainPositiveSentiment(description);
            positiveSentiments.Remove(sentiment);

        }

        private void removeNegativeSentiment(string description)
        {
            Sentiment sentiment = obtainNegativeSentiment(description);
            negativeSentiments.Remove(sentiment);
        }

        public void addEntity(Entity entity)
        {
            validateEntity(entity);
            entities.Add(entity);
        }

        private void validateEntity(Entity entity)
        {
            if (entity == null)
                throw new NullEntityException();
            else if (entity.Name == null)
                throw new NullAttributeInObjectException();
            else if (entity.Name == "")
                throw new LackOfObligatoryParametersException();
            else if (entities.Contains(entity))
                throw new EntityAlreadyExistsException();
        }

        public Entity obtainEntity(string name)
        {
            Entity entity = entities.Find(x => x.Name == name);
            if (entity != null)
                return entity;
            else
                throw new EntityDoesNotExistsException();
        }

        public void removeEntity(string name)
        {
            entities.Remove(obtainEntity(name));

        }


        public void addPhrase(Phrase phrase)
        {
            validatePhrase(phrase);
            phrases.Add(phrase);
        }

        private void validatePhrase(Phrase phrase)
        {
            if (phrase == null)
                throw new NullPhraseException();
            else if (phrase.Comment == null)
                throw new NullAttributeInObjectException();
            else if (phrase.Comment == "")
                throw new LackOfObligatoryParametersException();
        }

        public Phrase obtainPhrase(string comment, DateTime date)
        {
            return phrases.Find(x => x.Comment == comment && x.Date.Equals(date));
        }

        public void analyzePhrase(Phrase phrase1)
        {
            Entity ent = null;
            foreach(Entity entity in entities)
            {
                if (phrase1.Comment.Contains(entity.Name))
                {
                    ent = entity;
                    break;
                }
            }
            if (ent != null)
                phrase1.Entity = ent.Name;
            else
                phrase1.Entity = "";

            bool hasPositive = false;
            bool hasNegative = false;
            foreach(Sentiment sentiment in positiveSentiments)
            {
                if (phrase1.Comment.Contains(sentiment.Description))
                {
                    hasPositive = true;
                    break;
                }
            }

            foreach (Sentiment sentiment in negativeSentiments)
            {
                if (phrase1.Comment.Contains(sentiment.Description))
                {
                    hasNegative = true;
                    break;
                }
            }
            if (!hasPositive && !hasNegative)
                phrase1.Category = "neutro";
            else if (hasPositive)
                phrase1.Category = "positive";
            else
                phrase1.Category = "negative";

        }
    }
}