using BusinessLogic.Controllers;
using BusinessLogic.IControllers;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class AlertB : IAlert
    {

        IAlertController alertController;

        private int POST_UPPER_BOUND = 1000;
        private const string NULL_ALERT = "Ingrese una configuración de alerta válida.";
        private const string NULL_ENTITY = "Ingrese una entidad válida.";
        private const string EMPTY_ENTITY = "Ingrese una entidad no vacía.";
        private const string NEUTRO_CATEGORY = "Debe seleccionar una categoría.";
        private const string NEGATIVE_POSTS = "No puede ingresar una cantidad negativa de posts.";
        private const string NEGATIVE_DAYS = "No puede ingresar una cantidad negativa de días.";
        private const string NEGATIVE_HOURS = "No puede ingresar una cantidad negativa de horas.";
        private const string POST_COUNT_EXCEEDED = "No puede ingresar una cantidad superior a {0}";

        public int AlertBId { get; set; }
        public CategoryType Category { get; set; }
        public int Posts { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public bool Activated { get; set; }
        
        public AlertB()
        {
            alertController = new AlertBController();
        }

        public void ValidateAlert()
        {
            if (this.Category.Equals(CategoryType.Neutro))
                throw new ArgumentException(NEUTRO_CATEGORY);
            else if (this.Posts < 0)
                throw new ArgumentException(NEGATIVE_POSTS);
            else if (this.Days < 0)
                throw new ArgumentException(NEGATIVE_DAYS);
            else if (this.Hours < 0)
                throw new ArgumentException(NEGATIVE_HOURS);
            else if (this.Posts > POST_UPPER_BOUND)
                throw new ArgumentException(String.Format(POST_COUNT_EXCEEDED, POST_UPPER_BOUND));
        }

        public void EvaluateAlert(List<Phrase> phrases)
        {
            DateTime lowerLimitAlert = new DateTime();
            int count = 0;
            foreach (Phrase phrase in phrases)
            {
                if (ValidateCategories(phrase, this))
                {
                    lowerLimitAlert = CalculateLowerLimitAlert(this);
                    if (IsInsideAlertRange(lowerLimitAlert, phrase))
                        count++;
                }
            }
            ActivateAlarm(this, count);
        }

        private bool ValidateCategories(Phrase phrase, AlertB alert)
        {
            return phrase.Category.Equals(alert.Category) && !phrase.Category.Equals(CategoryType.Neutro);
        }

        private DateTime CalculateLowerLimitAlert(AlertB alert)
        {
            int hours = -(alert.Hours + alert.Days * 24);
            return DateTime.Now.AddHours(hours);
        }

        private bool IsInsideAlertRange(DateTime date, Phrase phrase)
        {
            return date.CompareTo(phrase.Date) < 0;
        }

        private void ActivateAlarm(AlertB alert, int count)
        {
            if (alert.Posts <= count)
                alert.Activated = true;
            else
                alert.Activated = false;
            alertController.UpdateAlert(alert);
        }

    }
}