using HistoryQuizApi.Models.Data;

namespace HistoryQuizApi.Services.Interface
{
    public interface ISubmissionService
    {
        Task SubmitExamAsync(Submission submission);
        Task<IEnumerable<Submission>> GetSubmissionsForExamAsync(Guid examId);
        Task GradeSubmissionAsync(Guid submissionId, decimal grade);
    }
}
