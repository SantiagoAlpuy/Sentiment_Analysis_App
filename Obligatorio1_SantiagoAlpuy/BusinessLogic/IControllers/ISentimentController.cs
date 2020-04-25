using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.IControllers
{
    public interface ISentimentController
    {
        void AddSentiment(Sentiment sentiment);

        Sentiment ObtainSentiment(string description, bool category);

        void RemoveSentiment(string description, bool category);
    }
}
