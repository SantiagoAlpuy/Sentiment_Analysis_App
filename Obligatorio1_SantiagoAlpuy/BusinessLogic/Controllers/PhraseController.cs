using System.Collections.Generic;
using System;
using BusinessLogic.IControllers;
using BusinessLogic.DataAccess;

namespace BusinessLogic.Controllers
{
    public class PhraseController : IPhraseController
    {
        Repository<Phrase> repositoryA;

        private const string NULL_PHRASE = "Ingrese una frase válida.";
        
        public PhraseController()
        {
            repositoryA = new Repository<Phrase>();
        }

        public void AddPhrase(Phrase phrase)
        {
            ValidatePhrase(phrase);
            repositoryA.Add(phrase);
            AnalyzePhrase(phrase);
            AnalyzeAlerts();
        }

        private void AnalyzeAlerts()
        {
            AlertAController alertAController = new AlertAController();
            AlertBController alertBController = new AlertBController();
            alertAController.EvaluateAlerts();
            alertBController.EvaluateAlerts();
        }

        private void ValidatePhrase(Phrase phrase)
        {
            if (phrase == null)
                throw new NullReferenceException(NULL_PHRASE);
            else phrase.Validate();
        }

        public Phrase ObtainPhrase(int phraseId)
        {
            return repositoryA.Find(x => x.PhraseId.Equals(phraseId));
        }

        public void AnalyzeAllPhrases()
        {
            ICollection<Phrase> phrases = repositoryA.GetAll();
            foreach (Phrase phrase in phrases)
            {
                AnalyzePhrase(phrase);
            }
        }

        private void AnalyzePhrase(Phrase phrase)
        {
            bool hasPositive = false;
            bool hasNegative = false;
            SetEntityOnPhrase(phrase);
            hasPositive = IsSentimentOnRepo(phrase, CategoryType.Positiva);
            hasNegative = IsSentimentOnRepo(phrase, CategoryType.Negativa);
            SetPhraseCategory(phrase, hasPositive, hasNegative);
            repositoryA.Update(phrase);
        }

        private void SetPhraseCategory(Phrase phrase, bool hasPositive, bool hasNegative)
        {
            if (!hasPositive && !hasNegative)
                phrase.Category = CategoryType.Neutro;
            else if (hasPositive && hasNegative)
                phrase.Category = CategoryType.Neutro;
            else if (hasPositive)
                phrase.Category = CategoryType.Positiva;
            else
                phrase.Category = CategoryType.Negativa;
        }

        private bool IsSentimentOnRepo(Phrase phrase, CategoryType category)
        {
            SentimentController sentimentController = new SentimentController();
            bool hasSentiment = false;
            ICollection<Sentiment> sentiments = sentimentController.GetAllEntitiesByCategory(category);
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

        private void SetEntityOnPhrase(Phrase phrase)
        {
            try
            {
                Entity ent = FindEntityInPhrase(phrase);
                phrase.Entity = ent.Name;
            }
            catch (NullReferenceException)
            {
                phrase.Entity = "";
            }
        }        

        private Entity FindEntityInPhrase(Phrase phrase)
        {
            EntityController entityController = new EntityController();
            Entity ent = null;
            ICollection<Entity> entities = entityController.GetAllEntities();
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
                throw new NullReferenceException();
        }

        private bool PhraseContainsEntity(Phrase phrase, Entity entity)
        {
            return phrase.Comment.ToUpper().Contains(entity.Name.ToUpper());
        }

        public List<Phrase> GetAllEntities()
        {
            return (List<Phrase>) repositoryA.GetAll();
        }

        public List<Phrase> GetAllEntitiesWithIncludes(string entityToInclude)
        {
            return (List<Phrase>)repositoryA.GetAllWithInclude(entityToInclude);
        }

        public void RemoveAllPhrases()
        {
            repositoryA.ClearAll();
        }

    }
}
