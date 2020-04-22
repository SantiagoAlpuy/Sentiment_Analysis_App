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
        public void GeneratePositiveAlertToEntity()
        {
            Alert positiveAlert = new Alert()
            {
                Entity = entity1,
                Category = CategoryType.Positive,
                Posts = 10,
                Time = 12334,
            };
            Repository repository = Repository.Instance;
            repository.AddAlert(positiveAlert);
            Assert.AreEqual(positiveAlert, repository.ObtainAlert(positiveAlert));
        }
    }
}
