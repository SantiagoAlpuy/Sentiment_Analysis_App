using System;
using System.Collections.Generic;

namespace BusinessLogic

{
    public class Phrase
    {
        public int PhraseId { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public string Entity { get; set; }
        public CategoryType Category { get; set; }

        public virtual Author Author { get; set; }
    }
}