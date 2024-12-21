using HistoryQuizApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HistoryQuizApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonCompletionController : ControllerBase
    {
        private readonly ILessonCompletionService _service;

        public LessonCompletionController(ILessonCompletionService service)
        {
            _service = service;
        }

        // API lấy số lượng bài học đã hoàn thành trong lớp học
        [HttpGet("class/{classId}/student/{studentId}/completed-count")]
        public async Task<IActionResult> GetCompletedLessonCount(Guid classId, Guid studentId)
        {
            var count = await _service.GetCompletedLessonsForClassAsync(classId, studentId);
            return Ok(new { CompletedLessons = count });
        }

        // API đánh dấu bài học là hoàn thành
        [HttpPost("lesson/{lessonId}/complete")]
        public async Task<IActionResult> CompleteLesson(Guid lessonId, [FromBody] Guid studentId)
        {
            await _service.CompleteLessonAsync(studentId, lessonId);
            return NoContent();
        }
    }
}
