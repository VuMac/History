namespace HistoryQuizApi.Services.Interface
{
    public interface ILessonCompletionService
    {
        Task<int> GetCompletedLessonsForClassAsync(Guid classId, Guid studentId);
        Task CompleteLessonAsync(Guid studentId, Guid lessonId);
    }
}
