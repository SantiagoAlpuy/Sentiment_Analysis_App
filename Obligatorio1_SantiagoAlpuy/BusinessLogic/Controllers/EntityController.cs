using System.Collections.Generic;
using System;
using BusinessLogic.IControllers;
using BusinessLogic.DataAccess;

namespace BusinessLogic.Controllers
{
    public class EntityController : IEntityController
    {
        IRepository<Entity> repositoryA;
        FactoryRepository<Entity> factoryRepository = new FactoryRepository<Entity>();

        private const string NULL_ENTITY = "Ingrese una entidad válida.";
        
        public EntityController()
        {
            repositoryA = factoryRepository.CreateRepository();
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
            return entity;

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
            AlertAController alertAController = new AlertAController();
            alertAController.EvaluateAlerts();
        }

        private void AnalyzePhrases()
        {
            PhraseController phraseController = new PhraseController();
            phraseController.AnalyzeAllPhrases();
        }

        public ICollection<Entity> GetAllEntities()
        {
            return repositoryA.GetAll();
        }
    }
}
