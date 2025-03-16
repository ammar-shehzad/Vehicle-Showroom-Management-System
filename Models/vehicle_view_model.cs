using System.ComponentModel.DataAnnotations;

namespace Vehicle_Showroom_Management_System.Models
{
    public class vehicle_view_model
    {

        [Key]
        public int vehicle_id { get; set; }
        [Required]
        public string vehicle_name { get; set; }

        [Required]
        public int vehicle_model_number { get; set; }

        [Required]
        public int car_brand_id { get; set; }
        [Required]
        public int branch_id { get; set; }



        [Required]
        public int vehicle_price { get; set; }

        [Required]
        public int QuantityAvailable { get; set; }

[Required]
        public string Color { get; set; }

        [Required]
        public string FuelType { get; set; }

        [Required]
        public string EngineCapacity { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public IFormFile vehicle_image { get; set; }
    }
}
