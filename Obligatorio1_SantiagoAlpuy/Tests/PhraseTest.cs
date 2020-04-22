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
            repository.addPhrase(phrase1);
            repository.addPhrase(phrase2);
            Assert.AreEqual(phrase1, repository.obtainPhrase(phrase1.Comment, phrase1.Date));
            Assert.AreEqual(phrase2, repository.obtainPhrase(phrase2.Comment, phrase2.Date));
        }

        [TestMethod]
        [ExpectedException(typeof(NullPhraseException))]
        public void RegisterNullPhrase()
        {
            Repository repository = Repository.Instance;
            repository.addPhrase(null);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterPhraseWithEmptyDescription()
        {
            Repository repository = Repository.Instance;
            repository.addPhrase(phraseWithEmptyComment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullAttributeInObjectException))]
        public void RegisterPhraseWithNullComment()
        {
            Repository repository = Repository.Instance;
            repository.addPhrase(nullCommentPhrase);
        }


        [TestMethod]
        public void AnalyzePhraseWithNoRegisteredEntity()
        {
            Entity entity = new Entity()
            {
                Name = "Coca",
            };
            analizePhrase(phrase1, entity);
            Assert.AreEqual("", phrase1.Entity);
        }

        [TestMethod]
        public void ObtainTheOnlyEntityFromPhrase()
        {
            Entity entity = new Entity()
            {
                Name = "Pepsi",
            };
            analizePhrase(phrase1, entity);
            Assert.AreEqual("Pepsi", phrase1.Entity);
        }


        private void analizePhrase(Phrase phrase1, Entity entity)
        {
            if (phrase1.Comment.Contains(entity.Name))
                phrase1.Entity = entity.Name;
        }

        

    }
}
