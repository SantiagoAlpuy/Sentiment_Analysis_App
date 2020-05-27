using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Exceptions;
using BusinessLogic.IControllers;
using System.Linq;

namespace BusinessLogic.Controllers
{
    public class AuthorController : IAuthorController
    { 
        Repository repository = Repository.Instance;
        private List<Author> authors;
        private const int MAX_CHARS_IN_USERNAME = 10;
        private const int MAX_CHARS_IN_NAME = 15;
        private const string USERNAME_IS_TOO_BIG = "El usuario es mayor a {MAX_CHARS_IN_USERNAME} caracteres.";
        private const string USERNAME_IS_NOT_ALPHANUMERIC = "El nombre de usuario contiene caracteres no alfanumericos.";
        private const string NAME_IS_TOO_BIG = "El nombre es mayor a {MAX_CHARS_IN_NAME} caracteres.";
        private const string NAME_IS_NOT_ALPHABETIC = "El nombre contiene caracteres no alfabeticos.";
        private const string SURNAME_IS_TOO_BIG = "El apellido del usuario es mayor a {MAX_CHARS_IN_NAME} caracteres.";
        private const string SURNAME_IS_NOT_ALPHABETIC = "El apellido contiene caracteres no alfabeticos.";

        public AuthorController()
        {
            authors = repository.Authors;
        }

        public void AddAuthor(Author author)
        {
            if (author.Username == null || author.Name == null || author.Surname == null)
                throw new LackOfObligatoryParametersException();
            else if (author.Username.Length >= MAX_CHARS_IN_USERNAME)
                throw new TooLargeException(USERNAME_IS_TOO_BIG);
            else if (!IsAlphanumeric(author.Username))
                throw new NotAlphaNumericalException(USERNAME_IS_NOT_ALPHANUMERIC);
            else if (author.Name.Length >= MAX_CHARS_IN_NAME)
                throw new TooLargeException(NAME_IS_TOO_BIG);
            else if (!isAlphabetic(author.Name))
                throw new NotAlphabeticException(NAME_IS_NOT_ALPHABETIC);
            else if (author.Surname.Length >= MAX_CHARS_IN_NAME)
                throw new TooLargeException(SURNAME_IS_TOO_BIG);
            else if (!isAlphabetic(author.Surname))
                throw new NotAlphabeticException(SURNAME_IS_NOT_ALPHABETIC);
            else
                authors.Add(author);
        }

        private bool IsAlphanumeric(string text)
        {
            return text.All(char.IsLetterOrDigit);
            
        }

        private bool isAlphabetic(string text)
        {
            return text.All(char.IsLetter);
        }


        public Author ObtainAuthorByUsername(string username)
        {
            return authors.Find(x => x.Username == username);
        }
    }
}
