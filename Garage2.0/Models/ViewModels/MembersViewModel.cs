using System.ComponentModel;

namespace Garage2._0.Models.ViewModels
{
    public class MembersViewModel
    {
        public int Id { get; set; }

        [DisplayName("Member")]
        public string MemberFullName { get; set; }

        [DisplayName("Social Security Number")]
        public string MemberPerNr { get; set; }

        [DisplayName("Number Of Vehicle")]

        public int VehiclesCount { get; set; }

    }
}
