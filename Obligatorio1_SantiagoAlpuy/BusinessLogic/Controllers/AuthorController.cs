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
        private const int LOWER_AGE_LIMIT = 13;
        private const int UPPER_AGE_LIMIT = 100;
        private string USERNAME_IS_TOO_BIG = String.Format("El usuario es mayor a {0} caracteres.", MAX_CHARS_IN_USERNAME);
        private const string USERNAME_IS_NOT_ALPHANUMERIC = "El nombre de usuario contiene caracteres no alfanumericos.";
        private string NAME_IS_TOO_BIG = String.Format("El nombre es mayor a {0} caracteres.", MAX_CHARS_IN_NAME);
        private const string NAME_IS_NOT_ALPHABETIC = "El nombre contiene caracteres no alfabeticos.";
        private string SURNAME_IS_TOO_BIG = String.Format("El apellido del usuario es mayor a {0} caracteres.", MAX_CHARS_IN_NAME);
        private const string SURNAME_IS_NOT_ALPHABETIC = "El apellido contiene caracteres no alfabeticos.";
        private string AGE_LOWER_THAN_LOWER_LIMIT = String.Format("La edad del autor es inferior a {0}", LOWER_AGE_LIMIT);
        private string AGE_BIGGER_THAN_UPPER_LIMIT = String.Format("La edad del autor es superior a {0}", UPPER_AGE_LIMIT);
        private const string AUTHOR_ALREADY_EXISTS = "El usuario que intento agregar ya ha sido agregado al sistema, pruebe otra combinación.";
        private const string EMPTY_USERNAME_FIELD = "El campo de 'nombre de usuario' esta vacío.";
        private const string EMPTY_NAME_FIELD = "El campo 'nombre' esta vacío.";
        private const string EMPTY_SURNAME_FIELD = "El campo 'apellido' esta vacío.";

        public AuthorController()
        {
            authors = repository.Authors;
        }
        
        public void AddAuthor(Author author)
        {
            if (author.Username == null || author.Name == null || author.Surname == null)
                throw new LackOfObligatoryParametersException(); 
            else if (author.Username.Trim() == "")
                throw new EmptyFieldException(EMPTY_USERNAME_FIELD);
            else if (!IsAlphanumeric(author.Username))
                throw new NotAlphaNumericalException(USERNAME_IS_NOT_ALPHANUMERIC);
            else if (author.Username.Length >= MAX_CHARS_IN_USERNAME)
                throw new TooLargeException(USERNAME_IS_TOO_BIG);
            else if (ObtainAuthorByUsername(author.Username) != null)
                throw new AlreadyExistsException(AUTHOR_ALREADY_EXISTS);

            else if (author.Name.Trim() == "")
                throw new EmptyFieldException(EMPTY_NAME_FIELD);
            else if (author.Name.Length >= MAX_CHARS_IN_NAME)
                throw new TooLargeException(NAME_IS_TOO_BIG);
            else if (!isAlphabetic(author.Name))
                throw new NotAlphabeticException(NAME_IS_NOT_ALPHABETIC);

            else if (author.Surname.Trim() == "")
                throw new EmptyFieldException(EMPTY_SURNAME_FIELD);            
            else if (author.Surname.Length >= MAX_CHARS_IN_NAME)
                throw new TooLargeException(SURNAME_IS_TOO_BIG);
            else if (!isAlphabetic(author.Surname))
                throw new NotAlphabeticException(SURNAME_IS_NOT_ALPHABETIC);

            else if (DateTime.Now.AddYears(-LOWER_AGE_LIMIT).Year < author.Born.Year)
                throw new DateNotInRangeException(AGE_LOWER_THAN_LOWER_LIMIT);
            else if (DateTime.Now.AddYears(-UPPER_AGE_LIMIT).Year > author.Born.Year)
                throw new DateNotInRangeException(AGE_BIGGER_THAN_UPPER_LIMIT);
            else
                authors.Add(author);
        }

        private bool IsAlphanumeric(string text)
        {
            return text.Trim().All(char.IsLetterOrDigit);
            
        }

        private bool isAlphabetic(string text)
        {
            return text.All(char.IsLetter);
        }


        public Author ObtainAuthorByUsername(string username)
        {
            return authors.Find(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
        }
    }
}
