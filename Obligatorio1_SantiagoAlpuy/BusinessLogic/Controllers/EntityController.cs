using System.Collections.Generic;
using System;
using BusinessLogic.IControllers;
using BusinessLogic.DataAccess;

namespace BusinessLogic.Controllers
{
    public class EntityController : IEntityController
    {
        private RepositoryA<Entity> repositoryA;
        private IAlertController alertAController;
        private IAlertController alertBController;
        private IPhraseController phraseController;

        private const string NULL_ENTITY = "Ingrese una entidad válida.";
        private const string NULL_NAME = "Ingrese un nombre de entidad válida.";
        private const string EMPTY_NAME = "Ingrese un nombre de entidad no vacío.";
        private const string ENTITY_ALREADY_EXISTS = "La entidad '{0}' ya fue ingresada anteriormente.";

        public EntityController()
        {
            repositoryA = new RepositoryA<Entity>();
            
        }

        public void AddEntity(Entity entity)
        {
            ValidateEntity(entity);
            repositoryA.Add(entity);
            AnalyzePhrasesAndAlerts();
        }

        private void ValidateEntity(Entity entity)
        {
            if (entity == null)
                throw new NullReferenceException(NULL_ENTITY);
            else if (entity.Name == null)
                throw new NullReferenceException(NULL_NAME);
            else if (entity.Name.Trim() == "")
                throw new ArgumentException(EMPTY_NAME);
            else if (IsEntityInRepo(entity))
                throw new InvalidOperationException(String.Format(ENTITY_ALREADY_EXISTS, entity.Name));
        }

        private bool IsEntityInRepo(Entity entity)
        {
            Entity entity1 = repositoryA.Find(x => x.Name.Trim().ToLower() == entity.Name.Trim().ToLower());
            if (entity1 != null)
                return true;
            else
                return false;
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
                AnalyzePhrasesAndAlerts();
            }
        }

        public void RemoveAllEntities()
        {
            repositoryA.ClearAll();
        }

        private void AnalyzePhrasesAndAlerts()
        {
            phraseController = new PhraseController();
            alertAController = new AlertAController();
            alertBController = new AlertBController();
            phraseController.AnalyzeAllPhrases();
            alertAController.EvaluateAlerts();
            alertBController.EvaluateAlerts();
        }

        public ICollection<Entity> GetAllEntities()
        {
            return repositoryA.GetAll();
        }
    }
}
