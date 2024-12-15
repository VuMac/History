using System.ComponentModel.DataAnnotations;

namespace HistoryQuizApi.Models.Data
{
    // Entity Lesson
    public class Lesson
    {
        // Primary key
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        // Foreign key for ClassHistory
        [Required]
        public Guid ClassHistoryId { get; set; }

        // Navigation property for ClassHistory
        public ClassHistory ClassHistory { get; set; }

        public Exam Exam { get; set; }
        public ICollection<Submission> Submissions { get; set; }


    }
}
