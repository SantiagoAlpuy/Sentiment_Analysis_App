using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class AuthorTest
    {
        List<Author> authors = new List<Author>();
        [TestMethod]
        public void RegisterAuthors()
        {
            Author author1 = new Author() { Username = "testUser", Name = "name1", Surname= "surname1", Born=DateTime.Now};
            Author author2 = new Author() { Username = "testUser", Name = "name1", Surname = "surname1", Born = DateTime.Now };
            authors.Add(author1);
            authors.Add(author2);
            Assert.IsTrue(authors.Contains(author1));
            Assert.IsTrue(authors.Contains(author2));
        }
    }
}
