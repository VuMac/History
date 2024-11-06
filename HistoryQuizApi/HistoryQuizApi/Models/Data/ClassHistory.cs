using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HistoryQuizApi.Models.Data
{
    public class ClassHistory
    {
        // Khóa chính kiểu GUID
        [Required]
        public Guid id { get; set; } 
        [AllowNull]
        public string name { get; set; }
        [AllowNull]
        public string description { get; set; }

    }
}
