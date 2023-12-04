using Microsoft.AspNetCore.Identity;
using Models.DTOs.User;

namespace DataAccess.Repository.IRepository
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(APIUserDto apiUserDto);
        Task<AuthResponseDto> Login(LoginDto loginuserdto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto obj);
    }
}