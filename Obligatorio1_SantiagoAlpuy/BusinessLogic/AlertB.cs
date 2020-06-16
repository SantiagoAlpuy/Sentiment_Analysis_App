using BusinessLogic.Controllers;
using BusinessLogic.IControllers;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class AlertB : IAlert
    {

        private int POST_UPPER_BOUND = 1000;
        private const string NULL_ALERT = "Ingrese una configuración de alerta válida.";
        private const string NULL_ENTITY = "Ingrese una entidad válida.";
        private const string EMPTY_ENTITY = "Ingrese una entidad no vacía.";
        private const string NEUTRO_CATEGORY = "Debe seleccionar una categoría.";
        private const string INVALID_POST_COUNT = "Debe seleccionar una cantidad positiva de posts.";
        private const string NEGATIVE_DAYS = "No puede ingresar una cantidad negativa de días.";
        private const string NEGATIVE_HOURS = "No puede ingresar una cantidad negativa de horas.";
        private const string POST_COUNT_EXCEEDED = "No puede ingresar una cantidad superior a {0}";
        private const string INCLUDED_ALERTB_AUTHORS = "AlertBAuthors";

        public int AlertBId { get; set; }
        public CategoryType Category { get; set; }
        public int Posts { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public bool Activated { get; set; }
        public virtual ICollection<AlertBAuthor> AlertBAuthors { get; set; }
        
        public AlertB()
        {
            AlertBAuthors = new List<AlertBAuthor>();
        }

        public void Validate()
        {
            if (this.Category.Equals(CategoryType.Neutro))
                throw new ArgumentException(NEUTRO_CATEGORY);
            else if (this.Posts <= 0)
                throw new ArgumentException(INVALID_POST_COUNT);
            else if (this.Days < 0)
                throw new ArgumentException(NEGATIVE_DAYS);
            else if (this.Hours < 0)
                throw new ArgumentException(NEGATIVE_HOURS);
            else if (this.Posts > POST_UPPER_BOUND)
                throw new ArgumentException(String.Format(POST_COUNT_EXCEEDED, POST_UPPER_BOUND));
        }

        public void EvaluateAlert()
        {
            PhraseController phraseController = new PhraseController();
            ICollection<Phrase> phrases = phraseController.GetAllEntitiesWithIncludes("Author");
            ICollection<int> authorsOfActivatedAlert = new HashSet<int>();
            DateTime lowerLimitAlert = new DateTime();
            int count = 0;
            foreach (Phrase phrase in phrases)
            {
                if (ValidateCategories(phrase))
                {
                    lowerLimitAlert = CalculateLowerLimitAlert();
                    if (IsInsideAlertRange(lowerLimitAlert, phrase))
                    {
                        count++;
                        authorsOfActivatedAlert.Add(phrase.Author.AuthorId);
                    }
                }
            }
            ActivateAlarm(count);
            CheckAssociationAlertAuthor(authorsOfActivatedAlert);
        }

        private bool ValidateCategories(Phrase phrase)
        {
            return phrase.Category.Equals(this.Category) && !phrase.Category.Equals(CategoryType.Neutro);
        }

        private DateTime CalculateLowerLimitAlert()
        {
            int hours = -(this.Hours + this.Days * 24);
            return DateTime.Now.AddHours(hours);
        }

        private bool IsInsideAlertRange(DateTime date, Phrase phrase)
        {
            return date.CompareTo(phrase.Date) < 0;
        }

        private void ActivateAlarm(int count)
        {
            AlertBController alertController = new AlertBController();
            if (this.Posts <= count)
            {
                this.Activated = true;
            }
            else{
                this.Activated = false;
            }
                
            alertController.UpdateAlert(this);
        }

        private void CheckAssociationAlertAuthor(ICollection<int> collection)
        {
            AuthorController authorController = new AuthorController();
            AlertBAuthorRelationController alertBAuthorController = new AlertBAuthorRelationController();
            if (this.Activated)
            {
                foreach(int item in collection)
                {
                    Author author = authorController.GetAuthorByIdWithInclude(item, INCLUDED_ALERTB_AUTHORS);
                    alertBAuthorController.AddAssociationAlertAuthor(this, author);
                }
            }
            else
            {
                alertBAuthorController.RemoveAssociationAlertAuthor(this);
            }
        }

    }
}