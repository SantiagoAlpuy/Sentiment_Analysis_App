using System.Data.Entity.ModelConfiguration;


namespace BusinessLogic
{
    public class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            this.HasMany<Phrase>(x => x.Phrases).WithRequired(y => y.PhraseAuthor).WillCascadeOnDelete();
        }
    }
}
