namespace Exam.Models;

public class CreateExamViewModel
{
    public int NumberOfQuestions { get; set; }
    public int SubjectId { get; set; }
    public TimeSpan Duration { get; set; }
    public ExamType ExamType { get; set; }
}