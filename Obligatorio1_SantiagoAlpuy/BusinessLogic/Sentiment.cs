using BusinessLogic.Controllers;
using BusinessLogic.DataAccess;
using System;
using System.Linq;

namespace BusinessLogic
{
    public class Sentiment
    {

        private const string NULL_DESCRIPTION = "Ingrese una descripción válida.";
        private const string EMPTY_DESCRIPTION = "No puede ingresar una descripción vacía.";
        private const string POSITIVE_SENTIMENT_ALREADY_REGISTERED = "Un sentimiento positivo con el mismo nombre ya ha sido agregado.";
        private const string NEGATIVE_SENTIMENT_ALREADY_REGISTERED = "Un sentimiento negativo con el mismo nombre ya ha sido agregado.";
        private const string CONTAINS_NUMBERS = "La descripción del sentimiento contiene números.";
        private const string SENTIMENT_REGISTERED_OTHER_CATEGORY = "Sentimiento ya registrado pero con la categoría ";

        public int SentimentId { get; set; }
        public string Description { get; set; }
        public bool Category { get; set; }
        public void Validate()
        {
            if (this.Description == null)
                throw new NullReferenceException(NULL_DESCRIPTION);
            else if (this.Description.Trim() == "")
                throw new ArgumentException(EMPTY_DESCRIPTION);
            else if (this.Description.Any(letter => char.IsDigit(letter)))
                throw new ArgumentException(CONTAINS_NUMBERS);
            else if (this.Category && IsSentimentInRepo(this.Description, true))
                throw new InvalidOperationException(POSITIVE_SENTIMENT_ALREADY_REGISTERED);
            else if (!this.Category && IsSentimentInRepo(this.Description, false))
                throw new InvalidOperationException(NEGATIVE_SENTIMENT_ALREADY_REGISTERED);
            else if (this.Category && IsSentimentInRepo(this.Description, false))
                throw new ArgumentException(SENTIMENT_REGISTERED_OTHER_CATEGORY + " negativa.");
            else if (!this.Category && IsSentimentInRepo(this.Description, true))
                throw new ArgumentException(SENTIMENT_REGISTERED_OTHER_CATEGORY + " positiva.");
        }

        private bool IsSentimentInRepo(string description, bool category)
        {
            SentimentController sentimentController = new SentimentController();
            Sentiment sentiment = sentimentController.ObtainSentiment(description, category);
            return (sentiment != null);
        }

    }
}