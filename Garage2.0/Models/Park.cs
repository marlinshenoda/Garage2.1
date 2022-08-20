using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models
{
    public class Park
    {
        public int  Id { get; set; }

        [Display(Name = "Arrival Time")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; set; }

        public int VehicleId { get; set; }  

        public Vehicle Vehicle { get; set; }

        public ICollection<ParkingSpace> Spaces { get; set; } = new List<ParkingSpace>();
    }
}
