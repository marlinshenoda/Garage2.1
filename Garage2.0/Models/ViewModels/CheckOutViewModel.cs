using System.ComponentModel.DataAnnotations;


namespace Garage2._0.Models.ViewModels
{
    public class CheckOutViewModel
    {
        public int Id { get; set; }
        public string RegNr { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public int NrOfWheels { get; set; }

        public DateTime ArrivalTime { get; set; }


        [Display(Name = "Leaving Time")]
        public DateTime LeaveTime { get; set; }

        [Display(Name = "Time Parked")]
        public double TimeParked { get; set; }

        public double Price { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Personal Identificaton Number")]
        public string PerNr { get; set; }

        [Display(Name = "Parking Space")]
        public string ParkSpace { get; set; }
    }
}
