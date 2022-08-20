using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models
{
    public class ParkingSpacesViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Parking Space")]
        public string NumberSpot { get; set; }

        public bool Occupied { get; set; }

        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Registration Number")]
        public string? RegNr { get; set; }

        public string Type { get; set; }

        [Display(Name = "Owner")]
        public string FullName { get; set; }

        public int VehicleId { get; set; }

    }
}
