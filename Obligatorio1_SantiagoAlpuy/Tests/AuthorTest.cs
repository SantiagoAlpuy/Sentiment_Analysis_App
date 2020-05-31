using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
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
            Author author1 = new Author() { Username = "testUser1", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Author author2 = new Author() { Username = "testUser2", Name = "nameB", Surname = "surnameB", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.AddAuthor(author2);
            Assert.AreEqual(authorController.ObtainAuthorByUsername("testUser1"), author1);
            Assert.AreEqual(authorController.ObtainAuthorByUsername("testUser2"), author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterNullAuthor()
        {
            authorController.AddAuthor(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithoutUsername()
        {
            Author author = new Author() { Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithoutName()
        {
            Author author = new Author() { Username = "testuser1", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithoutSurname()
        {
            Author author = new Author() { Username = "testuser1", Name = "nameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithVeryBigUsername()
        {
            Author author = new Author() { Username = "ABCDEFGHIJKLMOP", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithNotAlphanumericalUsername()
        {
            Author author = new Author() { Username = "%&###$", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithVeryBigName()
        {
            Author author = new Author() { Username = "testuser1", Name = "nameABCDEFGHIJKLM", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithNotAlphabeticName()
        {
            Author author = new Author() { Username = "testuser1", Name = "134556", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithVeryBigSurname()
        {
            Author author = new Author() { Username = "testuser1", Name = "nameA", Surname = "surnameABCDEFGHIJK", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithNotAlphabeticSurname()
        {
            Author author = new Author() { Username = "testuser1", Name = "nameA", Surname = "1234357", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithLessThanThirteenYearsOld()
        {
            Author author = new Author() { Username = "testuser1", Name = "nameA", Surname = "surnameA", Born = new DateTime(2010, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithMoreThanHundredYearsOld()
        {
            Author author = new Author() { Username = "testuser1", Name = "nameA", Surname = "surnameA", Born = new DateTime(1899, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterAuthorThatAlreadyExists()
        {
            Author author1 = new Author() { Username = "testUser1", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Author author2 = new Author() { Username = "testUser1", Name = "nameB", Surname = "surnameB", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.AddAuthor(author2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterAuthorThatAlreadyExistsButWithDifferentMayusMinusFormat()
        {
            Author author1 = new Author() { Username = "testUser1", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Author author2 = new Author() { Username = "teSTUSER1", Name = "nameB", Surname = "surnameB", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.AddAuthor(author2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterAuthorThatAlreadyExistsButWithBlankSpacesAtBegginingAndEnd()
        {
            Author author1 = new Author() { Username = "  santi  ", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Author author2 = new Author() { Username = "santi", Name = "nameB", Surname = "surnameB", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.AddAuthor(author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithEmptyUsername()
        {
            Author author = new Author() { Username = "", Name = "nameB", Surname = "surnameB", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithEmptyName()
        {
            Author author = new Author() { Username = "testUser1", Name = "", Surname = "surnameB", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithEmptySurname()
        {
            Author author = new Author() { Username = "testUser1", Name = "nameA", Surname = "", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithUsernameWithOnlyBlankSpaces()
        {
            Author author = new Author() { Username = "    ", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithNameWithOnlyBlankSpaces()
        {
            Author author = new Author() { Username = "nameA", Name = "     ", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterAuthorWithSurnameWithOnlyBlankSpaces()
        {
            Author author = new Author() { Username = "testUserA", Name = "nameA", Surname = "    ", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        public void DeleteExistingAuthor()
        {
            Author author = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author);
            authorController.RemoveAuthor("testUserA");
            Assert.IsNull(authorController.ObtainAuthorByUsername("testUserA"));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteNotExistingAuthor()
        {
            authorController.RemoveAuthor("ThisAuthorDoesNotExist");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorNameToEmpty()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorNameToNameWithOnlyBlankSpaces()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "    ", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorNameToNameWithNotAlphabeticCharacters()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "$234", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorNameToVeryBigName()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "veryverybigname", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorSurnameToEmpty()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Surname = "", Born = new DateTime(1980, 01, 01) };
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorSurnameToSurnameWithOnlyBlankSpaces()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Surname = "    ", Born = new DateTime(1980, 01, 01) };
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorSurnameToSurnameWithNotAlphabeticCharacters()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Surname = "%234", Born = new DateTime(1980, 01, 01) };
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorSurnameToVeryBigName()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Surname = "veryveryverybigsurname", Born = new DateTime(1980, 01, 01) };
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorBirthDateWithDateWithLessThanThirteenYearsOld()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(2010, 01, 01) };
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorBirthDateWithDateWithMoreThanHundredYearsOld()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1899, 01, 01) };
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorNameForNullName()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorSurnameForNullSurname()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Born = new DateTime(1980, 01, 01) };
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorForNullAuthor()
        {
            Author author = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.ModifyAuthor(author, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyNullAuthorWithAuthor()
        {
            Author author = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.ModifyAuthor(null, author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorWithBothParametersAsNull()
        {
            authorController.ModifyAuthor(null, null);
        }

    }
}
