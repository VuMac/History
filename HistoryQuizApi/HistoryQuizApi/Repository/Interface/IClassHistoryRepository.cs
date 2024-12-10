using HistoryQuizApi.Controllers.Result;
using HistoryQuizApi.Models.Data;

namespace HistoryQuizApi.Repository.Interface
{
    public interface IClassHistoryRepository
    {
        Task AddClassHistoryAsync(ClassHistory classHistory);
        Task<ClassHistory> GetClassByNameAsync(string name);
        Task DeleteClassByNameAsync(string name);
        Task<List<ClassHistory>> GetListClassAsync(Guid userId, int pageIndex, int pageSize);
        Task<List<ClassHistory>> GetListClassEnrollAsync(Guid userId);
        Task<List<ClassHistory>> GetListClassNotEnrollAsync(Guid userId);


    }
}
