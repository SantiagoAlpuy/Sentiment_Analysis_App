using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.IControllers
{
    public interface IPhraseController
    {
        void AddPhrase(Phrase phrase);

        Phrase ObtainPhrase(int phraseId);

        void AnalyzeAllPhrases();
        List<Phrase> GetAllEntities();

        List<Phrase> GetAllEntitiesWithIncludes(string entityToInclude);
        void RemoveAllPhrases();
    }
}
