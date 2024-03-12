using System.ComponentModel.DataAnnotations;

namespace MvcLab.Models;

public class CatsModel {
    //properties

    [Required]
    [MinLength(2)]
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

    [Required]
    [Display(Name = "Ålder:")]
    public string? Age { get; set; }
}