using System;
using System.Collections.Generic;
using BusinessLogic.IControllers;
using System.Linq;
using BusinessLogic.DataAccess;

namespace BusinessLogic.Controllers
{
    public class AuthorController : IAuthorController
    {

        RepositoryA<Author> repositoryA;
        private IAlertController alertAController;
        private IAlertController alertBController;
        private IPhraseController phraseController;

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
        private const string NULL_USERNAME = "Seleccione una nombre de usuario válido.";
        private const string NULL_NAME = "Seleccione una nombre válido.";
        private const string NULL_SURNAME = "Seleccione un apellido válido.";
        private const string NULL_AUTHOR = "Los autores no pueden ser nulos.";
        private const string INEXISTENT_AUTHOR = "El usuario a eliminar no existe.";

        public AuthorController()
        {
            repositoryA = new RepositoryA<Author>();
            alertAController = new AlertAController();
            alertBController = new AlertBController();
            phraseController = new PhraseController();
        }

        public void AddAuthor(Author author)
        {
            ValidateAuthorAdition(author);
            repositoryA.Add(author);
        }

        public void RemoveAuthor(string username)
        {
            Author author = ObtainAuthorByUsername(username);
            if (author == null)
                throw new NullReferenceException(INEXISTENT_AUTHOR);

            repositoryA.Remove(author);
            AnalyzeAlerts();
        }

        public void RemoveAllAuthors()
        {
            repositoryA.ClearAll();
        }

        private void AnalyzeAlerts()
        {
            alertAController.EvaluateAlerts();
            alertBController.EvaluateAlerts();
        }


        private void ValidateAuthorAdition(Author author)
        {
            if (author == null)
                throw new ArgumentException(NULL_AUTHOR);
            else if (author.Username == null)
                throw new ArgumentException(NULL_USERNAME);
            else if (author.Name == null)
                throw new ArgumentException(NULL_NAME);
            else if (author.Surname == null)
                throw new ArgumentException(NULL_SURNAME);
            else if (author.Username.Trim() == "")
                throw new ArgumentException(EMPTY_USERNAME_FIELD);
            else if (!IsAlphanumeric(author.Username))
                throw new ArgumentException(USERNAME_IS_NOT_ALPHANUMERIC);
            else if (author.Username.Length >= MAX_CHARS_IN_USERNAME)
                throw new ArgumentException(USERNAME_IS_TOO_BIG);
            else if (ObtainAuthorByUsername(author.Username) != null)
                throw new InvalidOperationException(AUTHOR_ALREADY_EXISTS);
            else if (author.Name.Trim() == "")
                throw new ArgumentException(EMPTY_NAME_FIELD);
            else if (author.Name.Length >= MAX_CHARS_IN_NAME)
                throw new ArgumentException(NAME_IS_TOO_BIG);
            else if (!IsAlphabetic(author.Name))
                throw new ArgumentException(NAME_IS_NOT_ALPHABETIC);
            else if (author.Surname.Trim() == "")
                throw new ArgumentException(EMPTY_SURNAME_FIELD);
            else if (author.Surname.Length >= MAX_CHARS_IN_NAME)
                throw new ArgumentException(SURNAME_IS_TOO_BIG);
            else if (!IsAlphabetic(author.Surname))
                throw new ArgumentException(SURNAME_IS_NOT_ALPHABETIC);
            else if (DateTime.Now.AddYears(-LOWER_AGE_LIMIT).Year < author.Born.Year)
                throw new ArgumentException(AGE_LOWER_THAN_LOWER_LIMIT);
            else if (DateTime.Now.AddYears(-UPPER_AGE_LIMIT).Year > author.Born.Year)
                throw new ArgumentException(AGE_BIGGER_THAN_UPPER_LIMIT);
        }

        private bool IsAlphanumeric(string text)
        {
            return text.Trim().All(char.IsLetterOrDigit);
            
        }

        private bool IsAlphabetic(string text)
        {
            return text.All(char.IsLetter) || text.Replace(" ","").All(char.IsLetter);
        }


        public Author ObtainAuthorByUsername(string username)
        {
            return repositoryA.Find(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
        }

        public void ModifyAuthor(Author author1, Author author2)
        {
            ValidateAuthorModification(author1, author2);
            author1.Name = author2.Name;
            author1.Surname = author2.Surname;
            author1.Born = author2.Born;
            repositoryA.Update(author1);
        }

        private void ValidateAuthorModification(Author author1, Author author2)
        {
            if (author1 == null || author2 == null)
                throw new ArgumentException(NULL_AUTHOR);
            else if (author2.Name == null)
                throw new ArgumentException(NULL_NAME);
            else if (author2.Name.Trim() == "")
                throw new ArgumentException(EMPTY_NAME_FIELD);
            else if (!IsAlphabetic(author2.Name))
                throw new ArgumentException(NAME_IS_NOT_ALPHABETIC);
            else if (author2.Name.Length >= MAX_CHARS_IN_NAME)
                throw new ArgumentException(NAME_IS_TOO_BIG);
            else if (author2.Surname == null)
                throw new ArgumentException(NULL_SURNAME);
            else if (author2.Surname.Trim() == "")
                throw new ArgumentException(EMPTY_SURNAME_FIELD);
            else if (!IsAlphabetic(author2.Surname))
                throw new ArgumentException(SURNAME_IS_NOT_ALPHABETIC);
            else if (author2.Surname.Length >= MAX_CHARS_IN_NAME)
                throw new ArgumentException(NAME_IS_TOO_BIG);
            else if (DateTime.Now.AddYears(-LOWER_AGE_LIMIT).Year < author2.Born.Year)
                throw new ArgumentException(AGE_LOWER_THAN_LOWER_LIMIT);
            else if (DateTime.Now.AddYears(-UPPER_AGE_LIMIT).Year > author2.Born.Year)
                throw new ArgumentException(AGE_BIGGER_THAN_UPPER_LIMIT);
        }

        public ICollection<Author> GetAll()
        {
            return repositoryA.GetAll();
        }

        public Author GetAuthorById(int authorId)
        {
            return repositoryA.Find(x => x.AuthorId == authorId);
        }

    }
}
