using HistoryQuizApi.Controllers.Result;
using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Shared.DTO;
using HistoryQuizApi.Shared.ResultModel;

namespace HistoryQuizApi.Services.Interface
{
    public interface IClassHistoryService
    {
        Task<ServiceResult> AddClassHistoryAsync(AddClassHistoryDto AddClassHistoryDto);
        Task<List<ClassHistory>> GetListClassEnrollAsync(Guid userId);
        Task<List<ClassHistory>> GetListClassNotEnrollAsync(Guid userId);
    }
}
