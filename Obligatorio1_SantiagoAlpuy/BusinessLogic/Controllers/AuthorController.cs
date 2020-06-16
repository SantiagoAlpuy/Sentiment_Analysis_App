using System;
using System.Collections.Generic;
using BusinessLogic.IControllers;
using System.Linq;
using BusinessLogic.DataAccess;

namespace BusinessLogic.Controllers
{
    public class AuthorController : IAuthorController
    {
        private const string NULL_AUTHOR = "Los autores no pueden ser nulos.";
        private const string INEXISTENT_AUTHOR = "El usuario a eliminar no existe.";
        private const string AUTHOR_ALREADY_EXISTS = "El usuario que intento agregar ya ha sido agregado al sistema, pruebe otra combinación.";
        private const string INCLUDED_PHRASES = "Phrases";

        Repository<Author> repositoryA;

        public AuthorController()
        {
            repositoryA = new Repository<Author>();
        }

        public void AddAuthor(Author author)
        {
            ValidateAuthorAdition(author);
            repositoryA.Add(author);
        }

        private void ValidateAuthorAdition(Author author)
        {
            if (author == null)
                throw new ArgumentException(NULL_AUTHOR);
            else if (ObtainAuthorByUsername(author.Username) != null)
                throw new InvalidOperationException(AUTHOR_ALREADY_EXISTS);
            else author.Validate();
        }

        public void RemoveAuthor(string username)
        {
            Author author = ObtainAuthorByUsername(username);
            if (author == null)
                throw new NullReferenceException(INEXISTENT_AUTHOR);

            repositoryA.Remove(author);
            AnalyzeAlerts();
        }

        private void AnalyzeAlerts()
        {
            AlertAController alertAController = new AlertAController();
            AlertBController alertBController = new AlertBController();
            alertAController.EvaluateAlerts();
            alertBController.EvaluateAlerts();
        }

        public void RemoveAllAuthors()
        {
            repositoryA.ClearAll();
        }

        public Author ObtainAuthorByUsername(string username)
        {
            return repositoryA.Find(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
        }

        public void ModifyAuthor(Author author1, Author author2)
        {
            ValidateAuthorModification(author1, author2);
            author1.Username = author2.Username;
            author1.Name = author2.Name;
            author1.Surname = author2.Surname;
            author1.Born = author2.Born;
            repositoryA.Update(author1);
        }

        private void ValidateAuthorModification(Author author1, Author author2)
        {
            if (author1 == null || author2 == null)
                throw new ArgumentException(NULL_AUTHOR);
            else if (UsernameChanged(author1, author2)
                && ObtainAuthorByUsername(author2.Username) != null)
                throw new InvalidOperationException(AUTHOR_ALREADY_EXISTS);
            else
                author2.Validate();
        }

        private bool UsernameChanged(Author author1, Author author2)
        {
            return author1.Username.ToLower() != author2.Username.ToLower();
        }

        public ICollection<Author> GetAll()
        {
            return repositoryA.GetAll();
        }

        public Author GetAuthorById(int authorId)
        {
            return repositoryA.Find(x => x.AuthorId == authorId);
        }

        public Author GetAuthorByIdWithInclude(int authorId, string includeAttribute)
        {
            return repositoryA.GetAllWithInclude(includeAttribute).SingleOrDefault(x => x.AuthorId == authorId);
        }

        public ICollection<Author> GetAllAuthorsWithInclude()
        {
            return repositoryA.GetAllWithInclude(INCLUDED_PHRASES);
        }
        
    }
}
