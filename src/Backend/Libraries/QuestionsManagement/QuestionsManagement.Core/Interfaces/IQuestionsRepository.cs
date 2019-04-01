using QuestionsManagement.Core.Model;
using System.Collections.Generic;

namespace QuestionsManagement.Core.Interfaces
{
    public interface IQuestionsRepository
    {
        void InsertQuestion(Question question);
        IEnumerable<Question> GetQuestions();
    }
}
