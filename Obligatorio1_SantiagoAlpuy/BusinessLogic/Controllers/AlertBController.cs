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
            phraseController = new PhraseController();
            ICollection<Phrase> phrases = phraseController.GetAllEntities();
            foreach (IAlert alert in repositoryA.GetAll())
            {
                alert.EvaluateAlert((List<Phrase>)phrases);
            }
        }

        public void EvaluateSingleAlert(IAlert alert)
        {
            phraseController = new PhraseController();
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
