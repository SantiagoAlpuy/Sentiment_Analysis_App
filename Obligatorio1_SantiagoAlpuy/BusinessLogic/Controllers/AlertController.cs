using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using BusinessLogic.Exceptions;
using BusinessLogic.IControllers;

namespace BusinessLogic.Controllers
{
    public class AlertController : IAlertController
    {
        Repository repository = Repository.Instance;
        private List<Alert> alerts;
        private List<Phrase> phrases;

        public AlertController()
        {
            alerts = repository.Alerts;
            phrases = repository.Phrases;
        }

        public void AddAlert(Alert alert)
        {
            ValidateAlert(alert);
            alerts.Add(alert);
        }

        private void ValidateAlert(Alert alert)
        {
            if (alert == null)
                throw new NullAlertException();
            if (alert.Entity == null)
                throw new NullEntityException();
            else if (alert.Posts < 0)
                throw new NegativePostCountException();
            else if (alert.Days < 0)
                throw new NegativeDayException();
            else if (alert.Hours < 0)
                throw new NegativeHourException();
        }

        public Alert ObtainAlert(Alert alert)
        {
            return alerts.Find(x => x.Equals(alert));
        }

        public void EvaluateAlert()
        {
            DateTime lowerLimitAlert = new DateTime();
            int count;
            foreach (Alert alert in alerts)
            {
                count = 0;
                foreach (Phrase phrase in phrases)
                {
                    if (ValidateEntitiesAndCategories(phrase,alert))
                    {
                        lowerLimitAlert = CalculateLowerLimitAlert(alert);
                        if (IsInsideAlertRange(lowerLimitAlert, phrase))
                        {
                        count++;
                        }
                    }
                }
                ActivateAlarm(alert, count);
            }
            
        }

        private bool ValidateEntitiesAndCategories(Phrase phrase, Alert alert)
        {
            return ValidateEntities(phrase, alert) && ValidateCategories(phrase, alert);
        }

        private bool ValidateEntities(Phrase phrase, Alert alert)
        {
            return phrase.Entity.ToUpper().Trim() == alert.Entity.ToUpper().Trim();
        }

        private bool ValidateCategories(Phrase phrase, Alert alert)
        {
            return phrase.Category.Equals(alert.Category) && !phrase.Category.Equals(CategoryType.Neutro);
        }

        private DateTime CalculateLowerLimitAlert(Alert alert)
        {
            int hours = -(alert.Hours + alert.Days * 24);
            return DateTime.Now.AddHours(hours);
        }

        private bool IsInsideAlertRange(DateTime date, Phrase phrase)
        {
            return date.CompareTo(phrase.Date) < 0;
        }

        private void ActivateAlarm(Alert alert, int count)
        {
            if (alert.Posts <= count)
                alert.Activated = true;
            else
                alert.Activated = false;
        }
    }
}
