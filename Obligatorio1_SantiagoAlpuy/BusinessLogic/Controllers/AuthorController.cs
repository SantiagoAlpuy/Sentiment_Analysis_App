using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.IControllers;

namespace BusinessLogic.Controllers
{
    public class AuthorController : IAuthorController
    { 
        Repository repository = Repository.Instance;
        private List<Author> authors;

        public AuthorController()
        {
            authors = repository.Authors;
        }

        public void AddAuthor(Author author)
        {
            authors.Add(author);
        }

        public Author ObtainAuthorByUsername(string username)
        {
            return authors.Find(x => x.Username == username);
        }
    }
}
