using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class EntityTest
    {
        [TestMethod]
        public void RegisterEntity()
        {
            EntityTest entity1 = new EntityTest()
            {
                Name = "Pepsi",
            };
            EntityTest entity2 = new EntityTest()
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
