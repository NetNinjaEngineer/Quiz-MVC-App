namespace Exam.Entities;

public class Subject
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Exam> Exams { get; set; } = [];
}
