using GearHeadAutoAPI.Data;
using GearHeadAutoAPI.IRepository;
using GearHeadAutoAPI.Models;
using GearHeadAutoAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GearHeadAutoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoInformationController : ControllerBase
    {
        private readonly IAutoInformation repository;

        //context for the database connection
        private readonly GearHeadAutoContext context;

        //variable for holding the configuration data for login authentication
        private IConfiguration config;

        public AutoInformationController(IConfiguration Config)
        {
            config = Config;
            context = new GearHeadAutoContext();
            repository = new AutoInformationDAL(context, config);
        }

        [HttpGet("GetAllCars", Name = "GetAllCars")]
        [AllowAnonymous]
        public async Task<GetCarsResponseModel> GetAllUsers()
        {
            GetCarsResponseModel response = new GetCarsResponseModel();

            //set up a list to hold the incoming users we will get from the db
            List<AutoInformation> autoList = new List<AutoInformation>();
            try
            {
                autoList = repository.GetAllCars();

                //check the list isn't empty
                if (autoList.Count != 0)
                {
                    response.Status = true;
                    response.StatusCode = 200;
                    response.cars = autoList;
                }
                else
                {
                    //there has been an error
                    response.Status = false;
                    response.Message = "Get Failed";
                    response.StatusCode = 0;
                    response.cars = null;
                }

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Get Failed - " + ex.Message;
                response.StatusCode = 0;
                //there has been an error
                Console.WriteLine(ex.Message);
            }
            return response;
        }
    }
}