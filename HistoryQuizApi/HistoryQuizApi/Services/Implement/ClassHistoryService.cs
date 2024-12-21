using HistoryQuizApi.Controllers.Result;
using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Repository.Interface;
using HistoryQuizApi.Services.Interface;
using HistoryQuizApi.Shared.DTO;
using HistoryQuizApi.Shared.ResultModel;
using Microsoft.EntityFrameworkCore;
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
                Id = new Guid(),
                Name = AddClassHistoryDto.name,
                Description = AddClassHistoryDto.description

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

        public async Task<IEnumerable<ClassHistory>> GetAllAsync()
        {
            return await _context.classHistory.Include(c => c.Lessons).ToListAsync();
        }

        public async Task<ClassHistory> GetByIdAsync(Guid id)
        {
            return await _context.classHistory.Include(c => c.Lessons)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(ClassHistory classHistory)
        {
            await _context.classHistory.AddAsync(classHistory);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddLessonToClassAsync(Guid classId, Lesson lesson)
        {
            // Retrieve the ClassHistory entity
            var classHistory = await _ClassRepository.GetByIdAsync(classId);
            if (classHistory == null)
            {
                throw new KeyNotFoundException($"Class with ID {classId} not found.");
            }

            // Create a new Lesson associated with the Class
            lesson.Id = Guid.NewGuid();
            lesson.ClassHistoryId = classId;

            // Use DbContext directly or ensure repository supports Lesson operations
            await _context.Lessons.AddAsync(lesson);

            // Persist changes
            await _context.SaveChangesAsync();
        }

        public async Task<List<ClassHistory>> GetAll(int index, int size)
        {
            var result  = await _ClassRepository.GetListClassAsync(index,size);
            return result;
        }
    } 
        
}
