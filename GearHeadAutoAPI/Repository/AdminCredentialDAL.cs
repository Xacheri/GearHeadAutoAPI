using System.Data;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System.Text;
using Microsoft.AspNetCore.Identity;
using GearHeadAutoAPI.Data;
using GearHeadAutoAPI.Models;
using GearHeadAutoAPI.IRepository;

namespace GearHeadAutoAPI.Repository
{
    public class AdminCredentialDAL : IAdminCredential
    {
        //context for the database connection
        private readonly GearHeadAutoContext context;

        private readonly IConfiguration _config;

        public AdminCredentialDAL(GearHeadAutoContext Context, IConfiguration config)
        {
            context = Context;
            _config = config;
        }

        public AdminLoginResponseModel LoginUser(AdminLoginModel request)
        {
            {
                AdminLoginResponseModel res = new AdminLoginResponseModel();
                try
                {
                    if (request != null)
                    {
                        //look for the user in the database
                        var query = context.AdminCredentials
                        .Where(x => x.Username == request.Username && x.Password == request.Password)
                        .FirstOrDefault<AdminCredential>();

                        //if query has a result then we have a match
                        if (query != null && query.AdminPassword == request.AdminPassword)
                        {
                            res.Status = true;
                            res.StatusCode = 200;
                            res.Message = "Login Success";

                            //get the user data so we can send it back with
                            AdminCredential user = new AdminCredential { Username = query.Username, Password = query.Password, AdminPassword = query.AdminPassword };
                            res.Credentials = user;
                            return res;
                        }
                        else
                        {
                            //the user wasn't found or wasn't a match
                            res.Status = false;
                            res.StatusCode = 500;
                            res.Message = "Login Failed";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("LoginUser --- " + ex.Message);
                    res.Status = false;
                    res.StatusCode = 500;
                }

                return res;
            }
        }
    }
}
