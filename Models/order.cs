using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Showroom_Management_System.Models
{
    public class order
    {

        [Key]


        
        public int order_id { get; set; }
        
        public int? cust_id { get; set; }
        [Required]
        public string? firstname { get; set; }

        [Required]
        public string? country { get; set; }
        [Required]
        public string? address { get; set; }

        [Required]
        public string? city { get; set; }
        
        public string? state { get; set; }
        public int? zip_code { get; set; }

        [Required]
        public string? phone { get; set; }

        [Required]
        public string? email { get; set; }
        [Required]
        public string? payment_method { get; set; }
        
        public string? order_note { get; set; }

        
        public int? order_amount { get; set; }
        
        public string? order_status { get; set; }

        [ForeignKey("cust_id")]
        public Customers? Customers { get; set; }

    }
}
