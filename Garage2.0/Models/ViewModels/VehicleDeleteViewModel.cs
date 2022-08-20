using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models.ViewModels
{
    public class VehicleDeleteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        [Display(Name = "Type")]
        public String Type { get; set; }

        [Display(Name = "Number of Wheels")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int NrOfWheels { get; set; }

        [Display(Name = "Owner name")]
        public String Name { get; set; }

        [Display(Name = "Personal Identification Number")]
        public String PerNr { get; set; }

        public bool Parked { get; set; }

        public string ParkingSpace { get; set; }
    }
}
