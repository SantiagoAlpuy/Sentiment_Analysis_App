using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace Tests
{
    [TestClass]
    public class AlertTest
    {
        Entity entity1;

        [TestInitialize]
        public void Setup()
        {
            entity1 = new Entity()
            {
                Name = "Pepsi",
            };
        }

        [TestMethod]
        public void GenerateAlertToEntity()
        {
            Alert alert = new Alert()
            {
                Entity = entity1,
                Category = CategoryType.Positive,
                Posts = 10,
                Time = 12334,
            };
            Repository repository = Repository.Instance;
            repository.AddAlert(alert);
            Assert.AreEqual(alert, repository.ObtainAlert(alert));
        }
    }
}
