﻿using HistoryQuizApi.Models.Data;

namespace HistoryQuizApi.Services.Interface
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetAllAsync();
        Task<Lesson> GetByIdAsync(Guid id);
        Task AddAsync(Lesson lesson);
        Task UpdateAsync(Lesson lesson);
        Task DeleteAsync(Lesson lesson);
        Task SaveChangesAsync();
    }
}
