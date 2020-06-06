using System;
using System.Collections.Generic;
using BusinessLogic.IControllers;

namespace BusinessLogic.Controllers
{
    public class AlertAController : IAlertController
    {
        IPhraseController phraseController;
        RepositoryA<AlertA> repositoryA;

        public AlertAController()
        {
            repositoryA = new RepositoryA<AlertA>();

        }

        public void AddAlert(IAlert alert)
        {
            alert.ValidateAlert();
            repositoryA.Add((AlertA)alert);
        }

        public AlertA ObtainAlert(int alertAId)
        {
            return repositoryA.Find(x => x.AlertAId.Equals(alertAId));
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
            repositoryA.Update((AlertA)alert);
        }

        public ICollection<AlertA> GetAllAlerts()
        {
            return repositoryA.GetAll();
        }

        public ICollection<AlertA> GetActivatedAlerts()
        {
            return repositoryA.GetEntitiesByPredicate(x => x.Activated);
        }

        public void RemoveAllAlerts()
        {
            repositoryA.ClearAll();
        }

    }
}
