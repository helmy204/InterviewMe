using Microsoft.EntityFrameworkCore;
using QuestionsManagement.Core.Model;

namespace QuestionsManagement.Data
{
    public class QuestionsContext : DbContext
    {
        public QuestionsContext(DbContextOptions<QuestionsContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Question> Questions { get; set; }
    }
}
