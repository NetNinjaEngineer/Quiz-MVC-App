namespace Exam.Models
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string Body { get; set; } = null!;
        public int Mark { get; set; }
        public int? SelectedAnswerId { get; set; }
        public List<AnswerViewModel> Answers { get; set; } = [];
    }
}
