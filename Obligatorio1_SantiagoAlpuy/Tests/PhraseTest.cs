using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class PhraseTest
    {

        ISentimentController sentimentController;
        IPhraseController phraseController;
        IEntityController entityController;
        IAuthorController authorController;


        [TestInitialize]
        public void Setup()
        {
            InitializeControllers();
            ClearDatabase();


        }

        [TestCleanup]
        public void ClassCleanup()
        {
            ClearDatabase();
        }

        private void InitializeControllers()
        {
            sentimentController = new SentimentController();
            phraseController = new PhraseController();
            entityController = new EntityController();
            authorController = new AuthorController();
        }

        private void ClearDatabase()
        {
            sentimentController.RemoveAllSentiments();
            phraseController.RemoveAllPhrases();
            entityController.RemoveAllEntities();
            authorController.RemoveAllAuthors();
        }

        [TestMethod]
        public void RegisterPhrase()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Phrase phrase1 = new Phrase() { Comment = "Me gusta la Pepsi", Date = DateTime.Now, Author = author };
            Phrase phrase2 = new Phrase() { Comment = "Odio la Limol", Date = DateTime.Now, Author = author };
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase1);
            phraseController.AddPhrase(phrase2);
            Phrase phrase3 = phraseController.ObtainPhrase(phrase1.PhraseId);
            Phrase phrase4 = phraseController.ObtainPhrase(phrase2.PhraseId);
            Assert.AreEqual(phrase1.PhraseId, phrase3.PhraseId);
            Assert.AreEqual(phrase2.PhraseId, phrase4.PhraseId);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RegisterNullPhrase()
        {
            phraseController.AddPhrase(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterPhraseWithEmptyComment()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Phrase phrase = new Phrase() { Comment = "", Date = DateTime.Now, Author = author };
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterPhraseWhoseCommentHasManyBlankSpaces()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Phrase phrase = new Phrase() { Comment = "   ", Date = DateTime.Now, Author = author };
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RegisterPhraseWithNullComment()
        {
            Phrase phrase = new Phrase();
            phraseController.AddPhrase(phrase);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterPhraseWithDateOlderThanOneYear()
        {
            Phrase phrase = new Phrase() { Comment = "Frase con fecha inferior a un año", Date = new DateTime(2019, 01, 01) };
            phraseController.AddPhrase(phrase);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterPhraseWithDateFromFuture()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Phrase phrase = new Phrase() { Comment = "Frase con fecha del futuro", Date = new DateTime(2025, 01, 1), Author = author };
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithNoRegisteredEntityInEntitiesList()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Phrase phrase = new Phrase() { Comment = "Me gusta la Pepsi", Date = DateTime.Now, Author = author };
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            Assert.AreEqual("", phrase.Entity);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithOnlyOneEntityInEntitiesList()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Phrase phrase = new Phrase() { Comment = "Me gusta la Pepsi", Date = DateTime.Now, Author = author };
            Entity entity = new Entity()  { Name = "Pepsi" };
            entityController.AddEntity(entity);
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            Assert.AreEqual("Pepsi", phrase.Entity);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithMultipleDifferentEntities()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Entity entity1 = new Entity() { Name = "Pepsi" };
            Entity entity2 = new Entity() { Name = "Coca" };
            Entity entity3 = new Entity() { Name = "Nix" };
            entityController.AddEntity(entity1);
            entityController.AddEntity(entity2);
            entityController.AddEntity(entity3);
            Phrase phrase = new Phrase() { Comment = "Me gusta la Pepsi la Coca y la Nix", Date = DateTime.Now, Author = author };
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            Assert.AreEqual("Pepsi", phrase.Entity);
        }

        [TestMethod]
        public void AnalyzeEntityOfPhraseWithDifferentUpperAndLowerLettersFormat()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Entity entity = new Entity() { Name = "Pepsi" };
            Phrase phrase = new Phrase() { Comment = "mE GUsTa La pEPsI", Date = DateTime.Now, Author = author };
            entityController.AddEntity(entity);
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            Assert.AreEqual("Pepsi", phrase.Entity);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithNoSentiments()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Phrase phrase = new Phrase() { Comment = "Mike Tyson", Date = DateTime.Now, Author= author};
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            Assert.AreEqual(CategoryType.Neutro, phrase.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithOnePositiveSentiment()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Sentiment sentiment = new Sentiment() { Description = "Me gusta", Category = true };
            Phrase phrase = new Phrase() { Comment = "Me gusta la Pepsi",  Date = DateTime.Now, Author = author };
            sentimentController.AddSentiment(sentiment);
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            Assert.AreEqual(CategoryType.Positiva, phrase.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithOneNegativeSentiment()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Sentiment sentiment = new Sentiment() { Description = "Odio", Category = false };
            Phrase phrase = new Phrase() { Comment = "Odio la Limol", Date = DateTime.Now, Author = author };
            sentimentController.AddSentiment(sentiment);
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            Assert.AreEqual(CategoryType.Negativa, phrase.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithMultipleNegativeAndPositiveSentiments()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Sentiment sentiment1 = new Sentiment() { Description = "Me gusta", Category = true };
            Sentiment sentiment2 = new Sentiment() { Description = "Me encanta", Category = true };
            Sentiment sentiment3 = new Sentiment() { Description = "detesto", Category = false };
            Sentiment sentiment4 = new Sentiment() { Description = "Odio", Category = false };
            sentimentController.AddSentiment(sentiment1);
            sentimentController.AddSentiment(sentiment2);
            sentimentController.AddSentiment(sentiment3);
            sentimentController.AddSentiment(sentiment4);
            Phrase phrase = new Phrase() { Comment = "Me gusta, Me encanta la Coca pero Odio la Nix y la detesto", Date= DateTime.Now, Author = author };
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            Assert.AreEqual(CategoryType.Neutro, phrase.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithDifferentUpperAndLowerLettersFormatPositiveSentiment()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Sentiment sentiment = new Sentiment() { Description = "Me gusta", Category = true };
            Phrase phrase = new Phrase() { Comment = "mE GUsTa La pEPsI", Date = DateTime.Now, Author = author };
            sentimentController.AddSentiment(sentiment);
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            Assert.AreEqual(CategoryType.Positiva, phrase.Category);
        }

        [TestMethod]
        public void AnalyzeCategoryOfPhraseWithDifferentUpperAndLowerLettersFormatNegativeSentiment()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Sentiment sentiment = new Sentiment() { Description = "Odio", Category = false };
            Phrase phrase = new Phrase() { Comment = "oDIo la guaRaNA", Date = DateTime.Now, Author = author };
            sentimentController.AddSentiment(sentiment);
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            Assert.AreEqual(CategoryType.Negativa, phrase.Category);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterPhraseWithoutAuthor()
        {
            
            Phrase phrase = new Phrase() { Comment = "me gusta la hamburguesa", Date = DateTime.Now };
            phraseController.AddPhrase(phrase);
        }

        [TestMethod]
        public void GetAllPhrasesWithAuthorAsInclude()
        {
            Author author = new Author() { Username = "testUser", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Phrase phrase = new Phrase() { Comment = "me gusta la hamburguesa", Date = DateTime.Now, Author = author };
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase);
            ICollection<Phrase> phrases = phraseController.GetAllEntitiesWithIncludes("Author");
            Assert.AreEqual(1, phrases.Count);
            Assert.AreEqual(phrases.FirstOrDefault().PhraseId, phrase.PhraseId);
        }

    }
}
