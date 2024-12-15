using System.ComponentModel.DataAnnotations;

namespace HistoryQuizApi.Models.Data
{
    public class Submission
    {
        // Primary key
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid ExamId { get; set; }

        public Exam Exam { get; set; }

        [Required]
        public Guid StudentId { get; set; } // Assuming StudentId is managed elsewhere

        [Required]
        public string Content { get; set; } // Answers or file path

        public bool? IsGraded { get; set; } // Nullable to indicate ungraded submissions

        public decimal? Grade { get; set; } // Nullable to store grade
    }

}
