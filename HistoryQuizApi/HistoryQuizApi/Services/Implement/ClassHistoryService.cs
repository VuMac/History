using HistoryQuizApi.Controllers.Result;
using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Repository.Interface;
using HistoryQuizApi.Services.Interface;
using HistoryQuizApi.Shared.DTO;
using HistoryQuizApi.Shared.ResultModel;
using System.Security.Claims;

namespace HistoryQuizApi.Services.Implement
{
    public class ClassHistoryService : IClassHistoryService
    {
        private readonly IClassHistoryRepository _ClassRepository;
        private readonly AppDbContext _context;
        public ClassHistoryService(IClassHistoryRepository ClassRepository, AppDbContext _context)
        {

            _ClassRepository = ClassRepository;
            _context = _context ?? throw new ArgumentNullException(nameof(_context));
        }

        public async Task<ServiceResult> AddClassHistoryAsync(AddClassHistoryDto AddClassHistoryDto)
        {
            var existingClass = await _ClassRepository.GetClassByNameAsync(AddClassHistoryDto.name);
            if (existingClass != null)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Tên lớp học đã tồn tại."
                };
            }
            var newClass = new ClassHistory
            {
                id = new Guid(),
                name = AddClassHistoryDto.name,
                description = AddClassHistoryDto.description

            };
            await _ClassRepository.AddClassHistoryAsync(newClass);

            return new ServiceResult
            {
                Success = true,
                Message = "Thêm lớp học thành công"
            };
        }

       

        public async Task<List<ClassHistory>> GetListClassEnrollAsync(Guid userId)
        {
            var result = await _ClassRepository.GetListClassEnrollAsync(userId);
            return result;
        }

        public async Task<List<ClassHistory>> GetListClassNotEnrollAsync(Guid userId)
        {
            var result = await _ClassRepository.GetListClassNotEnrollAsync(userId);
            return result;
        }
    } 
        
}
