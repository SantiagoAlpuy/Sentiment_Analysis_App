using System;

namespace BusinessLogic
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Born { get; set; }

        public override string ToString()
        {
            return Username;
        }
    }
}