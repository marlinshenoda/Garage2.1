using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models
{
    #nullable disable
    public class VehicleDetailsViewModel
    {   
        public int Id { get; set; }
        [Display(Name = "Owner's Name")]
        public string FullName { get; set; }
        [Display(Name = "Owner's ID")]
        public string PerNr { get; set; }
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        [Display(Name = "Number of Wheels")]
        public int NrOfWheels { get; set; }
        public string Type { get; set; }
    }
}
