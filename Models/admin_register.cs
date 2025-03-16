using System.ComponentModel.DataAnnotations;

namespace Vehicle_Showroom_Management_System.Models
{
    public class admin_register
    {
        [Key]
        public int admin_id { get; set; }

        public string admin_name { get; set; }
        public string admin_email { get; set; }

        public int admin_password { get; set; }

        public string admin_image {  get; set; }

    }
}
