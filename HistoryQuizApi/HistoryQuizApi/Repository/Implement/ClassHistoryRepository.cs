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

        public async Task AddClassHistoryAsync(ClassHistory classHistory)
        {
            _context.classHistory.Add(classHistory);
            await _context.SaveChangesAsync();

        }

        public async Task<ClassHistory> GetClassByNameAsync(string className)
        {
            return await _context.classHistory
                .FirstOrDefaultAsync(c => c.name == className);
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

       
    }
}
