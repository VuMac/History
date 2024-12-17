using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HistoryQuizApi.Repository.Implement
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _context;

        public ExamRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Exam> GetByLessonIdAsync(Guid lessonId)
        {
            return await _context.Exams.FirstOrDefaultAsync(e => e.LessonId == lessonId);
        }

        public async Task AddAsync(Exam exam)
        {
            await _context.Exams.AddAsync(exam);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
