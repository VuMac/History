using HistoryQuizApi.Controllers.Result;
using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HistoryQuizApi.Repository.Implement
{
    public class ClassHistoryRepository : IClassHistoryRepository
    {
        private readonly AppDbContext _context;

        public ClassHistoryRepository(AppDbContext context)
        {
            _context = context;
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

        public async Task AddClassHistoryAsync(ClassHistory classHistory)
        {
            _context.classHistory.Add(classHistory);
            await _context.SaveChangesAsync();

        }

        public async Task<ClassHistory> GetClassByNameAsync(string className)
        {
            return await _context.classHistory
                .FirstOrDefaultAsync(c => c.Name == className);
        }

        public async Task AddClassAsync(ClassHistory classroom)
        {
            await _context.classHistory.AddAsync(classroom);
            await _context.SaveChangesAsync();
        }

        public Task<List<ClassHistory>> GetClassHistoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateClassHistoryAsync(ClassHistory classHistory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClassByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ClassHistory>> GetListClassAsync(Guid userId, int pageIndex, int pageSize)
        {
            try
            {
                var query = _context.classHistory;

                // Đếm tổng số bản ghi
                var totalRecords = await query.CountAsync();

                // Phân trang
                var items = await query.Skip((pageIndex - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

                // Kết quả phân trang
                var result = new PagedResult<ClassHistory>
                {
                    TotalCount = totalRecords,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Items = items
                };

                return result;
            }
            catch (Exception ex) {
                return null;
            }
           
        }



        async Task<List<ClassHistory>> IClassHistoryRepository.GetListClassAsync(int pageIndex, int pageSize)
        {
            // Validate input parameters
            if (pageIndex < 0) throw new ArgumentException("Page index cannot be negative.", nameof(pageIndex));
            if (pageSize <= 0) throw new ArgumentException("Page size must be greater than zero.", nameof(pageSize));


            // Query all data from ClassHistories
            var query = _context.classHistory;

            // Apply pagination
            var result = await query.Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            return result;
        }

        public Task<List<ClassHistory>> GetListClassEnrollAsync(Guid userId)
        {
            string sql = "select * from classHistory c " +
                "where c.id in (select id from enrollments where userId = " + userId + " )";

            var result = _context.classHistory.FromSqlRaw(sql).ToListAsync(); ;

            return result;
        }

        public Task<List<ClassHistory>> GetListClassNotEnrollAsync(Guid userId)
        {
            string sql = "select * from classHistory c " +
               "where c.id not in (select id from enrollments where userId = " + userId + " )";

            var result = _context.classHistory.FromSqlRaw(sql).ToListAsync(); ;

            return result;
        }
    }
}
