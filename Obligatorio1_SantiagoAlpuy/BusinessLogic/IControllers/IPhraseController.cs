﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.IControllers
{
    public interface IPhraseController
    {
        void AddPhrase(Phrase phrase);

        Phrase ObtainPhrase(string comment, DateTime date);

        void AnalyzePhrase(Phrase phrase);

        void AnalyzeAllPhrases();
        List<Phrase> GetAllEntities();

        List<Phrase> GetAllEntitiesWithIncludes(string entityToInclude);
        void RemoveAllPhrases();
    }
}
