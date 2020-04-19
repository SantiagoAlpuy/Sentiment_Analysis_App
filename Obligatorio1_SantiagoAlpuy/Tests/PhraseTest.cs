using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PhraseTest
    {
        [TestMethod]
        public void RegisterPhrase()
        {
            Phrase phrase1 = new Phrase()
            {
                Comment = "Me gusta la Pepsi",
                Date = "01/12/2001",
            };
            Phrase phrase2 = new Phrase()
            {
                Comment = "Odio la Limol",
                Date = "01/01/2000",
            };
            phrase1.AddPhrase(phrase1);
            phrase1.AddPhrase(phrase2);
            Assert.AreEqual(phrase1, phrase1.ObtainPhrase(phrase1.Comment, phrase1.Date));
            Assert.AreEqual(phrase2, phrase1.ObtainPhrase(phrase2.Comment, phrase2.Date));
        }
    }
}
