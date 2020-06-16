using System.Collections.Generic;
using System;
using BusinessLogic.IControllers;
using BusinessLogic.DataAccess;

namespace BusinessLogic.Controllers
{
    public class EntityController : IEntityController
    {
        private RepositoryA<Entity> repositoryA;

        private const string NULL_ENTITY = "Ingrese una entidad válida.";
        
        public EntityController()
        {
            repositoryA = new RepositoryA<Entity>();
        }

        public void AddEntity(Entity entity)
        {
            ValidateEntity(entity);
            repositoryA.Add(entity);
            AnalyzePhrases();
            AnalyzeAlerts();
        }

        private void ValidateEntity(Entity entity)
        {
            if (entity == null)
                throw new NullReferenceException(NULL_ENTITY);
            else entity.Validate();
        }

        public Entity ObtainEntity(string name)
        {
            Entity entity = repositoryA.Find(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
            if (entity != null)
                return entity;
            else
                throw new NullReferenceException("");
        }

        public void RemoveEntity(string name)
        {
            Entity entity = ObtainEntity(name);
            if (entity != null)
            {
                repositoryA.Remove(entity);
                AnalyzePhrases();
                AnalyzeAlerts();
            }
        }

        public void RemoveAllEntities()
        {
            repositoryA.ClearAll();
        }

        private void AnalyzeAlerts()
        {
            IAlertController alertAController = new AlertAController();
            IAlertController alertBController = new AlertBController();
            alertAController.EvaluateAlerts();
        }

        private void AnalyzePhrases()
        {
            IPhraseController phraseController = new PhraseController();
            phraseController.AnalyzeAllPhrases();
        }

        public ICollection<Entity> GetAllEntities()
        {
            return repositoryA.GetAll();
        }
    }
}
