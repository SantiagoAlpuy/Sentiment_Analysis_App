using System.Collections.Generic;
using System;
using System.Linq;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Controllers
{
    public class PhraseController
    {
        Repository repository = Repository.Instance;
        AlertController alertController = new AlertController();
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

        public void AddPhraseToRepository(Phrase phrase)
        {
            ValidatePhrase(phrase);
            phrases.Add(phrase);
        }

        private void ValidatePhrase(Phrase phrase)
        {
            if (phrase == null)
                throw new NullPhraseException();
            else if (phrase.Comment == null)
                throw new NullAttributeInObjectException();
            else if (phrase.Comment.Trim() == "")
                throw new LackOfObligatoryParametersException();
            else if (phrase.Date.CompareTo(DateTime.Now.AddYears(-1)) < 0)
                throw new DateOlderThanOneYearException();
            else if (phrase.Date.CompareTo(DateTime.Now) > 0)
                throw new DateFromFutureException();
        }

        public Phrase ObtainPhrase(string comment, DateTime date)
        {
            return phrases.Find(x => x.Comment == comment && x.Date.Equals(date));
        }

        public void AnalyzePhrase(Phrase phrase)
        {
            bool hasPositive;
            bool hasNegative;
            AnalyzeEntityFromPhrase(phrase);
            hasPositive = IsSentimentOnRepo(phrase, positiveSentiments);
            hasNegative = IsSentimentOnRepo(phrase, negativeSentiments);
            SetPhraseCategory(phrase, hasPositive, hasNegative);
        }

        private void SetPhraseCategory(Phrase phrase, bool hasPositive, bool hasNegative)
        {
            if (!hasPositive && !hasNegative)
                phrase.Category = CategoryType.Neutro;
            else if (hasPositive && hasNegative)
                phrase.Category = CategoryType.Neutro;
            else if (hasPositive)
                phrase.Category = CategoryType.Positive;
            else
                phrase.Category = CategoryType.Negative;
        }

        private bool IsSentimentOnRepo(Phrase phrase, List<Sentiment> sentiments)
        {
            bool hasSentiment = false;
            foreach (Sentiment sentiment in sentiments)
            {
                if (IsSentimentOnPhrase(phrase, sentiment))
                {
                    hasSentiment = true;
                    break;
                }
            }
            return hasSentiment;
        }

        private bool IsSentimentOnPhrase(Phrase phrase, Sentiment sentiment)
        {
            return phrase.Comment.ToUpper().Contains(sentiment.Description.ToUpper());
        }

        private void AnalyzeEntityFromPhrase(Phrase phrase)
        {
            try
            {
                Entity ent = FindEntityInPhrase(phrase);
                phrase.Entity = ent.Name;
            }
            catch (NullEntityException)
            {
                phrase.Entity = "";
            }


        }

        private Entity FindEntityInPhrase(Phrase phrase)
        {
            Entity ent = null;
            foreach (Entity entity in entities)
            {
                if (PhraseContainsEntity(phrase, entity))
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

        private bool PhraseContainsEntity(Phrase phrase, Entity entity)
        {
            return phrase.Comment.ToUpper().Contains(entity.Name.ToUpper());
        }

    }
}
