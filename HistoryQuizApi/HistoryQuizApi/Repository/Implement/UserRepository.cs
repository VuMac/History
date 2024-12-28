using HistoryQuizApi.Controllers.Result;
using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Repository.Interface;
using HistoryQuizApi.Shared.DTO;
using HistoryQuizApi.Shared.ResultModel;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using System.Runtime.CompilerServices;

namespace HistoryQuizApi.Repository.Implement
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // Lấy user dựa trên username hoặc email
        public async Task<User> GetUserByUsernameOrEmailAsync(string username, string email)
        {
            return await _context.User
                .FirstOrDefaultAsync(u => u.Username == username || u.Email == email);
        }

        // Thêm user mới vào cơ sở dữ liệu
        public async Task AddUserAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username,string password)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Username.Trim().Equals(username.Trim()));
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public async Task UpdateUser(User u)
        {
            _context.User.Update(u);
            await _context.SaveChangesAsync();
        }

        //public async Task<ServiceResult> ResetPasswordAsync(string token, string newPassword)
        //{
        //    var user = await _context.User.FirstOrDefaultAsync(u => u.ResetToken == token);

        //    if (user == null)
        //    {
        //        return new ServiceResult
        //        {
        //            Success = false,
        //            Message = "Token không hợp lệ hoặc người dùng không tồn tại."
        //        };
        //    }

        //    // Kiểm tra token có hết hạn không
        //    if (user.TokenExpiry < DateTime.UtcNow)
        //    {
        //        return new ServiceResult
        //        {
        //            Success = false,
        //            Message = "Token đã hết hạn."
        //        };
        //    }

           

        //    try
        //    {
        //        await _context.SaveChangesAsync(); // Lưu thay đổi vào DB
        //        return new ServiceResult
        //        {
        //            Success = true,
        //            Message = "Mật khẩu đã được đặt lại thành công."
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ServiceResult
        //        {
        //            Success = false,
        //            Message = $"Lỗi khi đặt lại mật khẩu: {ex.Message}"
        //        };
        //    }
        //}

        public Task<ServiceResult> GenerateResetTokenAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ResetPasswordAsync(ResetPasswordModel resetModel)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ResetPasswordAsync(string token, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> registerClassForuser(Guid idUser, Guid idClass)
        {
            try
            {
                Enrollment data = new Enrollment();
                data.UserId = idUser;
                data.ClassHistoryId = idClass;
                data.EnrollmentDate = DateTime.Now;
                data.EnrollmentId = Guid.NewGuid();
                data.Status = "ACTIVE";
                _context.enrollments.Add(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<(IEnumerable<User> students, int totalCount)> GetStudentsWithPaginationAsync(int pageIndex, int pageSize)
        {
            var totalCount = await _context.User.CountAsync();

            var students = await _context.User
                .Skip((pageIndex - 1) * pageSize)  // Tính toán phần tử bắt đầu dựa trên trang hiện tại
                .Take(pageSize)  // Lấy số lượng học sinh theo kích thước trang
                .ToListAsync();

            return (students, totalCount);
        }
    }
  
}
