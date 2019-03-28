using InterviewMe.SharedKernel.Interfaces;
using QuestionsManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionsManagement.Core.Events
{
    public class QuestionCreatedEvent : IDomainEvent
    {
        public QuestionCreatedEvent(Question question)
        {
            Question = question;
        }

        public DateTime DateTimeEventOccurred => DateTime.Now;
        public Question Question { get; set; }
    }
}
