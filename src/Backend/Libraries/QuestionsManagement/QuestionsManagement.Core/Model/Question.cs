using InterviewMe.SharedKernel;
using InterviewMe.SharedKernel.Interfaces;
using QuestionsManagement.Core.Events;

namespace QuestionsManagement.Core.Model
{
    public class Question : AuditableEntity<int>
    {
        public static void CreateQuestion(string title, string body,string tags)
        {
            Question question = new Question();

            question.Title = title;
            question.Body = body;
            question.Tags = tags;

            DomainEvents.Raise(new QuestionCreatedEvent(question));
        }

        public string Title { get; private set; }
        public string Body { get; private set; }
        public string Tags { get; private set; }
    }
}
