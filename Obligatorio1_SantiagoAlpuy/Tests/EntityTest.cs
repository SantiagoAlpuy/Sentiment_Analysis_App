using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;
using System;

namespace Tests
{
    [TestClass]
    public class EntityTest
    {
        IEntityController entityController;

        [TestInitialize]
        public void Setup()
        {
            entityController = new EntityController();
            entityController.RemoveAllEntities();
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            entityController.RemoveAllEntities();
        }

        [TestMethod]
        public void RegisterEntity()
        {
            Entity entity1 = new Entity() { Name = "Pepsi" };
            Entity entity2 = new Entity() { Name = "Limol" };
            entityController.AddEntity(entity1);
            entityController.AddEntity(entity2);
            Entity entity3 = entityController.ObtainEntity(entity1.Name);
            Entity entity4 = entityController.ObtainEntity(entity2.Name);
            Assert.AreEqual(entity1.EntityId, entity3.EntityId);
            Assert.AreEqual(entity2.EntityId, entity4.EntityId);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterAlreadyRegisteredEntity()
        {
            Entity entity1 = new Entity() { Name = "Pepsi" };
            Entity entity2 = new Entity() { Name = "Pepsi" };
            entityController.AddEntity(entity1);
            entityController.AddEntity(entity2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterEntityWithDescriptionWithBlankSpacesInBetween()
        {
            Entity entity1 = new Entity() { Name = "pepsi" };
            Entity entity2 = new Entity() { Name = "  pepsi  " };
            entityController.AddEntity(entity1);
            entityController.AddEntity(entity2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterAlreadyRegisteredEntityWithDifferentMayusMinusFormat()
        {
            Entity entity1 = new Entity() { Name = "PepSI" };
            Entity entity2 = new Entity() { Name = "pepsi" };
            entityController.AddEntity(entity1);
            entityController.AddEntity(entity2);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RemoveExistantEntityFromRegister()
        {
            Entity entity = new Entity() { Name = "Pepsi" };
            entityController.AddEntity(entity);
            entityController.RemoveEntity(entity.Name);
            Entity ent = entityController.ObtainEntity(entity.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RemoveNonExistantEntityFromRegister()
        {
            entityController.RemoveEntity("una entidad que no existe ni existira jamas");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterEntityWithEmptyDescription()
        {
            Entity entity = new Entity() { Name = "" };
            entityController.AddEntity(entity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterEntityWithDescriptionWithOnlyManyBlankSpaces()
        {
            Entity entity = new Entity() { Name = "   " };
            entityController.AddEntity(entity);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RegisterNullEntity()
        {
            entityController.AddEntity(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RegisterEntityWithNullName()
        {
            Entity entity = new Entity();
            entityController.AddEntity(entity);
        }


    }
}
