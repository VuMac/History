﻿using HistoryQuizApi.Models.Data;

namespace HistoryQuizApi.Services.Interface
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetAllAsync(int pageIndex, int pageSize);
        Task<IEnumerable<Lesson>> GetAllByClassAsync(Guid idClass);
        Task<Lesson> GetByIdAsync(Guid id);
        Task AddAsync(Lesson lesson);
        Task UpdateAsync(LessonRequest lesson);
        Task DeleteAsync(Lesson lesson);
        Task SaveChangesAsync();
    }
}
