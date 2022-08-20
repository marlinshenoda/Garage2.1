
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models
{
#nullable disable
    public class ReceiptViewModel
    {
        public VehicleType Type { get; set; }

        [Display(Name="Registration Number")]
        public string RegNr { get; set; }

        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Leaving Time")]
        public DateTime LeaveTime { get; set; }

        [Display(Name = "Time Parked")]
        public double TimeParked { get; set; }

        public double Price { get; set; }
    }
}
