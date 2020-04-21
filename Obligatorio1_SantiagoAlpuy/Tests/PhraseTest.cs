using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Exceptions;

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
            
            Repository repository = Repository.Instance;
            repository.AddPhrase(phrase1);
            repository.AddPhrase(phrase2);
            Assert.AreEqual(phrase1, repository.ObtainPhrase(phrase1.Comment, phrase1.Date));
            Assert.AreEqual(phrase2, repository.ObtainPhrase(phrase2.Comment, phrase2.Date));
        }

        [TestMethod]
        [ExpectedException(typeof(NullPhraseException))]
        public void RegisterNullPhrase()
        {
            Repository repository = Repository.Instance;
            repository.AddPhrase(null);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterPhraseWithEmptyDescription()
        {
            Repository repository = Repository.Instance;
            repository.AddPhrase(phraseWithEmptyComment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAttributeInObjectException))]
        public void RegisterPhraseWithNullComment()
        {
            Repository repository = Repository.Instance;
            repository.AddPhrase(nullCommentPhrase);
        }

    }
}
