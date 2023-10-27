namespace GearHeadAutoAPI.Models
{
    public class AdminLoginModel
    {
        public string Username { get; set; }

        public string? Password { get; set; }

        public string? AdminPassword { get; set; }
        public bool isAdmin { get; set; }
    }
}