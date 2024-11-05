using HistoryQuizApi.Models.Data;

namespace HistoryQuizApi.Repository.Interface
{
    public interface IClassHistoryRepository
    {
        
        Task AddClassHistoryAsync(ClassHistory classHistory);
        Task<ClassHistory> GetClassByNameAsync(string name);
    }
}
