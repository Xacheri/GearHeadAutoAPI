using GearHeadAutoAPI.Models;

namespace GearHeadAutoAPI.IRepository
{
    public interface ICredential
    {
        public LoginResponseModel LoginUser(LoginModel request);

    }
}
