using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Shared.DTO;
using HistoryQuizApi.Shared.ResultModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using Org.BouncyCastle.Crypto.Generators;
using Task = Microsoft.Exchange.WebServices.Data.Task;

namespace HistoryQuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        // POST: api/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var result = await _userService.AuthenticateUserAsync(loginDto);

            if (!result.Success)
            {
                return Unauthorized(result.Message); // Trả về 401 Unauthorized nếu thông tin không hợp lệ
            }

            return Ok(new { message = "Đăng nhập thành công!", data = result.Data }); // Trả về thông tin đăng nhập thành công
        }

        // POST: api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto registrationDto)
        {
            var result = await _userService.RegisterUserAsync(registrationDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(new { message = "Đăng ký thành công!" });
        }



        //api dùng để cập nhập thông tin cho user
        [HttpPut("update-info")]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UpdateInfoModel updateModel)
        {
            var result = await _userService.UpdateUserAsync(updateModel);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        
        // forget password
        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel resetModel)
        {
            var result = await _userService.ResetPasswordAsync(resetModel);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
            
        }

        



    }
  
}