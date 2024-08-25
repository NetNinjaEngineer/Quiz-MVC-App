namespace Exam.Models;
public class AssignQuestionViewModel
{
    public int ExamId { get; set; }
    public QuestionType QuestionType { get; set; }
    public ExamType ExamType { get; set; }
    public CreateQuestionViewModel CreateQuestionViewModel { get; set; }
}
