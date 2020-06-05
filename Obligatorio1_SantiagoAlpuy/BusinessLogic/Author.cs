using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Born { get; set; }
        public ICollection<Phrase> Phrases { get; set; }

        public Author()
        {
            Phrases = new List<Phrase>();
        }

        public override string ToString()
        {
            return Username;
        }
    }
}