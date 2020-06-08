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
            return repositoryA.GetEntitiesByPredicate(x => x.Activated);
        }

        public void RemoveAllAlerts()
        {
            repositoryA.ClearAll();
        }

        public void CreateAssociationAlertAuthor(AlertB alert, Author author)
        {
            RepositoryA<AlertBAuthor> repository = new RepositoryA<AlertBAuthor>();
            AlertBAuthor association = FindAssociationAlertAuthor(alert, author);
            if (author != null && association == null)
            {
                association = new AlertBAuthor { AlertB = alert, AlertBId = alert.AlertBId, Author = author, AuthorId = author.AuthorId };
                repository.Add(association);
            }
            

        }

        public AlertBAuthor FindAssociationAlertAuthor(AlertB alert, Author author)
        {
            RepositoryA<AlertBAuthor> repository = new RepositoryA<AlertBAuthor>();
            AlertBAuthor association = repository.Find(x => x.AuthorId == author.AuthorId && x.AlertBId == alert.AlertBId);
            return association;
        }

        public void RemoveAssociationAlertAuthor(AlertB alert)
        {
            RepositoryA<AlertBAuthor> repository = new RepositoryA<AlertBAuthor>();
            ICollection<AlertBAuthor> collection = repository.GetEntitiesByPredicate(x => x.AlertBId == alert.AlertBId);
            foreach(AlertBAuthor item in collection)
            {
                repository.Remove(item);
            }
        }

    }
}
