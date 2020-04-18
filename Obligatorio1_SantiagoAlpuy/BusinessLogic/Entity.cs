using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Entity
    {

        public string Name { get; set; }

        public List<Entity> entities;

        public Entity()
        {
            entities = new List<Entity>();
        }

        public void AddEntity(Entity entity1)
        {
            entities.Add(entity1);
        }

        public Entity ObtainEntity(string name)
        {
            return entities.Find(x => x.Name == name);
        }
    }
}