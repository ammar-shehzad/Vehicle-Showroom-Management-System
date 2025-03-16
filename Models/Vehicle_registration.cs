using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vehicle_Showroom_Management_System.Models
{
    public class Vehicle_registration
    {
        [Key]
        public int registration_id { get; set; }
        public int registration_vehicle_id { get; set; }

        public int? registration_branch_id { get; set; }
        public int? registration_brand_id { get; set; }

        public string registration_chassis_Number { get; set; }
        public string Registration_Number { get; set; }


        //navigational_property

        [ForeignKey("registration_vehicle_id")]
        public Vehicle? Vehicle { get; set; }


        [ForeignKey("registration_branch_id")]
        public branch? branch { get; set; }

        [ForeignKey("registration_brand_id")]
        public Car_Brand? car_Brand { get; set; }

    }
}
