using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HistoryQuizApi.Repository.Implement
{
    public class LessonCompletionRepository : ILessonCompletionRepository
    {
        private readonly AppDbContext _context;

        public LessonCompletionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetCompletedLessonCountAsync(Guid classId, Guid studentId)
        {
            return await _context.LessonCompletions
                .Where(lc => lc.IsCompleted && lc.StudentId == studentId &&
                             _context.Lessons.Any(l => l.Id == lc.LessonId && l.ClassHistoryId == classId))
                .CountAsync();
        }

        public async Task MarkLessonAsCompletedAsync(Guid studentId, Guid lessonId)
        {
            var completion = new LessonCompletion
            {
                Id = Guid.NewGuid(),
                StudentId = studentId,
                LessonId = lessonId,
                IsCompleted = true
            };
            await _context.LessonCompletions.AddAsync(completion);
            await _context.SaveChangesAsync();
        }
    }
}
