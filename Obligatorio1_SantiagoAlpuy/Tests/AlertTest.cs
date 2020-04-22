using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Exceptions;
using BusinessLogic.Controllers;

namespace Tests
{
    [TestClass]
    public class AlertTest
    {
        Repository repository;
        AlertController alertController;
        Entity entity1;
        Alert alert1;
        Alert alert2;
        Alert alert3;
        Alert alert4;

        [TestInitialize]
        public void Setup()
        {
            repository = Repository.Instance;
            alertController = new AlertController();

            entity1 = new Entity()
            {
                Name = "Pepsi",
            };

            alert1 = new Alert()
            {
                Entity = entity1,
                Category = true,
                Posts = 10,
                Time = 12334,
            };

            alert2 = new Alert()
            {
                Entity = null,
                Category = true,
                Posts = 10,
                Time = 12334,
            };

            alert3 = new Alert()
            {
                Entity = entity1,
                Category = true,
                Posts = -2,
                Time = 12334,
            };

            alert4 = new Alert()
            {
                Entity = entity1,
                Category = true,
                Posts = 2,
                Time = -34,
            };
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            repository.cleanLists();
        }

        [TestMethod]
        public void GenerateAlertToEntity()
        {
            alertController.AddAlert(alert1);
            Assert.AreEqual(alert1, alertController.ObtainAlert(alert1));
        }

        [TestMethod]
        [ExpectedException(typeof(NullEntityException))]
        public void GenerateAlertWithNullEntity()
        {
            alertController.AddAlert(alert2);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativePostCountException))]
        public void GenerateAlertWithNegativePosts()
        {
            alertController.AddAlert(alert3);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeTimeException))]
        public void GenerateAlertWithNegativeTime()
        {
            alertController.AddAlert(alert4);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAlertException))]
        public void AddNullAlertToRepository()
        {
            alertController.AddAlert(null);
        }
    }
}
