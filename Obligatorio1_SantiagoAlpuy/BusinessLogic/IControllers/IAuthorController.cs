using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.IControllers
{
    public interface IAuthorController
    {
        void AddAuthor(Author author);
        Author ObtainAuthorByUsername(string username);
        void RemoveAuthor(string username);
        void RemoveAllAuthors();
        void ModifyAuthor(Author author1, Author author2);
        ICollection<Author> GetAll();
        Author GetAuthorById(int authorId);
        Author GetAuthorByIdWithInclude(int id, string includeAttribute);
        ICollection<Author> GetAllAuthorsWithInclude();
    }
}
