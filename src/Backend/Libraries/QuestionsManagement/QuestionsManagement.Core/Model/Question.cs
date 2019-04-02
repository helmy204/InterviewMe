using InterviewMe.SharedKernel;
using InterviewMe.SharedKernel.Interfaces;
using QuestionsManagement.Core.Events;

namespace QuestionsManagement.Core.Model
{
    public class Question:AuditableEntity<int>
    {
        public static void CreateQuestion(string title, string bodyText)
        {
            Question question = new Question();

            question.Title = title;
            question.BodyText = bodyText;

            DomainEvents.Raise(new QuestionCreatedEvent(question));
        }

        public string Title { get; private set; }
        public string BodyText { get; private set; }
    }
}
