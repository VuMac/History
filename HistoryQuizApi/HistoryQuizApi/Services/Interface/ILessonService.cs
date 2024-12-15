﻿using HistoryQuizApi.Models.Data;

namespace HistoryQuizApi.Services.Interface
{
    public interface ILessonService
    {
        Task<IEnumerable<Lesson>> GetAllLessonsAsync();
        Task<Lesson> GetLessonByIdAsync(Guid id);
        Task CreateLessonAsync(Lesson lesson);
        Task UpdateLessonAsync(Lesson lesson);
        Task DeleteLessonAsync(Guid id);
        Task AddExamToLessonAsync(Guid lessonId, Exam exam);
    }
}