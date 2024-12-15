using HistoryQuizApi.Models.Data;

namespace HistoryQuizApi.Repository.Interface
{
    public interface ISubmissionRepository
    {
        Task<IEnumerable<Submission>> GetSubmissionsByExamIdAsync(Guid examId);
        Task<Submission> GetByIdAsync(Guid id);
        Task AddAsync(Submission submission);
        Task UpdateAsync(Submission submission);
        Task SaveChangesAsync();
    }
}
