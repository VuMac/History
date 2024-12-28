using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HistoryQuizApi.Services.Implement
{
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext _context;

        public LessonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lesson>> GetAllAsync(int pageIndex, int pageSize)
        {
            try
            {
                // Validate input parameters
                if (pageIndex < 0) throw new ArgumentException("Page index cannot be negative.", nameof(pageIndex));
                if (pageSize <= 0) throw new ArgumentException("Page size must be greater than zero.", nameof(pageSize));
                // Query all data from ClassHistories
                var query = _context.Lessons;
                // Apply pagination
                var result = await query.Skip(pageIndex * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
                return result;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Lesson>> GetAllByClassAsync(Guid idClass)
        {
                // Sử dụng DbContext để truy xuất dữ liệu từ bảng Lessons.
                return await _context.Lessons
                    .Where(lesson => lesson.ClassHistoryId == idClass) // Lọc bài học theo idClass
                    .ToListAsync(); // Trả về danh sách
        }

        public async Task<Lesson> GetByIdAsync(Guid id)
        {
            return await _context.Lessons.FindAsync(id);
        }

        public async Task AddAsync(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
        }

        public async Task UpdateAsync(LessonRequest lesson)
        {
            try 
            {
               var a = _context.Lessons.FirstOrDefault(x => x.Id.Equals(lesson.id));
                a.Title = lesson.Title;
                a.Content = lesson.Content;
                _context.Lessons.Update(a);
                await _context.SaveChangesAsync();
            }catch(Exception e)
            {

            }
        }

        public async Task DeleteAsync(Lesson lesson)
        {
            _context.Lessons.Remove(lesson);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}
