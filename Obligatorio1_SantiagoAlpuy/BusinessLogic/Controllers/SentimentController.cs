using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Controllers
{
    public class SentimentController
    {
        Repository repository = Repository.Instance;
        private List<Sentiment> positiveSentiments;
        private List<Sentiment> negativeSentiments;

        public SentimentController()
        {
            positiveSentiments = repository.positiveSentiments;
            negativeSentiments = repository.negativeSentiments;
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
                throw new NullSentimentException();
            else if (sentiment.Description == null)
                throw new NullAttributeInObjectException();
            else if (sentiment.Description.Trim() == "")
                throw new LackOfObligatoryParametersException();
            else if (sentiment.Description.Any(letter => char.IsDigit(letter)))
                throw new ContainsNumbersException();
            else if (sentiment.Category && FindSentiment(positiveSentiments, sentiment))
                throw new SentimentAlreadyExistsException();
            else if (!sentiment.Category && FindSentiment(negativeSentiments, sentiment))
                throw new SentimentAlreadyExistsException();
        }

        private bool FindSentiment(List<Sentiment> sentiments, Sentiment sentiment)
        {
            return sentiments.Find(x => x.Description == sentiment.Description) != null;
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
                throw new SentimentDoesNotExistsException();
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
