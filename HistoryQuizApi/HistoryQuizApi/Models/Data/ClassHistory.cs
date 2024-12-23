using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HistoryQuizApi.Models.Data
{

    public class ClassHistoryRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ClassHistory
    {
        // Primary key
        [Required]
        public Guid Id { get; set; }

        [AllowNull]
        public string Name { get; set; }

        [AllowNull]
        public string Description { get; set; }

        // Navigation property for related lessons
        public ICollection<Lesson> Lessons { get; set; }

    }
}
