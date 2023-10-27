using GearHeadAutoAPI.Data;
using GearHeadAutoAPI.IRepository;

namespace GearHeadAutoAPI.Repository
{

    public class AutoInformationDAL : IAutoInformation
    {
        //context for the database connection
        private readonly GearHeadAutoContext context;

        private readonly IConfiguration _config;

        public AutoInformationDAL(GearHeadAutoContext Context, IConfiguration config)
        {
            context = Context;
            _config = config;
        }
        #region Get All Cars Method
        /// <summary>
        /// Method that retrieves all cars in the database
        /// </summary>
        /// <returns></returns>
        public List<AutoInformation> GetAllCars()
        {
            List<AutoInformation> autoList = new List<AutoInformation>();

            try
            {
                //query the database to get all of the autos
                var autos = context.AutoInformations.ToList();

                foreach (var car in autos)
                {
                    autoList.Add(new AutoInformation()
                    {
                        AutoId = car.AutoId,
                        Condition = car.Condition,
                        Year = car.Year,
                        Make = car.Make,
                        Model = car.Model,
                        Color = car.Color,
                        Type = car.Type,
                        Miles = car.Miles,
                        Zip = car.Zip,
                        Price = car.Price,
                        Image = car.Image
                    });
                }

                if (autoList.Count == 0)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAllUsers --- " + ex.Message);
                throw;
            }

            return autoList;
        }
        #endregion
    }
}
