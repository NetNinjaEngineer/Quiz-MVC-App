using Exam.Models;

namespace Exam.Services.Contracts;

public interface IExamService
{
    int CreateFinalExam(CreateExamViewModel model);
    int CreatePracticalExam(CreateExamViewModel model);
    int AssignQuestionToExam(QuestionType questionType, ExamType examType, CreateQuestionViewModel question, int examId);
    void AddAnswerToQuestion(int id, QuestionType questionType, CreateAnswerViewModel answerModel);
    Task<IEnumerable<SubjectViewModel>> GetAllSubjectsAsync();
    Task<int> GetQuestionsCountAsync(int examId, ExamType examType);
    IEnumerable<ExamViewModel> GetAllExamsAsync();
    Task<ExamViewModel?> GetSingleExamAsync(int examId);
}
