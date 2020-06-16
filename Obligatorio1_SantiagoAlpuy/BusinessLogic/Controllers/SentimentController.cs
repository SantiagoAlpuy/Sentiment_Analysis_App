using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DataAccess;
using BusinessLogic.IControllers;

namespace BusinessLogic.Controllers
{
    public class SentimentController : ISentimentController
    {

        private RepositoryA<Sentiment> repositoryA;

        private const string NULL_SENTIMENT = "Ingrese un sentimiento válido";
        
        public SentimentController()
        {
            repositoryA = new RepositoryA<Sentiment>();
        }

        public void AddSentiment(Sentiment sentiment)
        {
            ValidateSentiment(sentiment);
            repositoryA.Add(sentiment);
            AnalyzePhrases();
            AnalyzeAlerts();
        }

        private void ValidateSentiment(Sentiment sentiment)
        {
            if (sentiment == null)
                throw new NullReferenceException(NULL_SENTIMENT);
            else sentiment.Validate();
        }
        

        public Sentiment ObtainSentiment(string description, bool category)
        {
            Sentiment sentiment = repositoryA.Find(x => x.Description.Trim().ToLower() == description.Trim().ToLower() 
                                    && x.Category == category);
            if (sentiment != null)
                return sentiment;
            else
                throw new NullReferenceException("");
        }

        public void RemoveSentiment(string description, bool category)
        {
            Sentiment sentiment = ObtainSentiment(description, category);
            if (sentiment != null)
            {
                repositoryA.Remove(sentiment);
                AnalyzePhrases();
                AnalyzeAlerts();
            }
        }

        public void RemoveAllSentiments()
        {
            repositoryA.ClearAll();
        }

        private void AnalyzePhrases()
        {
            IPhraseController phraseController = new PhraseController();
            phraseController.AnalyzeAllPhrases();
        }

        private void AnalyzeAlerts()
        {
            IAlertController alertAController = new AlertAController();
            IAlertController alertBController = new AlertBController();
            alertAController.EvaluateAlerts();
            alertBController.EvaluateAlerts();
        }

        public ICollection<Sentiment> GetAllEntitiesByCategory(CategoryType category)
        {
            bool sentimentCategory = false;
            if (category.Equals(CategoryType.Positiva))
                sentimentCategory = true;
            return repositoryA.GetEntitiesByPredicate(x => x.Category == sentimentCategory);
        }

    }
}
