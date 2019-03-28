using QuestionsManagement.Core.Interfaces;
using QuestionsManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionsManagement.Data
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly QuestionsContext _questionsContext;

        public QuestionsRepository(QuestionsContext questionsContext)
        {
            _questionsContext = questionsContext;
        }

        public void InsertQuestion(Question question)
        {
            _questionsContext.Questions.Add(question);
            _questionsContext.SaveChanges();
        }
    }
}
