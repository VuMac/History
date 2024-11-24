using HistoryQuizApi.Controllers.Result;
using HistoryQuizApi.Models.Data;

namespace HistoryQuizApi.Repository.Interface
{
    public interface IClassHistoryRepository
    {
        Task AddClassHistoryAsync(ClassHistory classHistory);
        Task<ClassHistory> GetClassByNameAsync(string name);
        Task DeleteClassByNameAsync(string name);
        Task <PagedResult<ClassHistory>> GetListClassAsync(Guid userId, int pageIndex, int pageSize);
        Task<PagedResult<ClassHistory>> GetListClassEnrollAsync(Guid userId, int pageIndex, int pageSize);
    }
}
