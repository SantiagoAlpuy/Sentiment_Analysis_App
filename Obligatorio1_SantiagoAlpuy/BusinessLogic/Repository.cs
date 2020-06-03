using System.Collections.Generic;


namespace BusinessLogic
{
    public class Repository
    {
        public List<Sentiment> PositiveSentiments { get; set; }
        public List<Sentiment> NegativeSentiments { get; set; }
        public List<Entity> Entities { get; set; }
        public List<Phrase> Phrases { get; set; }
        public List<IAlert> Alerts { get; set; }
        public List<Author> Authors { get; set; }

        private static Repository instance = null;

        private Repository()
        {
            PositiveSentiments = new List<Sentiment>();
            NegativeSentiments = new List<Sentiment>();
            Entities = new List<Entity>();
            Phrases = new List<Phrase>();
            Alerts = new List<IAlert>();
            Authors = new List<Author>();
        }

        public static Repository Instance
        {
            get
            {
                if (instance == null)
                    instance = new Repository();
                return instance;
            }
        }

        public void CleanLists()
        {
            PositiveSentiments.Clear();
            NegativeSentiments.Clear();
            Entities.Clear();
            Phrases.Clear();
            Alerts.Clear();
            Authors.Clear();
        }
    }
}