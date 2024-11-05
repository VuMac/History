using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HistoryQuizApi.Models.Data
{
    public class ClassHistory
    {
        // Khóa chính kiểu GUID
        

        public Guid id { get; set; } 
        public string name { get; set; }
        public string description { get; set; }

    }
}
