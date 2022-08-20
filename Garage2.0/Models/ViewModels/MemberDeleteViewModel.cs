using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models.ViewModels
{
    public class MemberDeleteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "ID")]
        public string PerNr { get; set; }

        [Display(Name = "Number of owned vehicles")]
        public int Vehicles { get; set; }

        public bool ParkedVehicles { get; set; }
    }
}
