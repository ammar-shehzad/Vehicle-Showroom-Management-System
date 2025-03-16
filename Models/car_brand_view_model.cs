using System.ComponentModel.DataAnnotations;

namespace Vehicle_Showroom_Management_System.Models
{
    public class car_brand_view_model
    {

        
        public int Brand_Id { get; set; }

        [Required]
        public string Brand_Name { get; set; }


        public IFormFile Brand_Image { get; set; }
    }
}
