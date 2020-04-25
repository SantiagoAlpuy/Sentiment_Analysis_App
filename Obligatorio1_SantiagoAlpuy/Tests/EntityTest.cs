using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Exceptions;
using BusinessLogic.Controllers;

namespace Tests
{
    [TestClass]
    public class EntityTest
    {
        Repository repository;
        EntityController entityController;
        Entity entity1;
        Entity entity2;
        Entity emptyNameEntity;
        Entity nullNameEntity;

        [TestInitialize]
        public void Setup()
        {
            repository = Repository.Instance;
            entityController = new EntityController();

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

        [TestCleanup]
        public void ClassCleanup()
        {
            repository.cleanLists();
        }

        [TestMethod]
        public void RegisterEntity()
        {
            entityController.AddEntity(entity1);
            entityController.AddEntity(entity2);
            Assert.AreEqual(entity1, entityController.ObtainEntity(entity1.Name));
            Assert.AreEqual(entity2, entityController.ObtainEntity(entity2.Name));
        }

        [TestMethod]
        [ExpectedException(typeof(EntityAlreadyExistsException))]
        public void RegisterAlreadyRegisteredEntity()
        {
            entityController.AddEntity(entity1);
            entityController.AddEntity(entity1);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityDoesNotExistsException))]
        public void RemoveExistantEntityFromRegister()
        {
            entityController.AddEntity(entity1);
            entityController.RemoveEntity(entity1.Name);
            Entity ent = entityController.ObtainEntity(entity1.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityDoesNotExistsException))]
        public void RemoveNonExistantEntityFromRegister()
        {
            entityController.RemoveEntity("una entidad que no existe ni existira jamas");
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterEntityWithEmptyDescription()
        {
            entityController.AddEntity(emptyNameEntity);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterEntityWithDescriptionWithOnlyManyBlankSpaces()
        {
            Entity entity = new Entity() { Name = "   " };
            entityController.AddEntity(entity);
        }

        [TestMethod]
        [ExpectedException(typeof(NullEntityException))]
        public void RegisterNullEntity()
        {
            entityController.AddEntity(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAttributeInObjectException))]
        public void RegisterEntityWithNullName()
        {
            entityController.AddEntity(nullNameEntity);
        }


    }
}
