using QuestionsManagement.Core.Model;

namespace QuestionsManagement.Core.Interfaces
{
    public interface IQuestionsRepository
    {
        void InsertQuestion(Question question);
    }
}
