using InterviewMe.SharedKernel;

namespace Infrastructure.Data.EfMigrationContext
{
    public class Question : AuditableEntity<int>
    {
        public string Title { get; private set; }
        public string Body { get; private set; }
        public string Tags { get; private set; }
    }
}
