using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Services.Interface;
using HistoryQuizApi.Shared.DTO;
using HistoryQuizApi.Shared.ResultModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClassHistoryController : ControllerBase
{
    private readonly IClassHistoryService _classService;

    public ClassHistoryController(IClassHistoryService classService)
    {
        _classService = classService;
    }

  //  [Authorize]
    [HttpGet("GetClassHistoryEnroll")]
    public async Task<ActionResult<ServiceResult>> GetListClass(string idUser)
    { 
            var result = await _classService.GetListClassEnrollAsync(Guid.Parse(idUser));
            return Ok(result);      
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceResult>> GetAllListClass(int index,int size)
    {
        var result = await _classService.GetAll(index,size);
        return Ok(result);
    }

    [Authorize]
    [HttpGet("GetClassHistoryNotEnroll")]
    public async Task<ActionResult<ServiceResult>> GetListClassNotEnroll(string idUser)
    {
        var result = await _classService.GetListClassNotEnrollAsync(Guid.Parse(idUser));
        return Ok(result);
    }

    [Authorize]
    [HttpPost("Add")]
    public async Task<ActionResult<ServiceResult>> AddClass([FromBody] AddClassHistoryDto addClassHistoryDto)
    {
        try
        {
            var result = await _classService.AddClassHistoryAsync(addClassHistoryDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ServiceResult
            {
                Success = false,
                Message = "Lỗi server: " + ex.Message
            });
        }
    }

    [Authorize]
    [HttpPost("{classId}/lessons")]
    public async Task<IActionResult> AddLessonToClass(Guid classId, Lesson lesson)
    {
        try
        {
            await _classService.AddLessonToClassAsync(classId, lesson);
            return CreatedAtAction("GetClassById", new { id = classId }, lesson);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}