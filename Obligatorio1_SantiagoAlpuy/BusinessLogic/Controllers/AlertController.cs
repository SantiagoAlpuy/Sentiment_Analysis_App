using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Controllers
{
    public class AlertController
    {
        Repository repository = Repository.Instance;
        private List<Alert> alerts;
        private List<Phrase> phrases;

        public AlertController()
        {
            alerts = repository.alerts;
            phrases = repository.phrases;
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

        public void CheckAlertActivation()
        {
            DateTime now = DateTime.Now;
            DateTime lowerLimitAlert = new DateTime();
            int count;
            foreach (Alert alert in alerts)
            {
                count = 0;
                foreach (Phrase phrase in phrases)
                {
                    if (phrase.Entity == alert.Entity)
                    {
                        if (phrase.Category.Equals(alert.Category))
                        {
                            lowerLimitAlert = now.AddHours(-(alert.Hours + alert.Days * 24));
                            if (lowerLimitAlert.CompareTo(phrase.Date) < 0)
                            {
                                count++;
                            }
                        }
                    }
                }
                if (alert.Posts == count)
                {
                    alert.Activated = true;
                }
            }
            
        }
    }
}
