using GearHeadAutoAPI.Data;

namespace GearHeadAutoAPI.Models
{
    public class AdminLoginResponseModel
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public AdminCredential Credentials { get; set; }
    }
}
