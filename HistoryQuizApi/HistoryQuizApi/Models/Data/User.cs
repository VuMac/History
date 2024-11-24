using System.Diagnostics.CodeAnalysis;

namespace HistoryQuizApi.Models.Data
{
    public class User
    {
       
        // Khóa chính kiểu GUID
        public Guid Id { get; set; }

        // Thông tin đăng nhập cơ bản
        public string Username { get; set; }
        public string Password { get; set; }

        // Các thông tin bổ sung
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
