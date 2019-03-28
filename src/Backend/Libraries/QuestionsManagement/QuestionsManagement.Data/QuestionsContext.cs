using Microsoft.EntityFrameworkCore;
using QuestionsManagement.Core.Model;

namespace QuestionsManagement.Data
{
    public class QuestionsContext : DbContext
    {
        public virtual DbSet<Question> Questions { get; set; }
    }
}
