namespace Exam.Entities;

public abstract class Exam
{
    public int Id { get; set; }
    public int NumberOfQuestions { get; set; }
    public int? SubjectId { get; set; }
    public Subject? Subject { get; set; }
    public TimeSpan Duration { get; set; }

    public ICollection<Question> Questions { get; set; } = [];
}