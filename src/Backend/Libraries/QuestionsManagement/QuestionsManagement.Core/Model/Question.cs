using InterviewMe.SharedKernel;
using QuestionsManagement.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionsManagement.Core.Model
{
    public class Question
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
