using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models.ViewModel
{
    public class OverviewViewModel
    {
        [Display(Name = "Type of Vehicle")]
        public VehicleType Type { get; set; }

        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }
        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }
        public int Id { get; internal set; }
    }
}
