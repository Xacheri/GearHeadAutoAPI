using GearHeadAutoAPI.Data;
using GearHeadAutoAPI.IRepository;
using GearHeadAutoAPI.Models;
using GearHeadAutoAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GearHeadAutoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminCredentialController : ControllerBase
    {
        private readonly IAdminCredential repository;

        //context for the database connection
        private readonly GearHeadAutoContext context;

        //variable for holding the configuration data for login authentication
        private IConfiguration config;

        public AdminCredentialController(IConfiguration Config)
        {
            config = Config;
            context = new GearHeadAutoContext();
            repository = new AdminCredentialDAL(context, config);
        }

        [HttpPost("LoginAdmin", Name = "LoginAdmin")]
        [AllowAnonymous]
        public async Task<AdminLoginResponseModel> LoginUser(AdminLoginModel tokenData)
        {
            AdminLoginResponseModel response = new AdminLoginResponseModel();
            try
            {
                if (tokenData != null)
                {
                    //call the method that will check the user credentials
                    var loginResult = repository.LoginUser(tokenData);

                    if (loginResult.StatusCode == 200)
                    {
                        //login check has succeeded

                        //query the database to get the information about our logged in user
                        var user = loginResult.Credentials;
                        if (user != null)
                        {
                            response.StatusCode = 200;
                            response.Status = true;
                            response.Message = "Login Successful";
                            response.Credentials = user;

                            return response;
                        }
                    }
                    else
                    {
                        response.StatusCode = 500;
                        response.Status = false;
                        response.Message = "Login Failed";
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("LoginUser --- " + ex.Message);
                response.StatusCode = 500;
                response.Status = false;
                response.Message = "Login Failed";
            }

            return response;
        }
    }
}
