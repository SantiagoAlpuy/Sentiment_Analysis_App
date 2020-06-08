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
        public virtual ICollection<Phrase> Phrases { get; set; }
        public virtual ICollection<AlertBAuthor> AlertBAuthors { get; set; }

        public Author()
        {
            Phrases = new List<Phrase>();
            AlertBAuthors = new List<AlertBAuthor>();
        }

        public override string ToString()
        {
            return Username;
        }
    }
}