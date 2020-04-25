using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using BusinessLogic.Exceptions;
using BusinessLogic.IControllers;

namespace BusinessLogic.Controllers
{
    public class SentimentController : ISentimentController
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
            else if (sentiment.Category && IsSentimentInRepo(positiveSentiments, sentiment))
                throw new SentimentAlreadyExistsException();
            else if (!sentiment.Category && IsSentimentInRepo(negativeSentiments, sentiment))
                throw new SentimentAlreadyExistsException();
            else if (sentiment.Category && IsSentimentInRepo(negativeSentiments, sentiment))
                throw new SentimentRegisteredWithOppositeCategoryException();
            else if (!sentiment.Category && IsSentimentInRepo(positiveSentiments, sentiment))
                throw new SentimentRegisteredWithOppositeCategoryException();
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
