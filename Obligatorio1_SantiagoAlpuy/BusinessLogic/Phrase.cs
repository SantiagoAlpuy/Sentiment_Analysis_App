using System;
using System.Collections.Generic;

namespace BusinessLogic

{
    public class Phrase
    {
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public List<Phrase> phrase;

        public Phrase()
        {
            phrase = new List<Phrase>();
        }

        public void AddPhrase(Phrase phrase)
        {
            this.phrase.Add(phrase);
        }

        public Phrase ObtainPhrase(string comment, DateTime date)
        {
            return phrase.Find(x => x.Comment == comment && x.Date.Equals(date));
        }
    }
}