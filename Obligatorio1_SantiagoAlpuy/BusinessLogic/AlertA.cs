﻿using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class AlertA : IAlert
    {


        private const string NULL_ALERT = "Ingrese una configuración de alerta válida.";
        private const string NULL_ENTITY = "Ingrese una entidad válida.";
        private const string EMPTY_ENTITY = "Ingrese una entidad no vacía.";
        private const string NEUTRO_CATEGORY = "Debe seleccionar una categoría.";
        private const string NEGATIVE_POSTS = "No puede ingresar una cantidad negativa de posts.";
        private const string NEGATIVE_DAYS = "No puede ingresar una cantidad negativa de días.";
        private const string NEGATIVE_HOURS = "No puede ingresar una cantidad negativa de horas.";

        
        public string Entity { get; set; }
        public CategoryType Category { get; set; }
        public int Posts { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public bool Activated { get; set; }

        public void ValidateAlert()
        {
            if (this.Entity == null)
                throw new NullReferenceException(NULL_ENTITY);
            else if (this.Entity.Trim() == "")
                throw new ArgumentException(EMPTY_ENTITY);
            else if (this.Category.Equals(CategoryType.Neutro))
                throw new ArgumentException(NEUTRO_CATEGORY);
            else if (this.Posts < 0)
                throw new ArgumentException(NEGATIVE_POSTS);
            else if (this.Days < 0)
                throw new ArgumentException(NEGATIVE_DAYS);
            else if (this.Hours < 0)
                throw new ArgumentException(NEGATIVE_HOURS);
        }


        public void EvaluateAlert(List<Phrase> phrases)
        {
            DateTime lowerLimitAlert = new DateTime();
            int count = 0;
            foreach (Phrase phrase in phrases)
            {
                if (ValidateEntities(phrase, this) && ValidateCategories(phrase, this))
                {
                    lowerLimitAlert = CalculateLowerLimitAlert(this);
                    if (IsInsideAlertRange(lowerLimitAlert, phrase))
                        count++;
                }
            }
            ActivateAlarm(this, count);
        }


        private bool ValidateEntities(Phrase phrase, AlertA alert)
        {
            return phrase.Entity.ToUpper().Trim() == alert.Entity.ToUpper().Trim();
        }

        private bool ValidateCategories(Phrase phrase, AlertA alert)
        {
            return phrase.Category.Equals(alert.Category) && !phrase.Category.Equals(CategoryType.Neutro);
        }

        private DateTime CalculateLowerLimitAlert(AlertA alert)
        {
            int hours = -(alert.Hours + alert.Days * 24);
            return DateTime.Now.AddHours(hours);
        }

        private bool IsInsideAlertRange(DateTime date, Phrase phrase)
        {
            return date.CompareTo(phrase.Date) < 0;
        }

        private void ActivateAlarm(AlertA alert, int count)
        {
            if (alert.Posts <= count)
                alert.Activated = true;
            else
                alert.Activated = false;
        }

    }
}