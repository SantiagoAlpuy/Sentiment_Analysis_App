using System.Collections.Generic;

namespace BusinessLogic.IControllers
{
    public interface IEntityController
    {
        void AddEntity(Entity entity);
        Entity ObtainEntity(string name);
        void RemoveEntity(string name);
        ICollection<Entity> GetAllEntities();
        void RemoveAllEntities();

    }
}
