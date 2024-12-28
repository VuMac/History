using HistoryQuizApi.Models.Data;

namespace HistoryQuizApi.Services.Interface
{
    public interface ILessonService
    {
        Task<IEnumerable<Lesson>> GetAllLessonsAsync(int pageIndex, int pageSize);
        Task<Lesson> GetLessonByIdAsync(Guid id);
        Task<Boolean> CreateLessonAsync(LessonRequest lesson,Guid idClass);
        Task UpdateLessonAsync(LessonRequest lesson);
        Task DeleteLessonAsync(Guid id);
        Task AddExamToLessonAsync(Guid lessonId, Exam exam);

        Task<IEnumerable<Lesson>> GetAllLessonsByIdClassAsync(Guid idClass);
    }
}
