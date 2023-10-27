using System.Data;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System.Text;
using Microsoft.AspNetCore.Identity;
using GearHeadAutoAPI.Data;

namespace GearHeadAutoAPI.Repository
{
    public class CredentialDAL
    {
        //context for the database connection
        private readonly GearHeadAutoContext context;

        private readonly IConfiguration _config;

        public CredentialDAL(GearHeadAutoContext Context, IConfiguration config)
        {
            context = Context;
            _config = config;
        }

        //public async Task<LoginResponse> LoginUser(LoginModel request)
        //{

        //}
    }
}
