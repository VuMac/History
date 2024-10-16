namespace HistoryQuizApi.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<Answer> Answers { get; set; }
        public string CorrectAnswer { get; set; } // Lưu tên câu trả lời đúng
    }
}
