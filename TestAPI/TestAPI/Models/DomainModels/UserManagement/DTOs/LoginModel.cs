using Azure.Identity;

namespace TestAPI.Models.DomainModels.UserManagement.DTO
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
