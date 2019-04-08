using QuestionsManagement.Core.Interfaces;
using QuestionsManagement.Core.Model;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Question> GetQuestions()
        {
            return _questionsContext.Questions.ToList();
        }

        public IEnumerable<Question> GetQuestionsByTag(string tag)
        {
            return _questionsContext.Questions
                                    .Where(question => question.Tags.Contains(tag))
                                    .ToList();
        }
    }
}
