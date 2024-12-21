using HistoryQuizApi.Repository.Interface;
using HistoryQuizApi.Services.Interface;

namespace HistoryQuizApi.Services.Implement
{
    public class LessonCompletionService : ILessonCompletionService
    {
        private readonly ILessonCompletionRepository _repository;

        public LessonCompletionService(ILessonCompletionRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> GetCompletedLessonsForClassAsync(Guid classId, Guid studentId)
        {
            return await _repository.GetCompletedLessonCountAsync(classId, studentId);
        }

        public async Task CompleteLessonAsync(Guid studentId, Guid lessonId)
        {
            await _repository.MarkLessonAsCompletedAsync(studentId, lessonId);
        }
    }
}
