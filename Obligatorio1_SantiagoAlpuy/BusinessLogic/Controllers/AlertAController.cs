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
            phraseController = new PhraseController();
            repositoryA = new RepositoryA<AlertA>();
            
        }

        public void AddAlert(IAlert alert)
        {
            alert.ValidateAlert();
            repositoryA.Add((AlertA) alert);
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
                alert.EvaluateAlert((List<Phrase>) phrases);
            }
        }

        public void EvaluateSingleAlert(IAlert alert)
        {
            ICollection<Phrase> phrases = phraseController.GetAllEntities();
            alert.EvaluateAlert((List<Phrase>)phrases);
        }

        public void UpdateAlert(IAlert alert)
        {
            repositoryA.Update((AlertA) alert);
        }

        public ICollection<AlertA> GetAllEntities()
        {
            return repositoryA.GetAll();
        }
        
    }
}
