using System.ComponentModel.DataAnnotations;

namespace Vehicle_Showroom_Management_System.Models
{
    public class searchVehicle
    {
        [Required]
        public int? Search_vehicle_Name { get; set; }
        [Required]
        public int Search_vehicle_Branch { get; set; }

    }
}
