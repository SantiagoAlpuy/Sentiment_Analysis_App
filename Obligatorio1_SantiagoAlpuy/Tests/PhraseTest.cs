using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using Exceptions;

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
            Register register = Register.Instance;
            register.AddPhrase(phrase1);
            register.AddPhrase(phrase2);
            Assert.AreEqual(phrase1, register.ObtainPhrase(phrase1.Comment, phrase1.Date));
            Assert.AreEqual(phrase2, register.ObtainPhrase(phrase2.Comment, phrase2.Date));
        }

        [TestMethod]
        [ExpectedException(typeof(NullPhraseException))]
        public void RegisterNullPhrase()
        {
            Register register = Register.Instance;
            register.AddPhrase(null);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterPhraseWithEmptyDescription()
        {
            Register register = Register.Instance;
            Phrase phraseWithEmptyComment = new Phrase()
            {
                Comment = "",
                Date = DateTime.Now,
            };
            register.AddPhrase(phraseWithEmptyComment);
        }
    }
}
