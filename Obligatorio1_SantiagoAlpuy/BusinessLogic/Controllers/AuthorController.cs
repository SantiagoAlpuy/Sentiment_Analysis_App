﻿using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Exceptions;
using BusinessLogic.IControllers;

namespace BusinessLogic.Controllers
{
    public class AuthorController : IAuthorController
    { 
        Repository repository = Repository.Instance;
        private List<Author> authors;
        public const int MAX_CHARS_IN_USERNAME = 10;

        public AuthorController()
        {
            authors = repository.Authors;
        }

        public void AddAuthor(Author author)
        {
            if (author.Username == null || author.Name == null || author.Surname == null)
                throw new LackOfObligatoryParametersException();
            else if (author.Username.Length >= MAX_CHARS_IN_USERNAME)
                throw new UsernameIsTooLargeException();
            else
                authors.Add(author);
        }

        public Author ObtainAuthorByUsername(string username)
        {
            return authors.Find(x => x.Username == username);
        }
    }
}
