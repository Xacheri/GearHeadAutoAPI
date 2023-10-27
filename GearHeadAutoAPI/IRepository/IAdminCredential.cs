using GearHeadAutoAPI.Models;

namespace GearHeadAutoAPI.IRepository
{
    public interface IAdminCredential
    {
        public AdminLoginResponseModel LoginUser(AdminLoginModel request);

    }
}
