using InterviewMe.SharedKernel.Interfaces;
using QuestionsManagement.Core.Events;
using QuestionsManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionsManagement.Core.Services
{
    public class QuestionCreatedHandler : IDomainEventHandler<QuestionCreatedEvent>
    {
        private readonly IQuestionsRepository _questionsRepository;

        public QuestionCreatedHandler(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public void Handle(QuestionCreatedEvent questionCreatedEvent)
        {
            _questionsRepository.InsertQuestion(questionCreatedEvent.Question);
        }
    }
}
