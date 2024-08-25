namespace Exam.Entities;

public abstract class Question
{
    public int Id { get; set; }
    public abstract string Header { get; }
    public string? Body { get; set; }
    public int Mark { get; set; }
    public int? PracticalExamId { get; set; }
    public PracticalExam? PracticalExam { get; set; }
    public int? FinalExamId { get; set; }
    public FinalExam? FinalExam { get; set; }
    public ICollection<Answer> Answers { get; set; } = [];

}
