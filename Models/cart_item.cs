using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Showroom_Management_System.Models
{
    public class cart_item
    {
        [Key]
        public int cart_id { get; set; }

        public int? customer_id { get; set; }

        public int? vehicle_id { get; set; }
        public int? product_quantity { get; set; }

        public int? order_id { get; set; }

        [ForeignKey("customer_id")]
        public Customers? cart_customers { get; set; }

        [ForeignKey("vehicle_id")]
        public Vehicle? cart_vehicle { get; set; }


        [ForeignKey("order_id")]
        public order? cart_order { get; set; }





    }
}
