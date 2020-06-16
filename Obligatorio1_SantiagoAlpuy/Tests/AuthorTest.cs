using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class AuthorTest
    {
        IAuthorController authorController;
        IPhraseController phraseController;

        [TestInitialize]
        public void Setup()
        {
            authorController = new AuthorController();
            phraseController = new PhraseController();
            authorController.RemoveAllAuthors();
            phraseController.RemoveAllPhrases();
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            authorController.RemoveAllAuthors();
            phraseController.RemoveAllPhrases();
        }

        [TestMethod]
        public void RegisterAuthors()
        {
            Author author1 = new Author() { Username = "testUser1", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            Author author2 = new Author() { Username = "testUser2", Name = "nameB", Surname = "surnameB", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.AddAuthor(author2);
            Author author3 = authorController.ObtainAuthorByUsername("testUser1");
            Author author4 = authorController.ObtainAuthorByUsername("testUser2");
            Assert.AreEqual(author1.AuthorId, author3.AuthorId);
            Assert.AreEqual(author2.AuthorId, author4.AuthorId);
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
        public void RegisterAuthorWithNameWithBlankSpacesInTheMiddleOftheName()
        {
            Author author = new Author() { Username = "testUserA", Name = "San Tiago", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        public void RegisterAuthorWithSurnameWithBlankSpacesInTheMiddleOftheSurname()
        {
            Author author = new Author() { Username = "testUserA", Name = "nameA", Surname = "Al Puy", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author);
        }

        [TestMethod]
        public void DeleteExistingAuthor()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.RemoveAuthor("testUserA");
            Author author2 = authorController.ObtainAuthorByUsername("testUserA");
            Assert.IsNull(author2);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteNotExistingAuthor()
        {
            authorController.RemoveAuthor("ThisAuthorDoesNotExist");
        }

        [TestMethod]
        public void DeleteExistingAuthorAndAllHisPhrases()
        {
            List<Phrase> phrases = phraseController.GetAllEntities();
            Author author = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Phrase phrase1 = new Phrase() { Comment = "Me gusta la Pepsi", Date = DateTime.Now, Author = author };
            Phrase phrase2 = new Phrase() { Comment = "Odio la Limol", Date = DateTime.Now, Author = author };
            authorController.AddAuthor(author);
            phraseController.AddPhrase(phrase1);
            phraseController.AddPhrase(phrase2);
            authorController.RemoveAuthor("testUserA");
            List<Phrase> phrasesToBeDeleted = phrases.FindAll(x => x.Author.Equals(author));
            Assert.AreEqual(0, phrasesToBeDeleted.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorNameToEmpty()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorNameToNameWithOnlyBlankSpaces()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "    ", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorNameToNameWithNotAlphabeticCharacters()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "$234", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorNameToVeryBigName()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "veryverybigname", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorSurnameToEmpty()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Surname = "", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorSurnameToSurnameWithOnlyBlankSpaces()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Surname = "    ", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorSurnameToSurnameWithNotAlphabeticCharacters()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Surname = "%234", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorSurnameToVeryBigName()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Surname = "veryveryverybigsurname", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorBirthDateWithDateWithLessThanThirteenYearsOld()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(2010, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorBirthDateWithDateWithMoreThanHundredYearsOld()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1899, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorNameForNullName()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorSurnameForNullSurname()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorForNullAuthor()
        {
            Author author = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author);
            authorController.ModifyAuthor(author, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyNullAuthorWithAuthor()
        {
            Author author = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author);
            authorController.ModifyAuthor(null, author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorWithBothParametersAsNull()
        {
            authorController.ModifyAuthor(null, null);
        }

        [TestMethod]
        public void ModifyAuthorWithNameWithBlankSpacesInTheMiddleOftheName()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "Santiago", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "San Tiago", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        public void ModifyAuthorWithSurnameWithBlankSpacesInTheMiddleOftheSurname()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "Alpuy", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Surname = "Al Puy", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorUsernameToEmptyUsername()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "Alpuy", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorUsernameToUsernameWithManyBlankSpaces()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "Alpuy", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "   ", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        public void ModifyAuthorUsernameToSameUsername()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "Alpuy", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
            Assert.AreEqual("testUserA", author1.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ModifyAuthorUsernameToUsernameThatAlreadyExistsOtherThanHim()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "testUserB", Name = "nameB", Surname = "surnameB", Born = new DateTime(1980, 01, 01) };
            Author author3 = new Author() { Username = "testUserA", Name = "nameC", Surname = "surnameC", Born = new DateTime(1980, 01, 01) };

            authorController.AddAuthor(author1);
            authorController.AddAuthor(author2);
            authorController.ModifyAuthor(author2, author3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorUsernameToNotAlphanumericalUsername()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "%&###$", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyAuthorNameToVeryBigUsername()
        {
            Author author1 = new Author() { Username = "testUserA", Name = "nameA", Surname = "surnameA", Born = new DateTime(1980, 01, 01) };
            Author author2 = new Author() { Username = "ABCDEFGHIJKLMOP", Name = "nameA", Surname = "surnameA", Born = new DateTime(1960, 01, 01) };
            authorController.AddAuthor(author1);
            authorController.ModifyAuthor(author1, author2);
        }

    }
}
