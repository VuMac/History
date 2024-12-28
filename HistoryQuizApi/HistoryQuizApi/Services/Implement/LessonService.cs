using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Repository.Interface;
using HistoryQuizApi.Services.Interface;

namespace HistoryQuizApi.Services.Implement
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _repository;
        private readonly IExamRepository _examRepository;

        public LessonService(ILessonRepository repository, IExamRepository examRepository)
        {
            _repository = repository;
            _examRepository = examRepository;
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync(int pageIndex, int pageSize)
        {
            return await _repository.GetAllAsync( pageIndex, pageSize);
        }

        public async Task<Lesson> GetLessonByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Boolean> CreateLessonAsync(LessonRequest lesson, Guid idClass)
        {
            try
            {
                var data = new Lesson();
                data.Id = Guid.NewGuid();
                data.Title = lesson.Title;
                data.Content = lesson.Content;
                data.ClassHistoryId = idClass;
                await _repository.AddAsync(data);
                await _repository.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        public async Task UpdateLessonAsync(LessonRequest lesson)
        {
            await _repository.UpdateAsync(lesson);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteLessonAsync(Guid id)
        {
            var lesson = await _repository.GetByIdAsync(id);
            if (lesson != null)
            {
                await _repository.DeleteAsync(lesson);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task AddExamToLessonAsync(Guid lessonId, Exam exam)
        {
            var lesson = await _repository.GetByIdAsync(lessonId);
            if (lesson == null)
            {
                throw new ArgumentException("Lesson not found");
            }

            exam.Id = Guid.NewGuid();
            exam.LessonId = lessonId;
            await _examRepository.AddAsync(exam);
            await _examRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsByIdClassAsync(Guid idClass)
        {
            return await _repository.GetAllByClassAsync(idClass);
        }
    }
}
