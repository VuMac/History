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

    [Authorize]
    [HttpGet("GetClassHistory")]
    public async Task<ActionResult<ServiceResult>> GetListClass(int pageIndex,int pageSize)
    { 
            var result = await _classService.GetListClassAsync(Guid.Empty, pageIndex, pageSize);
            return Ok(result);      
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