using System.Collections.Generic;
using BusinessLogic.DataAccess;
using BusinessLogic.IControllers;
using System.Linq;

namespace BusinessLogic.Controllers
{
    public class AlertBController : IAlertController
    {
        private const string INCLUDED_ALERTB_AUTHORS = "AlertBAuthors";

        IRepository<AlertB> repositoryA;
        FactoryRepository<AlertB> factoryRepository = new FactoryRepository<AlertB>();

        public AlertBController()
        {
            repositoryA = factoryRepository.CreateRepository();
        }

        public void AddAlert(IAlert alert)
        {
            alert.Validate();
            repositoryA.Add((AlertB)alert);
        }

        public AlertB ObtainAlertWithInclude(int id)
        {
            return repositoryA.GetAllWithInclude(INCLUDED_ALERTB_AUTHORS).SingleOrDefault(x => x.AlertBId == id);
        }

        public void EvaluateAlerts()
        {
            foreach (IAlert alert in repositoryA.GetAll())
            {
                EvaluateSingleAlert(alert);
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
            return repositoryA.GetAllWithInclude(INCLUDED_ALERTB_AUTHORS).Where(x => x.Activated).ToList();
        }

        public void RemoveAllAlerts()
        {
            repositoryA.ClearAll();
        }

    }
}
