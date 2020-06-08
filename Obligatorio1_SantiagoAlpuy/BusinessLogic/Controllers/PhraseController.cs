using System.Collections.Generic;
using System;
using BusinessLogic.IControllers;

namespace BusinessLogic.Controllers
{
    public class PhraseController : IPhraseController
    {

        IEntityController entityController;
        ISentimentController sentimentController;
        IAlertController alertAController;
        IAlertController alertBController;
        RepositoryA<Phrase> repositoryA;

        private const string NULL_AUTHOR_IN_PHRASE = "Debe elegir un autor para agregar una frase.";
        private const string NULL_PHRASE = "Ingrese una frase válida.";
        private const string EMPTY_PHRASE = "Debe ingresar una frase no vacía.";
        private const string OLD_DATE = "La fecha no debe tener más de un año de antiguedad.";
        private const string FUTURE_DATE = "La fecha no puede ser superior a la fecha actual.";

        public PhraseController()
        {
            repositoryA = new RepositoryA<Phrase>();
            entityController = new EntityController();
            sentimentController = new SentimentController();
            alertAController = new AlertAController();
            alertBController = new AlertBController();
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
            alertAController.EvaluateAlerts();
            alertBController.EvaluateAlerts();
        }

        private void ValidatePhrase(Phrase phrase)
        {
            if (phrase == null)
                throw new NullReferenceException(NULL_PHRASE);
            else if (phrase.Comment == null)
                throw new NullReferenceException(NULL_PHRASE);
            else if (phrase.Comment.Trim() == "")
                throw new ArgumentException(EMPTY_PHRASE);
            else if (phrase.Date.CompareTo(DateTime.Now.AddYears(-1)) < 0)
                throw new ArgumentException(OLD_DATE);
            else if (phrase.Date.CompareTo(DateTime.Now) > 0)
                throw new ArgumentException(FUTURE_DATE);
            else if (phrase.Author == null)
                throw new ArgumentException(NULL_AUTHOR_IN_PHRASE);
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
