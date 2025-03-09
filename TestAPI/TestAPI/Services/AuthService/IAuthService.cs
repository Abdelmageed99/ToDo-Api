using TestAPI.Models.CustomModels;
using TestAPI.Models.DomainModels.UserManagement.DTO;

namespace TestAPI.Services.AuthManagement
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);

        Task<AuthModel> LoginAsync(LoginModel model);
    }
}
