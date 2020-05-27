using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Exceptions;
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
            if (author.Username == null)
                throw new LackOfObligatoryParametersException();
            else
                authors.Add(author);
        }

        public Author ObtainAuthorByUsername(string username)
        {
            return authors.Find(x => x.Username == username);
        }
    }
}
