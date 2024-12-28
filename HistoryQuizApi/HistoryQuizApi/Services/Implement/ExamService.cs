using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HistoryQuizApi.Services.Implement
{
    public class ExamService : IExamService
    {
        private readonly AppDbContext _context;

        public ExamService(AppDbContext context)
        {
            _context = context;
        }

        // Thêm câu hỏi cho bài học
        public async Task<bool> AddQuestionToLessonAsync(Guid lessonId, string questionTitle, string description)
        {
            try
            {
                    var question = new Exam
                {
                    Title = questionTitle,
                    Description = description,
                    LessonId = lessonId,
                };
                question.Id = new Guid();
                _context.Exams.Add(question);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Lấy danh sách câu hỏi theo bài học
        public async Task<IEnumerable<Exam>> GetQuestionsByLessonIdAsync(Guid lessonId)
        {
            return await _context.Exams
                .Where(e => e.LessonId == lessonId)
                .ToListAsync();
        }

        // Cập nhật câu hỏi
        public async Task<bool> UpdateQuestionAsync(string questionId, string title, string description)
        {
            var question = await _context.Exams.FindAsync(questionId);
            if (question == null) return false;

            question.Title = title;
            question.Description = description;

            _context.Exams.Update(question);
            await _context.SaveChangesAsync();

            return true;
        }

        // Xóa câu hỏi
        public async Task<bool> DeleteQuestionAsync(string questionId)
        {
            var question = await _context.Exams.FindAsync(questionId);
            if (question == null) return false;

            _context.Exams.Remove(question);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
