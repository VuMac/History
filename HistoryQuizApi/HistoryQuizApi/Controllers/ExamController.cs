using HistoryQuizApi.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HistoryQuizApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExamController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExams()
        {
            var exams = await _context.Exams.ToListAsync();
            return Ok(exams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamById(Guid id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            return Ok(exam);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExam(Exam exam)
        {
            exam.Id = Guid.NewGuid();
            await _context.Exams.AddAsync(exam);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetExamById), new { id = exam.Id }, exam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(Guid id, Exam exam)
        {
            if (id != exam.Id)
            {
                return BadRequest();
            }

            _context.Entry(exam).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Exams.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(Guid id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
