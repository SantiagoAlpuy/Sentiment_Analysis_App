﻿using BusinessLogic.DataAccess;
using System.Collections.Generic;

namespace BusinessLogic.Controllers
{
    public class AlertBAuthorRelationController
    {

        RepositoryA<AlertBAuthor> repository;

        public AlertBAuthorRelationController()
        {
            repository = new RepositoryA<AlertBAuthor>();
        }

        public void AddAssociationAlertAuthor(AlertB alert, Author author)
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
            AlertBAuthor association = repository.Find(x => x.AuthorId == author.AuthorId && x.AlertBId == alert.AlertBId);
            return association;
        }

        public void RemoveAssociationAlertAuthor(AlertB alert)
        {
            ICollection<AlertBAuthor> collection = repository.GetEntitiesByPredicate(x => x.AlertBId == alert.AlertBId);
            foreach (AlertBAuthor item in collection)
            {
                repository.Remove(item);
            }
        }

        public ICollection<AlertBAuthor> GetAllRelationsByAlertId(int alertBId)
        {
            ICollection<AlertBAuthor> collection = repository.GetEntitiesByPredicate(x => x.AlertBId == alertBId);
            return collection;
        }

    }
}
