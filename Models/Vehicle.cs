using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Showroom_Management_System.Models
{
    public class Vehicle
    {
        [Key]
        public int vehicle_id { get; set; }

        public string vehicle_name { get; set; }

        public int vehicle_model_number { get; set; }





        public int vehicle_price { get; set; }

        public int QuantityAvailable { get; set; }

        public int car_brand_id { get; set; }

        public string Color { get; set; }
        public string FuelType { get; set; }
        public string EngineCapacity { get; set; }
        public string Status { get; set; }
        
        
        public int branch_id { get; set; }

        public string vehicle_image { get; set; }

        [ForeignKey("car_brand_id")]
        public Car_Brand? car_Brand { get; set; }

        [ForeignKey("branch_id")]
        public branch? car_branch { get; set; }

    
}
}

