using Microsoft.AspNetCore.Identity;

namespace TestAPI.Models.DomainModels.UserManagement.UserModel
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
