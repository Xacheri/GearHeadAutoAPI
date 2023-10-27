using GearHeadAutoAPI.Data;

namespace GearHeadAutoAPI.Models
{
    public class LoginResponseModel
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Credential Credentials { get; set; }
    }
}
