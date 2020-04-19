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

            Register register = new Register();
            register.AddEntity(entity1);
            register.AddEntity(entity2);
            Assert.AreEqual(entity1, register.ObtainEntity(entity1.Name));
            Assert.AreEqual(entity2, register.ObtainEntity(entity2.Name));
        }
    }
}
