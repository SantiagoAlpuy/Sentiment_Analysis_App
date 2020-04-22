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

        public AlertController()
        {
            alerts = repository.alerts;
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
            else if (alert.Time < 0)
                throw new NegativeTimeException();
        }

        public Alert ObtainAlert(Alert alert)
        {
            return alerts.Find(x => x.Equals(alert));
        }

        public void CheckAlertsActivation()
        {
            throw new NotImplementedException();
        }
    }
}
