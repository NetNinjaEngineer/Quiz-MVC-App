namespace Exam.Entities;

public class Answer
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public bool Correct { get; set; }
    public int? TFQuestionId { get; set; }
    public TFQuestion? TFQuestion { get; set; }
    public int? MCQQuestionId { get; set; }
    public MCQQuestion? MCQQuestion { get; set; }
}
