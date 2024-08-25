namespace Exam.Models;

public class CreateAnswerViewModel
{
    public int QuestionId { get; set; }
    public QuestionType QuestionType { get; set; }
    public string? Answer { get; set; }
    public bool IsCorrect { get; set; }
}