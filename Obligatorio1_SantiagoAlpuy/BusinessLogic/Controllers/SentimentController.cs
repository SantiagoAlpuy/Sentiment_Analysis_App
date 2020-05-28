using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.IControllers;

namespace BusinessLogic.Controllers
{
    public class SentimentController : ISentimentController
    {
        Repository repository = Repository.Instance;
        private List<Sentiment> positiveSentiments;
        private List<Sentiment> negativeSentiments;

        private const string NULL_SENTIMENT = "Ingrese un sentimiento válido";
        private const string NULL_DESCRIPTION = "Ingrese una descripción válida.";
        private const string EMPTY_DESCRIPTION = "No puede ingresar una descripción vacía.";
        private const string POSITIVE_SENTIMENT_ALREADY_REGISTERED = "Un sentimiento positivo con el mismo nombre ya ha sido agregado.";
        private const string NEGATIVE_SENTIMENT_ALREADY_REGISTERED = "Un sentimiento negativo con el mismo nombre ya ha sido agregado.";
        private const string CONTAINS_NUMBERS = "La descripción del sentimiento contiene números.";
        private const string SENTIMENT_REGISTERED_OTHER_CATEGORY = "Sentimiento ya registrado pero con la categoría ";

        public SentimentController()
        {
            positiveSentiments = repository.PositiveSentiments;
            negativeSentiments = repository.NegativeSentiments;
        }

        public void AddSentiment(Sentiment sentiment)
        {
            ValidateSentiment(sentiment);
            AddSentimentToRepository(sentiment);
        }

        private void AddSentimentToRepository(Sentiment sentiment)
        {
            if (sentiment.Category)
                positiveSentiments.Add(sentiment);
            else
                negativeSentiments.Add(sentiment);
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
            else if (sentiment.Category && IsSentimentInRepo(positiveSentiments, sentiment))
                throw new InvalidOperationException(POSITIVE_SENTIMENT_ALREADY_REGISTERED);
            else if (!sentiment.Category && IsSentimentInRepo(negativeSentiments, sentiment))
                throw new InvalidOperationException(NEGATIVE_SENTIMENT_ALREADY_REGISTERED);
            else if (sentiment.Category && IsSentimentInRepo(negativeSentiments, sentiment))
                throw new ArgumentException(SENTIMENT_REGISTERED_OTHER_CATEGORY + " negativa.");
            else if (!sentiment.Category && IsSentimentInRepo(positiveSentiments, sentiment))
                throw new ArgumentException(SENTIMENT_REGISTERED_OTHER_CATEGORY + " positiva.");
        }

        private bool IsSentimentInRepo(List<Sentiment> sentiments, Sentiment sentiment)
        {
            return sentiments.Find(x => x.Description.Trim().ToLower() == sentiment.Description.Trim().ToLower()) != null;
        }

        public Sentiment ObtainSentiment(string description, bool category)
        {
            Sentiment sentiment = null;
            if (category)
                sentiment = ObtainSentiment(description, positiveSentiments);
            else
                sentiment = ObtainSentiment(description, negativeSentiments);
            return sentiment;
        }

        private Sentiment ObtainSentiment(string description, List<Sentiment> sentiments)
        {
            Sentiment sentiment = sentiments.Find(x => x.Description == description);
            if (sentiment != null)
                return sentiment;
            else
                throw new NullReferenceException("");
        }

        public void RemoveSentiment(string description, bool category)
        {
            if (category)
                RemoveSentiment(description, positiveSentiments);
            else
                RemoveSentiment(description, negativeSentiments);
        }

        private void RemoveSentiment(string description, List<Sentiment> sentiments)
        {
            Sentiment sentiment = ObtainSentiment(description, sentiments);
            sentiments.Remove(sentiment);
        }
    }
}
