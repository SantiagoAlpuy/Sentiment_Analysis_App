using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace Tests
{
    [TestClass]
    public class EntityTest
    {
        Repository repository;
        Entity entity1;
        Entity entity2;
        Entity emptyNameEntity;
        Entity nullNameEntity;

        [TestInitialize]
        public void Setup()
        {
            repository = Repository.Instance;

            entity1 = new Entity()
            {
                Name = "Pepsi",
            };
            entity2 = new Entity()
            {
                Name = "Limol",
            };
            emptyNameEntity = new Entity()
            {
                Name = "",
            };
            nullNameEntity = new Entity();
        }

        [TestMethod]
        public void RegisterEntity()
        {
            repository.addEntity(entity1);
            repository.addEntity(entity2);
            Assert.AreEqual(entity1, repository.obtainEntity(entity1.Name));
            Assert.AreEqual(entity2, repository.obtainEntity(entity2.Name));
            repository.CleanLists();
        }

        [TestMethod]
        [ExpectedException(typeof(EntityAlreadyExistsException))]
        public void RegisterAlreadyRegisteredEntity()
        {
            repository.addEntity(entity1);
            repository.addEntity(entity1);
            repository.CleanLists();
        }

        [TestMethod]
        [ExpectedException(typeof(EntityDoesNotExistsException))]
        public void RemoveExistantEntityFromRegister()
        {
            repository.CleanLists();
            repository.addEntity(entity1);
            repository.removeEntity(entity1.Name);
            Entity ent = repository.obtainEntity(entity1.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityDoesNotExistsException))]
        public void RemoveNonExistantEntityFromRegister()
        {
            repository.CleanLists();
            repository.removeEntity("una entidad que no existe ni existira jamas");
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterEntityWithEmptyDescription()
        {
            repository.addEntity(emptyNameEntity);
        }

        [TestMethod]
        [ExpectedException(typeof(NullEntityException))]
        public void RegisterNullEntity()
        {
            repository.addEntity(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAttributeInObjectException))]
        public void RegisterEntityWithNullName()
        {
            repository.addEntity(nullNameEntity);
        }


    }
}
