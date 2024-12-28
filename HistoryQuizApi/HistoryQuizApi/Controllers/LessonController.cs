using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HistoryQuizApi.Controllers
{
    [ApiController]
    [Route("api/lesson")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _service;

        public LessonController(ILessonService service)
        {
            _service = service;
        }
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllLessons(int index, int size)
        {
            var lessons = await _service.GetAllLessonsAsync(index, size);
            return Ok(lessons);
        }

        [HttpGet("getByClass")]
        public async Task<IActionResult> GetAllLessonsByClass(Guid idClass)
        {
            var lessons = await _service.GetAllLessonsByIdClassAsync(idClass);
            return Ok(lessons);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateLesson(LessonRequest classHistory)
        {
            try
            {
                await _service.UpdateLessonAsync(classHistory);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //s [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateLessons(LessonRequest lesson,Guid idClass)
        {
            string a = "";
            var data = await _service.CreateLessonAsync(lesson, idClass);
            return Ok(data);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonById(Guid id)
        {
            var lesson = await _service.GetLessonByIdAsync(id);
            if (lesson == null)
                return NotFound();

            return Ok(lesson);
        }
        [Authorize]
        [HttpPost("{lessonId}/exam")]
        public async Task<IActionResult> AddExamToLesson(Guid lessonId, Exam exam)
        {
            try
            {
                await _service.AddExamToLessonAsync(lessonId, exam);
                return CreatedAtAction(nameof(GetLessonById), new { id = lessonId }, exam);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
    }
