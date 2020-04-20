using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using Exceptions;

namespace Tests
{
    [TestClass]
    public class PhraseTest
    {
        Phrase phrase1;
        Phrase phrase2;
        Phrase phraseWithEmptyComment;
        Phrase nullCommentPhrase;


        [TestInitialize]
        public void Setup()
        {
            DateTime now = DateTime.Now;
            phrase1 = new Phrase()
            {
                Comment = "Me gusta la Pepsi",
                Date = now,
            };

            phrase2 = new Phrase()
            {
                Comment = "Odio la Limol",
                Date = now,
            };

            phraseWithEmptyComment = new Phrase()
            {
                Comment = "",
                Date = now,
            };

            nullCommentPhrase = new Phrase();
        }

        [TestMethod]
        public void RegisterPhrase()
        {
            
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
            register.AddPhrase(phraseWithEmptyComment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullParameterException))]
        public void RegisterPhraseWithNullComment()
        {
            Register register = Register.Instance;
            register.AddPhrase(nullCommentPhrase);
        }

    }
}
