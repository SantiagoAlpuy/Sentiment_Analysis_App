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

        [TestMethod]
        public void RegisterAuthors()
        {
            Author author1 = new Author() { Username = "testUser1", Name = "name1", Surname= "surname1", Born=DateTime.Now};
            Author author2 = new Author() { Username = "testUser2", Name = "name2", Surname = "surname2", Born = DateTime.Now};
            authorController.AddAuthor(author1);
            authorController.AddAuthor(author2);
            Assert.AreEqual(authorController.ObtainAuthorByUsername("testUser1"), author1);
            Assert.AreEqual(authorController.ObtainAuthorByUsername("testUser2"), author2);
        }

        [TestMethod]
        [ExpectedException(typeof(LackOfObligatoryParametersException))]
        public void RegisterAuthorWithoutUsername()
        {
            Author author = new Author() { Name = "name1", Surname = "surname1", Born = DateTime.Now };
            authorController.AddAuthor(author);
        }
    }
}
