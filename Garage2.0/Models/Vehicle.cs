using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace Garage2._0.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        [StringLength(6, ErrorMessage = "The registration number must be exactly length 6.", MinimumLength = 6)]
        [Remote(action: "IsRegNrUsed", controller: "Vehicles", ErrorMessage = "The Registration number is already in use.", AdditionalFields = nameof(Id))]
        public string RegNr { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        [Display(Name = "Number of Wheels")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int NrOfWheels { get; set; }

        public int MemberId { get; set; }

        public Member Member { get; set; }

        public int VehicleTypeEntityId { get; set; }

        public VehicleTypeEntity VehicleTypeEntity { get; set; }
        
        public Park? Park { get; set; }
    }
}
