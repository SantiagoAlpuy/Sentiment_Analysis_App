using System.Data.Entity;
using BusinessLogic;

namespace DataAccess
{
    public class Context : DbContext
    {
        public DbSet<Sentiment> Sentiments {get; set;}
        public DbSet<Entity> Entities { get; set;}
        public DbSet<Phrase> Phrases { get; set;}
        public DbSet<AlertA> AlertsA { get; set; }
        public DbSet<AlertB> AlertsB { get; set; }
        public DbSet<Author> Authors { get; set; }
        
    }
}
