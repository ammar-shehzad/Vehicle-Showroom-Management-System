﻿using System.ComponentModel.DataAnnotations;

namespace Vehicle_Showroom_Management_System.Models
{
    public class Customers
    {
        [Key]

        [Required]
        public int Customer_id { get; set; }
        [Required]
        public string? Customer_name { get; set; }
        [Required]
        public string? Customer_email { get; set; }
        [Required]
        public string? Customer_password { get; set; }
        [Required]
        public string? Customer_city { get; set; }
        [Required]
        public string? Customer_address { get; set; }
        
        [Required]
        public int? Customer_phone { get; set; }

    }
}
