using System.Collections.Generic;

namespace BusinessLogic.IControllers
{
    public interface ISentimentController
    {
        void AddSentiment(Sentiment sentiment);
        Sentiment ObtainSentiment(string description, bool category);
        void RemoveSentiment(string description, bool category);
        void RemoveAllSentiments();
        ICollection<Sentiment> GetAllEntitiesByCategory(CategoryType category);
    }
}
