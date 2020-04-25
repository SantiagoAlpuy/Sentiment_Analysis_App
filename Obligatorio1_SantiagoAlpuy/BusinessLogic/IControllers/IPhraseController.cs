using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.IControllers
{
    public interface IPhraseController
    {
        void AddPhraseToRepository(Phrase phrase);

        Phrase ObtainPhrase(string comment, DateTime date);

        void AnalyzePhrase(Phrase phrase)

        void AnalyzeAllPhrases();


    }
}
