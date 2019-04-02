using InterviewMe.SharedKernel;

namespace Infrastructure.Data.EfMigrationContext
{
    public class Question : AuditableEntity<int>
    {
        public string Title { get; private set; }
        public string BodyText { get; private set; }
    }
}
