using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HistoryQuizApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _service;

        public SubmissionController(ISubmissionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitExam(Submission submission)
        {
            await _service.SubmitExamAsync(submission);
            return CreatedAtAction(nameof(GetSubmissionById), new { id = submission.Id }, submission);
        }

        [HttpGet("exam/{examId}")]
        public async Task<IActionResult> GetSubmissionsForExam(Guid examId)
        {
            var submissions = await _service.GetSubmissionsForExamAsync(examId);
            return Ok(submissions);
        }

        [HttpPatch("{submissionId}/grade")]
        public async Task<IActionResult> GradeSubmission(Guid submissionId, [FromBody] decimal grade)
        {
            try
            {
                await _service.GradeSubmissionAsync(submissionId, grade);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubmissionById(Guid id)
        {
            var submission = await _service.GetSubmissionsForExamAsync(id);
            if (submission == null)
                return NotFound();

            return Ok(submission);
        }
    }
}
