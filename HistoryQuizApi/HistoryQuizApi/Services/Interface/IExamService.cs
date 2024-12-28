using HistoryQuizApi.Models.Data;

namespace HistoryQuizApi.Services.Interface
{
    public interface IExamService
    {
        // Tạo câu hỏi mới cho bài học
        Task<bool> AddQuestionToLessonAsync(Guid lessonId, string questionTitle, string description);

        // Lấy danh sách câu hỏi theo bài học
        Task<IEnumerable<Exam>> GetQuestionsByLessonIdAsync(Guid lessonId);

        // Cập nhật câu hỏi
        Task<bool> UpdateQuestionAsync(string questionId, string title, string description);

        // Xóa câu hỏi
        Task<bool> DeleteQuestionAsync(string questionId);
    }
}
