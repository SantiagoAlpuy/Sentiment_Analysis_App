using System;
using System.Collections.Generic;
using BusinessLogic.IControllers;

namespace BusinessLogic.Controllers
{
    public class AlertBController : IAlertController
    {
        IPhraseController phraseController;
        RepositoryA<AlertB> repositoryA;

        public AlertBController()
        {
            phraseController = new PhraseController();
            repositoryA = new RepositoryA<AlertB>();

        }

        public void AddAlert(IAlert alert)
        {
            alert.ValidateAlert();
            repositoryA.Add((AlertB)alert);
        }

        public IAlert ObtainAlert(IAlert alert)
        {
            return repositoryA.Find(x => x.Equals(alert));
        }

        public void EvaluateAlerts()
        {
            ICollection<Phrase> phrases = phraseController.GetAllEntities();
            foreach (IAlert alert in repositoryA.GetAll())
            {
                alert.EvaluateAlert((List<Phrase>)phrases);
            }
        }

        public void EvaluateSingleAlert(IAlert alert)
        {
            ICollection<Phrase> phrases = phraseController.GetAllEntities();
            alert.EvaluateAlert((List<Phrase>)phrases);
        }

        public void UpdateAlert(IAlert alert)
        {
            repositoryA.Update((AlertB)alert);
        }

        public ICollection<AlertB> GetAllEntities()
        {
            return repositoryA.GetAll();
        }

    }
}
