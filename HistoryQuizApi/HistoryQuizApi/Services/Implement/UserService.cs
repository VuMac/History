using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Repository.Interface;
using HistoryQuizApi.Shared.DTO;
using HistoryQuizApi.Shared.ResultModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly AppDbContext _context;     

    public UserService(IUserRepository userRepository, AppDbContext _context)
    {

        _userRepository = userRepository;
        _context = _context ?? throw new ArgumentNullException(nameof(_context));
    }

    public async Task<ServiceResult> RegisterUserAsync(UserRegistrationDto registrationDto)
    {
        // Kiểm tra xem user đã tồn tại chưa
        var existingUser = await _userRepository.GetUserByUsernameOrEmailAsync(registrationDto.Username, registrationDto.Email);

        if (existingUser != null)
        {
            return new ServiceResult { Success = false, Message = "Username hoặc email đã tồn tại." };
        }

        // Tạo user mới
        var newUser = new User
        {
            Username = registrationDto.Username,
            Password = registrationDto.Password,  // Cần mã hóa password ở đây
            Email = registrationDto.Email,
            PhoneNumber = registrationDto.PhoneNumber,
            City = registrationDto.City,
            Region = registrationDto.Region,
            CreatedAt = DateTime.Now

        };

        // Lưu user vào cơ sở dữ liệu
        await _userRepository.AddUserAsync(newUser);

        return new ServiceResult { Success = true };
    }


    // Xác thực người dùng khi đăng nhập
    public async Task<ServiceResult> AuthenticateUserAsync(UserLoginDto loginDto)
    {
        // Kiểm tra xem người dùng có tồn tại không
        var user = await _userRepository.GetUserByUsernameAsync(loginDto.Username);
        if (user == null)
        {
            return new ServiceResult
            {
                Success = false,
                Message = "Người dùng không tồn tại."
            };
        }
        // 
        if (user.Password.Equals(loginDto.Password))
        {
            // Nếu thông tin đăng nhập đúng, trả về kết quả thành công
            return new ServiceResult
            {
                Success = true,
                Message = "Đăng nhập thành công!",
                Data = new { user.Id, user.Username, user.Email }  // Có thể trả về thêm thông tin cần thiết
            };
        }
        else
        {
            return new ServiceResult
            {
                Success = false,
                Message = "Sai mật khẩu"
            };
        }

        


    }

    // Khởi tạo _context thông qua Dependency Injection

    public async Task<ServiceResult> UpdateUserAsync(UpdateInfoModel updateModel)
    {
        var user = await _userRepository.GetUserByIdAsync(updateModel.id);

        if (user == null)
        {
            return new ServiceResult { Success = false, Message = $"User với ID {updateModel.id} không tồn tại." };
        }

        // Cập nhật thông tin nếu có
        if (!string.IsNullOrWhiteSpace(updateModel.Address))
            user.Address = updateModel.Address;

        if (!string.IsNullOrWhiteSpace(updateModel.PhoneNumber))
            user.PhoneNumber = updateModel.PhoneNumber;

        if (!string.IsNullOrWhiteSpace(updateModel.City))
            user.City = updateModel.City;

        if (!string.IsNullOrWhiteSpace(updateModel.Region))
            user.Region = updateModel.Region;

        try
        {
            _userRepository.UpdateUser(user);
            return new ServiceResult { Success = true, Message = "Cập nhật thành công!", Data = null };
        }
        catch (Exception ex)
        {
            return new ServiceResult { Success = false, Message = $"Lỗi khi cập nhật: {ex.Message}" };
        }
    }

    public async Task<ServiceResult> ResetPasswordAsync(ResetPasswordModel resetModel)
    {
        var user = await _context.User.FirstOrDefaultAsync(u =>
         u.Email == resetModel.email);

        if (user == null)
        {
            return new ServiceResult { Success = false, Message = "Email không hợp lệ." };
        }
  
        try
        {
            user.Password = resetModel.password;
            await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
            return new ServiceResult { Success = true, Message = "Mật khẩu đã được đặt lại thành công." };
        }
        catch (Exception ex)
        {
            return new ServiceResult { Success = false, Message = $"Lỗi khi đặt lại mật khẩu: {ex.Message}" };
        }
    }
}