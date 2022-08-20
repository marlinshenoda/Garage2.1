using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models
{
    public class Member
    {
        public int age;

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [Remote(action: "FirstLastDiff", controller: "Members", ErrorMessage = "First and Last name must be different", AdditionalFields = nameof(FirstName))]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Required(ErrorMessage = "Please enter your social security number!")]
        [Display(Name = "Personal Number")]
        [Remote(action: "IsPerNrUsed", controller: "Members", ErrorMessage = "This ID number is already in use", AdditionalFields = nameof(Id))]
        [MaxLength(13)]
        [MinLength(10)]
        [RegularExpression("[0-9]{6}-[0-9]{4}",ErrorMessage = "Invalid social security number!")]
        public string PerNr { get; set; }
        public DateTime DateOfBirth { get; set; }

        public  int Year { get; set; }
        public bool IsUnderage { get; set; }

        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        
    }
}
