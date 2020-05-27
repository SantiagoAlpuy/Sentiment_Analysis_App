using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusinessLogic;
using BusinessLogic.Exceptions;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;


namespace Tests
{
    [TestClass]
    public class AuthorTest
    {
        Repository repository = Repository.Instance;
        IAuthorController authorController = new AuthorController();


        [TestCleanup]
        public void ClassCleanup()
        {
            repository.CleanLists();
        }

        [TestMethod]
        public void RegisterAuthors()
        {
            Author author1 = new Author() { Username = "testUser1", Name = "nameA", Surname= "surnameA", Born= new DateTime(1960, 01, 01) };
            Author author2 = new Author() { Username = "testUser2", Name = "nameB", Surname = "surnameB", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.AddAuthor(author2);
            Assert.AreEqual(authorController.ObtainAuthorByUsername("testUser1"), author1);
            Assert.AreEqual(authorController.ObtainAuthorByUsername("testUser2"), author2);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterAuthorWithoutUsername()
        {
            Author author = new Author() { Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterAuthorWithoutName()
        {
            Author author = new Author() { Username= "testuser1", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterAuthorWithoutSurname()
        {
            Author author = new Author() { Username = "testuser1", Name = "nameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(TooLargeException))]
        public void RegisterAuthorWithVeryBigUsername()
        {
            Author author = new Author() { Username = "ABCDEFGHIJKLMOP", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(NotAlphaNumericalException))]
        public void RegisterAuthorWithNotAlphanumericalUsername()
        {
            Author author = new Author() { Username = "%&###$", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(TooLargeException))]
        public void RegisterAuthorWithVeryBigName()
        {
            Author author = new Author() { Username = "testuser1", Name = "nameABCDEFGHIJKLM", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(NotAlphabeticException))]
        public void RegisterAuthorWithNotAlphabeticName()
        {
            Author author = new Author() { Username = "testuser1", Name = "134556", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(TooLargeException))]
        public void RegisterAuthorWithVeryBigSurname()
        {
            Author author = new Author() { Username = "testuser1", Name = "nameA", Surname = "surnameABCDEFGHIJK", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(NotAlphabeticException))]
        public void RegisterAuthorWithNotAlphabeticSurname()
        {
            Author author = new Author() { Username = "testuser1", Name = "nameA", Surname = "1234357", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(DateNotInRangeException))]
        public void RegisterAuthorWithLessThanThirteenYearsOld()
        {
            Author author = new Author() { Username = "testuser1", Name = "nameA", Surname = "surnameA", Born = new DateTime(2010, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(DateNotInRangeException))]
        public void RegisterAuthorWithMoreThanHundredYearsOld()
        {
            Author author = new Author() { Username = "testuser1", Name = "nameA", Surname = "surnameA", Born = new DateTime(1899, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistsException))]
        public void RegisterAuthorThatAlreadyExists()
        {
            Author author1 = new Author() { Username = "testUser1", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Author author2 = new Author() { Username = "testUser1", Name = "nameB", Surname = "surnameB", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.AddAuthor(author2);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistsException))]
        public void RegisterAuthorThatAlreadyExistsButWithDifferentMayusMinusFormat()
        {
            Author author1 = new Author() { Username = "testUser1", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Author author2 = new Author() { Username = "teSTUSER1", Name = "nameB", Surname = "surnameB", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.AddAuthor(author2);
        }



    }
}
