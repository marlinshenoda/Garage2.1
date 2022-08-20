using System.ComponentModel;

namespace Garage2._0.Models.ViewModels
{
    #nullable disable
    public class VehicleIndexViewModel
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        public string MemberFullName { get; set; }

        [DisplayName("Registration Number")]
        public string RegNr { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        [DisplayName("Number of Wheels")]
        public int NrOfWheels { get; set; }

        [DisplayName("Id")]
        public string MemberPerNr { get; set; }







    }
}
