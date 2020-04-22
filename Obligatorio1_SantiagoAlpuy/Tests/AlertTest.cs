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
                Category = CategoryType.Positive,
                Posts = 10,
                Time = 12334,
            };

            alert2 = new Alert()
            {
                Entity = null,
                Category = CategoryType.Positive,
                Posts = 10,
                Time = 12334,
            };

            alert3 = new Alert()
            {
                Entity = entity1,
                Category = CategoryType.Positive,
                Posts = -2,
                Time = 12334,
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
            Assert.AreEqual(alert2, repository.ObtainAlert(alert2));
        }

        [TestMethod]
        [ExpectedException(typeof(NegativePostCountException))]
        public void GenerateAlertWithNegativePosts()
        {
            repository.AddAlert(alert3);
            Assert.AreEqual(alert3, repository.ObtainAlert(alert3));
        }
    }
}
