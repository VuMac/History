using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Shared.DTO;
using HistoryQuizApi.Shared.ResultModel;

namespace HistoryQuizApi.Repository.Interface
{
    public interface IUserRepository
    {

        Task<User> GetUserByUsernameAsync(string username); // Thêm phương thức này
        Task<User> GetUserByUsernameOrEmailAsync(string username, string email);
        Task AddUserAsync(User user);
        Task<User> GetUserByIdAsync(Guid id);
        Task UpdateUser(User u);
        Task<ServiceResult> ResetPasswordAsync(string token, string newPassword);

        Task<bool> registerClassForuser(Guid idUser, Guid idClass);
        
    }
}
