using HistoryQuizApi.Services.Interface;
using HistoryQuizApi.Shared.DTO;
using HistoryQuizApi.Shared.ResultModel;
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
}