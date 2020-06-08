using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DataAccess;
using BusinessLogic.IControllers;

namespace BusinessLogic.Controllers
{
    public class SentimentController : ISentimentController
    {

        RepositoryA<Sentiment> repositoryA;
        private IAlertController alertAController;
        private IAlertController alertBController;
        private IPhraseController phraseController;

        private const string NULL_SENTIMENT = "Ingrese un sentimiento válido";
        private const string NULL_DESCRIPTION = "Ingrese una descripción válida.";
        private const string EMPTY_DESCRIPTION = "No puede ingresar una descripción vacía.";
        private const string POSITIVE_SENTIMENT_ALREADY_REGISTERED = "Un sentimiento positivo con el mismo nombre ya ha sido agregado.";
        private const string NEGATIVE_SENTIMENT_ALREADY_REGISTERED = "Un sentimiento negativo con el mismo nombre ya ha sido agregado.";
        private const string CONTAINS_NUMBERS = "La descripción del sentimiento contiene números.";
        private const string SENTIMENT_REGISTERED_OTHER_CATEGORY = "Sentimiento ya registrado pero con la categoría ";

        public SentimentController()
        {
            repositoryA = new RepositoryA<Sentiment>();
        }

        public void AddSentiment(Sentiment sentiment)
        {
            ValidateSentiment(sentiment);
            repositoryA.Add(sentiment);
            AnalyzePhrasesAndAlerts();
        }

        private void ValidateSentiment(Sentiment sentiment)
        {
            if (sentiment == null)
                throw new NullReferenceException(NULL_SENTIMENT);
            else if (sentiment.Description == null)
                throw new NullReferenceException(NULL_DESCRIPTION);
            else if (sentiment.Description.Trim() == "")
                throw new ArgumentException(EMPTY_DESCRIPTION);
            else if (sentiment.Description.Any(letter => char.IsDigit(letter)))
                throw new ArgumentException(CONTAINS_NUMBERS);
            else if (sentiment.Category && IsSentimentInRepo(sentiment, true))
                throw new InvalidOperationException(POSITIVE_SENTIMENT_ALREADY_REGISTERED);
            else if (!sentiment.Category && IsSentimentInRepo(sentiment, false))
                throw new InvalidOperationException(NEGATIVE_SENTIMENT_ALREADY_REGISTERED);
            else if (sentiment.Category && IsSentimentInRepo(sentiment, false))
                throw new ArgumentException(SENTIMENT_REGISTERED_OTHER_CATEGORY + " negativa.");
            else if (!sentiment.Category && IsSentimentInRepo(sentiment, true))
                throw new ArgumentException(SENTIMENT_REGISTERED_OTHER_CATEGORY + " positiva.");
        }

        private bool IsSentimentInRepo(Sentiment sentiment, bool category)
        {
            return repositoryA.Find(x => x.Description.Trim().ToLower() == sentiment.Description.Trim().ToLower()
                                    && x.Category == category) != null;
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
                AnalyzePhrasesAndAlerts();
            }
        }

        public void RemoveAllSentiments()
        {
            repositoryA.ClearAll();
        }

        private void AnalyzePhrasesAndAlerts()
        {
            alertAController = new AlertAController();
            alertBController = new AlertBController();
            phraseController = new PhraseController();
            phraseController.AnalyzeAllPhrases();
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
