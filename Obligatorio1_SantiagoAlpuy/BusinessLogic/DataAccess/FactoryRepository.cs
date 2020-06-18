using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataAccess
{
    public class FactoryRepository<T> where T : class
    {
        private const string ENTITY_FRAMEWORK = "EntityFramework";
        public static string repositoryType = ENTITY_FRAMEWORK;

        public IRepository<T> CreateRepository()
        {
            Repository<T> repository = null;
            if (repositoryType == ENTITY_FRAMEWORK)
                repository = new Repository<T>();
            return repository;
        }
    }
}
