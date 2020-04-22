using System;

namespace BusinessLogic

{
    public class Phrase
    {
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public string Entity { get; set; }
        public CategoryType Category { get; set; }
    }
}