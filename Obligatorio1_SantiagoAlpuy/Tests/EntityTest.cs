using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using Exceptions;

namespace Tests
{
    [TestClass]
    public class EntityTest
    {

        Entity entity1;
        Entity entity2;

        [TestInitialize]
        public void Setup()
        {
            entity1 = new Entity()
            {
                Name = "Pepsi",
            };
            entity2 = new Entity()
            {
                Name = "Limol",
            };
        }

        [TestMethod]
        public void RegisterEntity()
        {
            Register register = Register.Instance;
            register.AddEntity(entity1);
            register.AddEntity(entity2);
            Assert.AreEqual(entity1, register.ObtainEntity(entity1.Name));
            Assert.AreEqual(entity2, register.ObtainEntity(entity2.Name));
            register.CleanLists();
        }

        [TestMethod]
        [ExpectedException(typeof(EntityAlreadyExistsException))]
        public void RegisterAlreadyRegisteredEntity()
        {
            Register register = Register.Instance;
            register.AddEntity(entity1);
            register.AddEntity(entity1);
            register.CleanLists();
        }

        [TestMethod]
        [ExpectedException(typeof(EntityDoesNotExistsException))]
        public void RemoveExistantEntityFromRegister()
        {
            Register register = Register.Instance;
            register.CleanLists();
            register.AddEntity(entity1);
            register.RemoveEntity(entity1.Name);
            Entity ent = register.ObtainEntity(entity1.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityDoesNotExistsException))]
        public void RemoveNonExistantEntityFromRegister()
        {
            Register register = Register.Instance;
            register.CleanLists();
            register.RemoveEntity("una entidad que no existe ni existira jamas");
        }


    }
}
