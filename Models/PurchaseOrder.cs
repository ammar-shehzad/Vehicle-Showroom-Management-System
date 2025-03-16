using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Showroom_Management_System.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int purchase_order_id { get; set; }
        public int purchase_vehicle_name { get; set; }
        public int purchase_model_number { get; set; }

        public int purchase_brand_id { get; set; }

        

        public string Color { get; set; }
        public string FuelType { get; set; }
        public string EngineCapacity { get; set; }
        public string Status { get; set; }

        public int purchase_quantity { get; set; }
        public int purchase_totalAmount { get; set; }


        //Navigational properties  

  


        [ForeignKey("purchase_brand_id")]
        public List<Car_Brand>? Car_Brand { get; set; }




    }
}
