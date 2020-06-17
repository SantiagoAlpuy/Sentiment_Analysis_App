using System.Data.Entity;

namespace BusinessLogic
{
    public class Context : DbContext
    {
        public DbSet<Sentiment> Sentiments {get; set;}
        public DbSet<Entity> Entities { get; set;}
        public DbSet<Phrase> Phrases { get; set;}
        public DbSet<AlertA> AlertsA { get; set; }
        public DbSet<AlertB> AlertsB { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AlertBAuthor> AlertBAuthors { get; set; }
        
        public Context()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlertBAuthorConfiguration());
            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new AlertBConfiguration());
            
        }
    }
}
