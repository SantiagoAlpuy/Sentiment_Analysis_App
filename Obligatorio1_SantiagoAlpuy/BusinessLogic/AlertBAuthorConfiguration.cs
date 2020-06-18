using System.Data.Entity.ModelConfiguration;


namespace BusinessLogic
{
    public class AlertBAuthorConfiguration : EntityTypeConfiguration<AlertBAuthor>
    {
        public AlertBAuthorConfiguration()
        {
            this.HasKey(x => new { x.AuthorId, x.AlertBId });
        }
    }
}
