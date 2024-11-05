using HistoryQuizApi.Shared.DTO;
using HistoryQuizApi.Shared.ResultModel;

namespace HistoryQuizApi.Services.Interface
{
    public interface IClassHistoryService
    {
        Task<ServiceResult> AddClassHistoryAsync(AddClassHistoryDto AddClassHistoryDto);
    }
}
