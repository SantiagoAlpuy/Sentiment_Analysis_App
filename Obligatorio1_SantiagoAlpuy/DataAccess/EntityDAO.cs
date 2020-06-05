using BusinessLogic;

namespace DataAccess
{
    public class EntityDAO
    {
        public void AddEntity(Entity entity)
        {
            using (Context context = new Context())
            {
                context.Entities.Add(entity);
                context.SaveChanges();
            }
        }
    }
}
