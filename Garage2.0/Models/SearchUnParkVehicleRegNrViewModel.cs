using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Garage2._0.Models;

public class SearchUnParkVehicleRegNrViewModel
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Registration Number")]
    [StringLength(6, ErrorMessage = "The registration number must be exactly length 6.", MinimumLength = 6)]
    [Remote(action: "UnparkSearch", controller: "Vehicles")]
    public string? RegNr { get; set; }

}