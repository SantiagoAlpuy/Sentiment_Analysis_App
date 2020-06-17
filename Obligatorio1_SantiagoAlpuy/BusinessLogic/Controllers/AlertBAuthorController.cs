using BusinessLogic.DataAccess;
using System.Collections.Generic;

namespace BusinessLogic.Controllers
{
    public class AlertBAuthorController
    {

        IRepository<AlertBAuthor> repository;
        FactoryRepository<AlertBAuthor> factoryRepository = new FactoryRepository<AlertBAuthor>();

        public AlertBAuthorController()
        {
            repository = factoryRepository.CreateRepository();
        }

        public void AddAssociationAlertAuthor(AlertB alert, Author author)
        {
            AlertBAuthor association = FindAssociationAlertAuthor(alert, author);
            AlertBController alertController = new AlertBController();
            AuthorController authorController = new AuthorController();
            alert = alertController.ObtainAlertWithInclude(alert.AlertBId);
            author = authorController.GetAuthorByIdWithInclude(author.AuthorId, "AlertBAuthors");
            if (author != null && association == null)
            {
                AlertBAuthor alertAuthor = new AlertBAuthor { AlertB = alert, Author = author, AlertBId = alert.AlertBId, AuthorId = author.AuthorId };
                alert.AlertBAuthors.Add(alertAuthor);
                repository.Add(alertAuthor);
            }
        }

        public AlertBAuthor FindAssociationAlertAuthor(AlertB alert, Author author)
        {
            AlertBAuthor association = repository.Find(x => x.AuthorId == author.AuthorId && x.AlertBId == alert.AlertBId);
            return association;
        }

        public void RemoveAssociationAlertAuthor(AlertB alert, Author author)
        {
            AlertBAuthor alertAuthor = FindAssociationAlertAuthor(alert, author);
            if (alertAuthor != null)
                repository.Remove(alertAuthor);
        }

        public ICollection<AlertBAuthor> GetAllRelationsByAlertId(int alertBId)
        {
            ICollection<AlertBAuthor> collection = repository.GetEntitiesByPredicate(x => x.AlertBId == alertBId);
            return collection;
        }

        public void RemoveAll()
        {
            repository.ClearAll();
        }

    }
}
