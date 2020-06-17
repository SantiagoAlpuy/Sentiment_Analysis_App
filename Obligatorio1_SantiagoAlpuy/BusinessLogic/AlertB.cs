﻿using BusinessLogic.Controllers;
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
            AlertBAuthorController alertBAuthorController = new AlertBAuthorController();
            AuthorController authorController = new AuthorController();
            ICollection<Author> authors = authorController.GetAllAuthorsWithInclude();
            
            foreach (Author author in authors)
            {
                int count = 0;
                ICollection<Phrase> phrases = author.Phrases;
                foreach (Phrase phrase in phrases)
                {
                    if (phrase.Category.Equals(this.Category))
                    {
                        DateTime lowerLimitAlert = CalculateLowerLimitAlert();
                        if (lowerLimitAlert.CompareTo(phrase.Date) < 0)
                        {
                            count++;
                        }
                    }
                }

                if (count >= this.Posts)
                {
                    this.Activated = true;
                    alertBAuthorController.AddAssociationAlertAuthor(this, author);
                }

                count = 0;
            }
        }

        private DateTime CalculateLowerLimitAlert()
        {
            int hours = -(this.Hours + this.Days * 24);
            return DateTime.Now.AddHours(hours);
        }




    }
}