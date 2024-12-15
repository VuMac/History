using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Repository.Interface;
using HistoryQuizApi.Services.Interface;

namespace HistoryQuizApi.Services.Implement
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _repository;

        public SubmissionService(ISubmissionRepository repository)
        {
            _repository = repository;
        }

        public async Task SubmitExamAsync(Submission submission)
        {
            submission.Id = Guid.NewGuid();
            submission.IsGraded = false;
            await _repository.AddAsync(submission);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Submission>> GetSubmissionsForExamAsync(Guid examId)
        {
            return await _repository.GetSubmissionsByExamIdAsync(examId);
        }

        public async Task GradeSubmissionAsync(Guid submissionId, decimal grade)
        {
            var submission = await _repository.GetByIdAsync(submissionId);
            if (submission == null)
            {
                throw new ArgumentException("Submission not found");
            }

            submission.IsGraded = true;
            submission.Grade = grade;
            await _repository.UpdateAsync(submission);
            await _repository.SaveChangesAsync();
        }
    }
}
