using HistoryQuizApi.Models.Data;

namespace HistoryQuizApi.Repository.Interface
{
    public interface IExamRepository
    {
        Task<Exam> GetByLessonIdAsync(Guid lessonId);
        Task AddAsync(Exam exam);
        Task SaveChangesAsync();
    }
}
