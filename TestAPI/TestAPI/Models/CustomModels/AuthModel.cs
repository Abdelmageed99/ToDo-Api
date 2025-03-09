namespace TestAPI.Models.CustomModels
{
    public class AuthModel
    {
        public string? Massage { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Token { get; set; }
        public DateTime ExpireOn { get; set; }
        public string? UserName { get; set; }

        public string? Email { get; set; }

    }
}
