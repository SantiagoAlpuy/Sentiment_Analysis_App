﻿using System.Collections.Generic;
using System;
using System.Linq;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Controllers
{
    public class PhraseController
    {
        Repository repository = Repository.Instance;
        private List<Phrase> phrases;
        private List<Sentiment> positiveSentiments;
        private List<Sentiment> negativeSentiments;
        private List<Entity> entities;

        public PhraseController()
        {
            phrases = repository.phrases;
            positiveSentiments = repository.positiveSentiments;
            negativeSentiments = repository.negativeSentiments;
            entities = repository.entities;
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
            else if (phrase.Date.CompareTo(DateTime.Now.AddYears(-1)) < 0)
                throw new DateOlderThanOneYearException();
            else if (phrase.Date.CompareTo(DateTime.Now) > 0)
                throw new DateFromFutureException();
        }

        public Phrase obtainPhrase(string comment, DateTime date)
        {
            return phrases.Find(x => x.Comment == comment && x.Date.Equals(date));
        }

        public void analyzePhrase(Phrase phrase)
        {
            bool hasPositive;
            bool hasNegative;
            analyzeEntityFromPhrase(phrase);
            hasPositive = findPositiveSentiment(phrase);
            hasNegative = findNegativeSentiment(phrase);
            setPhraseCategory(phrase, hasPositive, hasNegative);
        }

        private void setPhraseCategory(Phrase phrase, bool hasPositive, bool hasNegative)
        {
            if (!hasPositive && !hasNegative)
                phrase.Category = "neutro";
            else if (hasPositive && hasNegative)
                phrase.Category = "neutro";
            else if (hasPositive)
                phrase.Category = "positive";
            else
                phrase.Category = "negative";
        }

        private bool findPositiveSentiment(Phrase phrase)
        {
            bool hasPositive = false;
            foreach (Sentiment sentiment in positiveSentiments)
            {
                if (phrase.Comment.ToUpper().Contains(sentiment.Description.ToUpper()))
                {
                    hasPositive = true;
                    break;
                }
            }
            return hasPositive;
        }

        private bool findNegativeSentiment(Phrase phrase)
        {
            bool hasNegative = false;
            foreach (Sentiment sentiment in negativeSentiments)
            {
                if (phrase.Comment.ToUpper().Contains(sentiment.Description.ToUpper()))
                {
                    hasNegative = true;
                    break;
                }
            }
            return hasNegative;
        }

        private void analyzeEntityFromPhrase(Phrase phrase)
        {
            try
            {
                Entity ent = findEntityInPhrase(phrase);
                phrase.Entity = ent.Name;
            }
            catch (NullEntityException)
            {
                phrase.Entity = "";
            }


        }

        private Entity findEntityInPhrase(Phrase phrase)
        {
            Entity ent = null;
            foreach (Entity entity in entities)
            {
                if (phrase.Comment.ToUpper().Contains(entity.Name.ToUpper()))
                {
                    ent = entity;
                    break;
                }
            }
            if (ent != null)
                return ent;
            else
                throw new NullEntityException();
        }

    }
}
