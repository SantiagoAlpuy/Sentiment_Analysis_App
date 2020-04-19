using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace Tests
{
    [TestClass]
    public class PhraseTest
    {
        [TestMethod]
        public void RegisterPhrase()
        {
            DateTime now = DateTime.Now;
            Phrase phrase1 = new Phrase()
            {
                Comment = "Me gusta la Pepsi",
                Date = now,
            };
            Phrase phrase2 = new Phrase()
            {
                Comment = "Odio la Limol",
                Date = now,
            };
            Register register = new Register();
            register.AddPhrase(phrase1);
            register.AddPhrase(phrase2);
            Assert.AreEqual(phrase1, register.ObtainPhrase(phrase1.Comment, phrase1.Date));
            Assert.AreEqual(phrase2, register.ObtainPhrase(phrase2.Comment, phrase2.Date));
        }
    }
}
