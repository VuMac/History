using HistoryQuizApi.Models.Data;

namespace HistoryQuizApi.Repository.Interface
{
    public interface IEnrollmentRepository
    {
        //CRUD
        Task<Enrollment> GetEnrollmentById(Guid id);
        Task AddEnrollmentAsync(Enrollment data);
        Task DeleteEnrollmentAsync(Guid id);
        Task UpdateEnrollmentAsync(Enrollment data);

        Task<Enrollment> GetEnrollmentList();

    }
}
