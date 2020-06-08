using System.Data.Entity.ModelConfiguration;


namespace BusinessLogic
{
    public class AlertBConfiguration : EntityTypeConfiguration<AlertB>
    {
        public AlertBConfiguration()
        {
            this.HasMany(x => x.AlertBAuthors)
            .WithRequired()
            .HasForeignKey(x => x.AlertBId);
        }
    }
}
