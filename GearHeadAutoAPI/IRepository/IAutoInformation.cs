using GearHeadAutoAPI.Data;

namespace GearHeadAutoAPI.IRepository
{
    internal interface IAutoInformation
    {
        /// Method that retrieves all cars in the database
        /// </summary>
        /// <returns></returns>
        public List<AutoInformation> GetAllCars();
    }
}