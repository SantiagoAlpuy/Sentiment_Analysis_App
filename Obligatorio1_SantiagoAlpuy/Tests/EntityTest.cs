using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace Tests
{
    [TestClass]
    public class EntityTest
    {

        Entity entity1;
        Entity entity2;
        Entity emptyNameEntity;
        Entity nullNameEntity;

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
            emptyNameEntity = new Entity()
            {
                Name = "",
            };
            nullNameEntity = new Entity();
        }

        [TestMethod]
        public void RegisterEntity()
        {
            Repository repository = Repository.Instance;
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
            Repository repository = Repository.Instance;
            repository.addEntity(entity1);
            repository.addEntity(entity1);
            repository.CleanLists();
        }

        [TestMethod]
        [ExpectedException(typeof(EntityDoesNotExistsException))]
        public void RemoveExistantEntityFromRegister()
        {
            Repository repository = Repository.Instance;
            repository.CleanLists();
            repository.addEntity(entity1);
            repository.removeEntity(entity1.Name);
            Entity ent = repository.obtainEntity(entity1.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityDoesNotExistsException))]
        public void RemoveNonExistantEntityFromRegister()
        {
            Repository repository = Repository.Instance;
            repository.CleanLists();
            repository.removeEntity("una entidad que no existe ni existira jamas");
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterEntityWithEmptyDescription()
        {
            Repository repository = Repository.Instance;
            repository.addEntity(emptyNameEntity);
        }

        [TestMethod]
        [ExpectedException(typeof(NullEntityException))]
        public void RegisterNullEntity()
        {
            Repository repository = Repository.Instance;
            repository.addEntity(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAttributeInObjectException))]
        public void RegisterEntityWithNullName()
        {
            Repository repository = Repository.Instance;
            repository.addEntity(nullNameEntity);
        }


    }
}
