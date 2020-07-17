using Microsoft.EntityFrameworkCore;

namespace DoFest.Persistence
{
    public class DoFestContext:DbContext
    {
        public DoFestContext(DbContextOptions<DoFestContext> options)
        {
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}