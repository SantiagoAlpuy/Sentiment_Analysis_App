using System;
using System.Collections.Generic;
using BusinessLogic.IControllers;

namespace BusinessLogic.Controllers
{
    public class AlertController : IAlertController
    {
        Repository repository = Repository.Instance;
        private List<IAlert> alerts;
        private List<Phrase> phrases;

        public AlertController()
        {
            alerts = repository.Alerts;
            phrases = repository.Phrases;
        }

        public void AddAlert(IAlert alert)
        {
            alert.ValidateAlert();
            alerts.Add(alert);
        }        

        public IAlert ObtainAlert(IAlert alert)
        {
            return alerts.Find(x => x.Equals(alert));
        }

        public void EvaluateAlerts()
        {
            foreach (IAlert alert in alerts)
            {
                alert.EvaluateAlert(phrases);
            }
            
        }
        
    }
}
