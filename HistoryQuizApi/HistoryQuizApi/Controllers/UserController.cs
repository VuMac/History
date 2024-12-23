using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Shared.DTO;
using HistoryQuizApi.Shared.ResultModel;
using Microsoft.AspNetCore.Authorization;
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
        private readonly JwtService _jwtService;

        public UserController(IUserService userService, JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
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

            var token = _jwtService.GenerateToken(loginDto.Username);
            return Ok(new LoginResponse
            {
                Token = token,
                Expiration = DateTime.Now.AddDays(7),
                data = result.Data

            }); // Trả về thông tin đăng nhập thành công
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
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel resetModel)
        {
            var result = await _userService.ResetPasswordAsync(resetModel);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
            
        }


        //dang ky lop hoc
        [HttpPost("register/class")]
        public async Task<IActionResult> RegisterClass( Guid idUser,Guid idClass)
        {
            var result = await _userService.registerClassForUser(idUser,idClass);

            if (!result)
            {
                return BadRequest("dang ky that bai");
            }

            return Ok(new { message = "Đăng ký thành công!" });
        }





    }

}