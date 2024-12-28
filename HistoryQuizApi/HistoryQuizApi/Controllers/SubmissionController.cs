using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HistoryQuizApi.Controllers
{
    [ApiController]
    [Route("api/submission")]
    public class SubmissionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubmissionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitExam([FromBody] List<SubmissionRequest> submissions)
        {
            if (submissions == null || submissions.Count == 0)
            {
                return BadRequest("Danh sách submissions không hợp lệ.");
            }

            // Lấy thông tin học sinh từ submissions
            var studentId = submissions.First().StudentId;

            // Lấy danh sách các ExamId từ submissions
            var examIds = submissions.Select(s => s.ExamId).ToList();

            // Kiểm tra xem bất kỳ Exam nào trong danh sách đã được nộp bởi học sinh này chưa
            var existingSubmissions = await _context.Submissions
                .Where(s => s.StudentId == studentId && examIds.Contains(s.ExamId))
                .ToListAsync();

            if (existingSubmissions.Any())
            {
                return Conflict("Học sinh đã nộp bài kiểm tra cho môn học này.");
            }

            // Nếu chưa nộp, tạo danh sách mới và lưu vào cơ sở dữ liệu
            var newSubmissions = submissions.Select(sub => new Submission
            {
                Id = Guid.NewGuid(),
                ExamId = sub.ExamId,
                StudentId = sub.StudentId,
                Content = sub.Content,
                IsGraded = false,
                Grade = null
            }).ToList();

            await _context.Submissions.AddRangeAsync(newSubmissions);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Nộp bài thành công!" });
        }
    }
}
