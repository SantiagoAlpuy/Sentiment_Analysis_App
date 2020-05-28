using System.Collections.Generic;
using System;
using BusinessLogic.IControllers;

namespace BusinessLogic.Controllers
{
    public class EntityController : IEntityController
    {
        Repository repository = Repository.Instance;
        private List<Entity> entities;

        private const string NULL_ENTITY = "Ingrese una entidad válida.";
        private const string NULL_NAME = "Ingrese un nombre de entidad válida.";
        private const string EMPTY_NAME = "Ingrese un nombre de entidad no vacío.";
        private const string ENTITY_ALREADY_EXISTS = "La entidad '{0}' ya fue ingresada anteriormente.";

        public EntityController()
        {
            entities = repository.Entities;
        }

        public void AddEntity(Entity entity)
        {
            ValidateEntity(entity);
            entities.Add(entity);
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
            return entities.Find(x => x.Name.Trim().ToLower() == entity.Name.Trim().ToLower()) != null;
        }

        public Entity ObtainEntity(string name)
        {
            Entity entity = entities.Find(x => x.Name == name);
            if (entity != null)
                return entity;
            else
                throw new NullReferenceException("");
        }

        public void RemoveEntity(string name)
        {
            entities.Remove(ObtainEntity(name));
        }
    }
}
