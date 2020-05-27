using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AuthorTest
    {
        [TestMethod]
        public void RegisterAuthor()
        {
            Author author = new Author() { Username = "testUser", Name = "name1", Surname= "surname1", Born=DateTime.Now};
        }
    }
}
