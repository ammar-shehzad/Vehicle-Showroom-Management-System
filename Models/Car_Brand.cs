using System.ComponentModel.DataAnnotations;

namespace Vehicle_Showroom_Management_System.Models
{
    public class Car_Brand
    {
        [Key]
        public int Brand_Id { get; set; }

        [Required]
        public string Brand_Name { get; set; }


        public string Brand_Image { get; set; }


    }
}
