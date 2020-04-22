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

        public void addSentiment(Sentiment sentiment)
        {
            validateSentiment(sentiment);
            addSentimentToRepository(sentiment);
        }

        private void addSentimentToRepository(Sentiment sentiment)
        {
            if (sentiment.Category)
                positiveSentiments.Add(sentiment);
            else
                negativeSentiments.Add(sentiment);
        }

        private void validateSentiment(Sentiment sentiment)
        {
            if (sentiment == null)
                throw new NullSentimentException();
            else if (sentiment.Description == null)
                throw new NullAttributeInObjectException();
            else if (sentiment.Description == "")
                throw new LackOfObligatoryParametersException();
            else if (sentiment.Description.Any(letter => char.IsDigit(letter)))
                throw new ContainsNumbersException();
            else if (sentiment.Category && positiveSentiments.Contains(sentiment))
                throw new SentimentAlreadyExistsException();
            else if (!sentiment.Category && negativeSentiments.Contains(sentiment))
                throw new SentimentAlreadyExistsException();
        }

        public Sentiment obtainSentiment(string description, bool category)
        {
            Sentiment sentiment = null;
            if (category)
                sentiment = obtainPositiveSentiment(description);
            else
                sentiment = obtainNegativeSentiment(description);
            return sentiment;
        }

        private Sentiment obtainPositiveSentiment(string description)
        {
            Sentiment sentiment = positiveSentiments.Find(x => x.Description == description);
            if (sentiment != null)
                return sentiment;
            else
                throw new SentimentDoesNotExistsException();
        }

        private Sentiment obtainNegativeSentiment(string description)
        {
            Sentiment sentiment = negativeSentiments.Find(x => x.Description == description);
            if (sentiment != null)
                return sentiment;
            else
                throw new SentimentDoesNotExistsException();
        }


        public void removeSentiment(string description, bool category)
        {
            if (category)
                removePositiveSentiment(description);
            else
                removeNegativeSentiment(description);
        }

        private void removePositiveSentiment(string description)
        {
            Sentiment sentiment = obtainPositiveSentiment(description);
            positiveSentiments.Remove(sentiment);

        }

        private void removeNegativeSentiment(string description)
        {
            Sentiment sentiment = obtainNegativeSentiment(description);
            negativeSentiments.Remove(sentiment);
        }
    }
}
