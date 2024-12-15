using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Repository.Interface;

namespace HistoryQuizApi.Repository.Implement
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly ApplicationDbContext _context;

        public SubmissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Submission>> GetSubmissionsByExamIdAsync(Guid examId)
        {
            return await _context.Submissions.Where(s => s.ExamId == examId).ToListAsync();
        }

        public async Task<Submission> GetByIdAsync(Guid id)
        {
            return await _context.Submissions.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Submission submission)
        {
            await _context.Submissions.AddAsync(submission);
        }

        public async Task UpdateAsync(Submission submission)
        {
            _context.Submissions.Update(submission);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
