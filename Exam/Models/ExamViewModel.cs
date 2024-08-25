namespace Exam.Models
{
    public class ExamViewModel
    {
        public int ExamId { get; set; }
        public ExamType ExamType { get; set; }
        public TimeSpan Duration { get; set; }
        public int NumberOfQuestions { get; set; }
        public string? Subject { get; set; }
        public List<QuestionViewModel> Questions { get; set; } = [];
    }
}
