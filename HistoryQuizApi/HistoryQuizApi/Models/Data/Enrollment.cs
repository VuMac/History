using System.Security.Claims;

namespace HistoryQuizApi.Models.Data
{
    public class Enrollment
    {
        public Guid EnrollmentId { get; set; } // Mã ghi danh
        public Guid UserId { get; set; } // Mã người dùng (liên kết với User)
        public Guid ClassHistoryId { get; set; } // Mã lớp học (liên kết với Class)
        public DateTime EnrollmentDate { get; set; } // Ngày ghi danh
        public string Status { get; set; } // Trạng thái ghi danh (VD: "Đã tham gia", "Đang chờ", "Hoàn thành")

        // Liên kết với User
        public User User { get; set; }

        // Liên kết với ClassHistory
        public ClassHistory Class { get; set; }
    }
}
