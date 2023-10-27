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
    public class CredentialDAL : ICredential
    {
        //context for the database connection
        private readonly GearHeadAutoContext context;

        private readonly IConfiguration _config;

        public CredentialDAL(GearHeadAutoContext Context, IConfiguration config)
        {
            context = Context;
            _config = config;
        }

        public LoginResponseModel LoginUser(LoginModel request)
        {
            {
                LoginResponseModel res = new LoginResponseModel();
                try
                {
                    if (request != null)
                    {
                        //look for the user in the database
                        var query = context.Credentials
                        .Where(x => x.Username == request.Username && x.Password == request.Password)
                        .FirstOrDefault<Credential>();

                        //if query has a result then we have a match
                        if (query != null)
                        {
                            res.Status = true;
                            res.StatusCode = 200;
                            res.Message = "Login Success";

                            //get the user data so we can send it back with
                            Credential user = new Credential { Username = query.Username, Password = query.Password };
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
