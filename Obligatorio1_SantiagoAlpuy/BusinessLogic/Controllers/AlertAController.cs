using System.Collections.Generic;
using BusinessLogic.DataAccess;
using BusinessLogic.IControllers;

namespace BusinessLogic.Controllers
{
    public class AlertAController : IAlertController
    {
        IRepository<AlertA> repositoryA;
        FactoryRepository<AlertA> factoryRepository = new FactoryRepository<AlertA>();

        public AlertAController()
        {
            repositoryA = factoryRepository.CreateRepository();
        }

        public void AddAlert(IAlert alert)
        {
            alert.Validate();
            repositoryA.Add((AlertA)alert);
        }

        public AlertA ObtainAlert(int alertAId)
        {
            return repositoryA.Find(x => x.AlertAId.Equals(alertAId));
        }

        public void EvaluateAlerts()
        {
            foreach (IAlert alert in repositoryA.GetAll())
            {
                alert.EvaluateAlert();
            }
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
