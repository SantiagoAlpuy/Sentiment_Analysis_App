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
            throw new NotImplementedException();
        }
    }
}
