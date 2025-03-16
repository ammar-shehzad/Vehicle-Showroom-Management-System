using System.ComponentModel.DataAnnotations;

namespace Vehicle_Showroom_Management_System.Models
{
    public class branch
    {

        [Key]
        public int branch_id { get; set; }

        [Required]
        public string branch_name { get; set; }

    }
}
