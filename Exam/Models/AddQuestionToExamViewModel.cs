namespace Exam.Models;

public class AddQuestionToExamViewModel
{
    public string Body { get; set; } = null!;
    public int Mark { get; set; }
    public QuestionType QuestionType { get; set; }
}