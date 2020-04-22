using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace Tests
{
    [TestClass]
    public class AlertTest
    {
        Repository repository = Repository.Instance;

        Entity entity1;
        Alert alert1;
        Alert alert2;
        Alert alert3;
        Alert alert4;

        [TestInitialize]
        public void Setup()
        {
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

        [TestMethod]
        public void GenerateAlertToEntity()
        {
            repository.AddAlert(alert1);
            Assert.AreEqual(alert1, repository.ObtainAlert(alert1));
        }

        [TestMethod]
        [ExpectedException(typeof(NullEntityException))]
        public void GenerateAlertWithNullEntity()
        {
            repository.AddAlert(alert2);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativePostCountException))]
        public void GenerateAlertWithNegativePosts()
        {
            repository.AddAlert(alert3);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeTimeException))]
        public void GenerateAlertWithNegativeTime()
        {
            repository.AddAlert(alert4);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAlertException))]
        public void AddNullAlertToRepository()
        {
            repository.AddAlert(null);
        }
    }
}
