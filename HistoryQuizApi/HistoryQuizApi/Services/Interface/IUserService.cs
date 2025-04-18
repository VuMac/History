﻿using HistoryQuizApi.Controllers.Result;
using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Shared.DTO;
using HistoryQuizApi.Shared.ResultModel;
using System.Threading.Tasks;

public interface IUserService
{
    Task<ServiceResult> RegisterUserAsync(UserRegistrationDto registrationDto);

    Task<ServiceResult> AuthenticateUserAsync(UserLoginDto loginDto);  // Thêm phương thức này
    Task<ServiceResult> UpdateUserAsync(UpdateInfoModel updateModel);
    Task<ServiceResult> ResetPasswordAsync(ResetPasswordModel resetModel);

    Task<bool> registerClassForUser(Guid idUser, Guid idClass);

    Task<(IEnumerable<User> students, int totalCount)> GetStudentsWithPaginationAsync(int pageIndex, int pageSize);


}