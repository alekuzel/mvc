using System.ComponentModel.DataAnnotations;

//namespace for the model
namespace MvcLab.Models;

//  CatsModel class
public class CatsModel {

    // An integer property for the ID of the cat
    public int Id { get; set; }

    //property for the name of the cat
    // Required attribute means that this field must be provided
    // MinLength attribute sets the minimum length of the string to 1
    [Required]
    [MinLength(1)]
    [Display(Name = "Kattens namn:")]
    public string? Name { get; set; }

    [Required]
    [MinLength(2)]
    [Display(Name = "Ras:")]
    public string? Breed { get; set; }

    [Required] 
    [MinLength(2)]
    [Display(Name = "Färg:")]
    public string? Color { get; set; }

    // property for the age of the cat
    // Required attribute means that this field must be provided
    // The Display attribute sets the display name for this field to "Ålder:"
    [Required]
    [Display(Name = "Ålder:")]
    public string? Age { get; set; }
}