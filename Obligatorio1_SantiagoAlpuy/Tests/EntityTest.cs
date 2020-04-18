using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace Tests
{
    [TestClass]
    public class EntityTest
    {
        [TestMethod]
        public void RegisterEntity()
        {
            Entity entity1 = new Entity()
            {
                Name = "Pepsi",
            };
            Entity entity2 = new Entity()
            {
                Name = "Limol",
            };
            entity1.AddEntity(entity1);
            entity1.AddEntity(entity2);
            Assert.AreEqual(entity1, entity1.ObtainEntity(entity1.Name));
            Assert.AreEqual(entity2, entity1.ObtainEntity(entity2.Name));
        }
    }
}
