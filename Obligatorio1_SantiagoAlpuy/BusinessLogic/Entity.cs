using BusinessLogic.DataAccess;
using System;

namespace BusinessLogic
{
    public class Entity
    {

        private const string NULL_NAME = "Ingrese un nombre de entidad válida.";
        private const string EMPTY_NAME = "Ingrese un nombre de entidad no vacío.";
        private const string ENTITY_ALREADY_EXISTS = "La entidad '{0}' ya fue ingresada anteriormente.";

        public int EntityId { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            if (this.Name == null)
                throw new NullReferenceException(NULL_NAME);
            else if (this.Name.Trim() == "")
                throw new ArgumentException(EMPTY_NAME);
            else if (IsEntityInRepo(this))
                throw new InvalidOperationException(String.Format(ENTITY_ALREADY_EXISTS, this.Name));
        }

        private bool IsEntityInRepo(Entity entity)
        {
            RepositoryA<Entity> repositoryA = new RepositoryA<Entity>();
            Entity entity1 = repositoryA.Find(x => x.Name.Trim().ToLower() == entity.Name.Trim().ToLower());
            return entity1 != null;
        }
    }
}