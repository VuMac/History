using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HistoryQuizApi.Controllers
{
    [ApiController]
    [Route("api/exam")]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet("getExamsByClass")]
        public async Task<IActionResult> GetExamsByClassWithPagination( int pageIndex = 1, int pageSize = 10)
        {
            var exams = await _examService.GetAllExamsWithPagination(pageIndex, pageSize);

            if (exams == null || !exams.Any())
            {
                return NotFound("Không tìm thấy câu hỏi nào cho lớp học này.");
            }

            return Ok(exams);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddQuestionToLesson([FromBody] ExamRequest request)
        {
            var result = await _examService.AddQuestionToLessonAsync(request.LessonId, request.Title, request.Description);
            if (result)
                return Ok();
            return BadRequest("Thêm câu hỏi không thành công");
        }

        [HttpGet("getByLesson/{lessonId}")]
        public async Task<IActionResult> GetQuestionsByLessonId(Guid lessonId)
        {
            var questions = await _examService.GetQuestionsByLessonIdAsync(lessonId);
            return Ok(questions);
        }

        [HttpPut("update/{questionId}")]
        public async Task<IActionResult> UpdateQuestion(string questionId, [FromBody] ExamRequest request)
        {
            var result = await _examService.UpdateQuestionAsync(questionId, request.Title, request.Description);
            if (result)
                return Ok();
            return NotFound("Câu hỏi không tồn tại");
        }

        [HttpDelete("delete/{questionId}")]
        public async Task<IActionResult> DeleteQuestion(string questionId)
        {
            var result = await _examService.DeleteQuestionAsync(questionId);
            if (result)
                return Ok();
            return NotFound("Câu hỏi không tồn tại");
        }
    }

    public class ExamRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid LessonId { get; set; }
    }
}
