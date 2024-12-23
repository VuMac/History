using HistoryQuizApi.Controllers.Result;
using HistoryQuizApi.Models.Data;

namespace HistoryQuizApi.Repository.Interface
{
    public interface IClassHistoryRepository
    {
        Task AddClassHistoryAsync(ClassHistory classHistory);
        Task<ClassHistory> GetClassByNameAsync(string name);
        Task DeleteClassByNameAsync(string name);
        Task<List<ClassHistory>> GetListClassAsync( int pageIndex, int pageSize);
        Task<List<ClassHistory>> GetListClassEnrollAsync(Guid userId);
        Task<List<ClassHistory>> GetListClassNotEnrollAsync(Guid userId);

        Task<ClassHistory> UpdateClassHistory(ClassHistoryRequest name);
        Task<IEnumerable<ClassHistory>> GetAllAsync();
        Task<ClassHistory> GetByIdAsync(Guid id);
        Task AddAsync(ClassHistory classHistory);
        Task SaveChangesAsync();
        Task<bool> DeleteById(Guid id);

    }
}
