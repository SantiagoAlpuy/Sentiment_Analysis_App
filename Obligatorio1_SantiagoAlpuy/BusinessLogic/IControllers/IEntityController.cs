using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.IControllers
{
    public interface IEntityController
    {
        void AddEntity(Entity entity);

        Entity ObtainEntity(string name);

        void RemoveEntity(string name);

    }
}
