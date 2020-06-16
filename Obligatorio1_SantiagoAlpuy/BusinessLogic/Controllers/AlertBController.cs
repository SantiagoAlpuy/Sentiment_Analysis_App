using System;
using System.Collections.Generic;
using BusinessLogic.DataAccess;
using BusinessLogic.IControllers;
using System.Linq;

namespace BusinessLogic.Controllers
{
    public class AlertBController : IAlertController
    {
        RepositoryA<AlertB> repositoryA;

        public AlertBController()
        {
            repositoryA = new RepositoryA<AlertB>();
        }

        public void AddAlert(IAlert alert)
        {
            alert.Validate();
            repositoryA.Add((AlertB)alert);
        }

        public AlertB ObtainAlert(int alertAId)
        {
            return repositoryA.Find(x => x.AlertBId.Equals(alertAId));
        }

        public void EvaluateAlerts()
        {
            foreach (IAlert alert in repositoryA.GetAll())
            {
                alert.EvaluateAlert();
            }
        }

        public void EvaluateSingleAlert(IAlert alert)
        {
            alert.EvaluateAlert();
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
            return repositoryA.GetAllWithInclude("AlertBAuthors").Where(x => x.Activated).ToList();
        }

        public void RemoveAllAlerts()
        {
            repositoryA.ClearAll();
        }

    }
}
