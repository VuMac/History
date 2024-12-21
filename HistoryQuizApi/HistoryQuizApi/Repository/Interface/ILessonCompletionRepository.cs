namespace HistoryQuizApi.Repository.Interface
{

    public interface ILessonCompletionRepository
    {
        Task<int> GetCompletedLessonCountAsync(Guid classId, Guid studentId);
        Task MarkLessonAsCompletedAsync(Guid studentId, Guid lessonId);
    }
}
