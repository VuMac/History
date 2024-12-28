using System.ComponentModel.DataAnnotations;

namespace HistoryQuizApi.Models.Data
{
    public class ExamRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid LessonId { get; set; }
    }
    public class Exam
    {
        // Primary key
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        // Foreign key for Lesson
        [Required]
        public Guid LessonId { get; set; }

        // Navigation property for Lesson
        public Lesson Lesson { get; set; }

        // Navigation property for Submissions
        public ICollection<Submission> Submissions { get; set; }
    }
}
