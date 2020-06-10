using System;
using System.Collections.Generic;
using BusinessLogic.DataAccess;
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

        public AlertB ObtainAlert(int alertAId)
        {
            return repositoryA.Find(x => x.AlertBId.Equals(alertAId));
        }

        public void EvaluateAlerts()
        {
            phraseController = new PhraseController();
            ICollection<Phrase> phrases = phraseController.GetAllEntitiesWithIncludes("Author");
            foreach (IAlert alert in repositoryA.GetAll())
            {
                alert.EvaluateAlert((List<Phrase>)phrases);
            }
        }

        public void EvaluateSingleAlert(IAlert alert)
        {
            phraseController = new PhraseController();
            ICollection<Phrase> phrases = phraseController.GetAllEntitiesWithIncludes("Author");
            alert.EvaluateAlert((List<Phrase>)phrases);
        }

        public void UpdateAlert(IAlert alert)
        {
            repositoryA.Update((AlertB)alert);
        }

        public ICollection<AlertB> GetAllAlerts()
        {
            return repositoryA.GetAll();
        }

        public ICollection<AlertB> GetActivatedAlerts()
        {
            ;
            return repositoryA.GetAllWithInclude("AlertBAuthors");
        }

        public void RemoveAllAlerts()
        {
            repositoryA.ClearAll();
        }

    }
}
