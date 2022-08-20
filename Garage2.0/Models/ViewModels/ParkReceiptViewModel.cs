using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models.ViewModels
{
    public class ParkReceiptViewModel
    {
        public string Type { get; set; }

        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }

        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Leaving Time")]
        public DateTime LeaveTime { get; set; }

        [Display(Name = "Time Parked")]
        public double TimeParked { get; set; }

        public double Price { get; set; }

        [Display(Name = "Member")]
        public string FullName { get; set; }

        [Display(Name = "Personal Identificaton Number")]
        public string PerNr { get; set; }
    }
}
