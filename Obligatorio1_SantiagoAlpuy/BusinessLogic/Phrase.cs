using System;
using System.Collections.Generic;

namespace BusinessLogic

{
    public class Phrase
    {
        private const string NULL_PHRASE = "Ingrese una frase válida.";
        private const string NULL_AUTHOR_IN_PHRASE = "Debe elegir un autor para agregar una frase.";
        private const string EMPTY_PHRASE = "Debe ingresar una frase no vacía.";
        private const string OLD_DATE = "La fecha no debe tener más de un año de antiguedad.";
        private const string FUTURE_DATE = "La fecha no puede ser superior a la fecha actual.";


        public int PhraseId { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string Entity { get; set; }
        public CategoryType Category { get; set; }
        public virtual Author Author { get; set; }

        public void Validate()
        {
            if (this.Comment == null)
                throw new NullReferenceException(NULL_PHRASE);
            else if (this.Comment.Trim() == "")
                throw new ArgumentException(EMPTY_PHRASE);
            else if (this.Date.CompareTo(DateTime.Now.AddYears(-1)) < 0)
                throw new ArgumentException(OLD_DATE);
            else if (this.Date.CompareTo(DateTime.Now) > 0)
                throw new ArgumentException(FUTURE_DATE);
            else if (this.Author == null)
                throw new ArgumentException(NULL_AUTHOR_IN_PHRASE);
        }
    }
}