using System.Collections.Generic;
using System;
using System.Linq;
using BusinessLogic;
using BusinessLogic.Exceptions;
using BusinessLogic.IControllers;

namespace BusinessLogic.Controllers
{
    public class EntityController : IEntityController
    {
        Repository repository = Repository.Instance;
        private List<Entity> entities;

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
                throw new NullEntityException();
            else if (entity.Name == null)
                throw new NullAttributeInObjectException();
            else if (entity.Name.Trim() == "")
                throw new LackOfObligatoryParametersException();
            else if (IsEntityInRepo(entity))
                throw new EntityAlreadyExistsException();
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
                throw new EntityDoesNotExistsException();
        }

        public void RemoveEntity(string name)
        {
            entities.Remove(ObtainEntity(name));
        }
    }
}
