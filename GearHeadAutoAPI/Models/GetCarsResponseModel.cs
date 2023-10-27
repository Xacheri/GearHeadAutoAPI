using GearHeadAutoAPI.Data;

namespace GearHeadAutoAPI.Models
{
    public class GetCarsResponseModel
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<AutoInformation> cars { get; set; }


    }
}