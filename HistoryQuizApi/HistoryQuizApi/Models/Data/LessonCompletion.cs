using System.ComponentModel.DataAnnotations;

namespace HistoryQuizApi.Models.Data
{
    public class LessonCompletion
    {
        [Required]
        public Guid Id { get; set; } // Primary Key

        [Required]
        public Guid StudentId { get; set; } // ID của học sinh

        [Required]
        public Guid LessonId { get; set; } // ID của bài học

        public bool IsCompleted { get; set; } // Trạng thái hoàn thành
    }
}
