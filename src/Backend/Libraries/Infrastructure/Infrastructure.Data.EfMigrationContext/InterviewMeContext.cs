using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.EfMigrationContext
{
    public class InterviewMeContext : DbContext
    {
        public InterviewMeContext(DbContextOptions<InterviewMeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Question> Questions { get; set; }


    }
}
