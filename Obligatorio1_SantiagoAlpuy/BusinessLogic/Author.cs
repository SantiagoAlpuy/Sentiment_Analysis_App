using BusinessLogic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Author
    {
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
        private const string EMPTY_USERNAME_FIELD = "El campo de 'nombre de usuario' esta vacío.";
        private const string EMPTY_NAME_FIELD = "El campo 'nombre' esta vacío.";
        private const string EMPTY_SURNAME_FIELD = "El campo 'apellido' esta vacío.";
        private const string NULL_USERNAME = "Seleccione una nombre de usuario válido.";
        private const string NULL_NAME = "Seleccione una nombre válido.";
        private const string NULL_SURNAME = "Seleccione un apellido válido.";
        

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

        public void Validate()
        {
            if (this.Username == null)
                throw new ArgumentException(NULL_USERNAME);
            else if (this.Name == null)
                throw new ArgumentException(NULL_NAME);
            else if (this.Surname == null)
                throw new ArgumentException(NULL_SURNAME);
            else if (this.Username.Trim() == "")
                throw new ArgumentException(EMPTY_USERNAME_FIELD);
            else if (!IsAlphanumeric(this.Username))
                throw new ArgumentException(USERNAME_IS_NOT_ALPHANUMERIC);
            else if (this.Username.Length >= MAX_CHARS_IN_USERNAME)
                throw new ArgumentException(USERNAME_IS_TOO_BIG);
            else if (this.Name.Trim() == "")
                throw new ArgumentException(EMPTY_NAME_FIELD);
            else if (this.Name.Length >= MAX_CHARS_IN_NAME)
                throw new ArgumentException(NAME_IS_TOO_BIG);
            else if (!IsAlphabetic(this.Name))
                throw new ArgumentException(NAME_IS_NOT_ALPHABETIC);
            else if (this.Surname.Trim() == "")
                throw new ArgumentException(EMPTY_SURNAME_FIELD);
            else if (this.Surname.Length >= MAX_CHARS_IN_NAME)
                throw new ArgumentException(SURNAME_IS_TOO_BIG);
            else if (!IsAlphabetic(this.Surname))
                throw new ArgumentException(SURNAME_IS_NOT_ALPHABETIC);
            else if (DateTime.Now.AddYears(-LOWER_AGE_LIMIT).Year < this.Born.Year)
                throw new ArgumentException(AGE_LOWER_THAN_LOWER_LIMIT);
            else if (DateTime.Now.AddYears(-UPPER_AGE_LIMIT).Year > this.Born.Year)
                throw new ArgumentException(AGE_BIGGER_THAN_UPPER_LIMIT);
        }

        private bool IsAlphanumeric(string text)
        {
            return text.Trim().All(char.IsLetterOrDigit);
        }

        private bool IsAlphabetic(string text)
        {
            return text.All(char.IsLetter) || text.Replace(" ", "").All(char.IsLetter);
        }

        public override string ToString()
        {
            return Username;
        }

        public int CalculatePercentage(CategoryType category)
        {
            int totalNumberPhrases = this.Phrases.Count();
            int totalNumberByCategory = this.Phrases.Where(x => x.Category == category).Count();
            int percentage = totalNumberPhrases > 0 ? totalNumberByCategory * 100 / totalNumberPhrases : 0;
            return percentage;  
        }

        public int CalculateEntitiesInPhrases()
        {
            HashSet<string> entities = new HashSet<string>();
            foreach (Phrase phrase in this.Phrases)
            {
                if (phrase.Entity != "")
                    entities.Add(phrase.Entity);
            }
            return entities.Count();
        }

        public double CalculateMeanOfPhrases()
        {
            throw new NotImplementedException();
        }
    }
}