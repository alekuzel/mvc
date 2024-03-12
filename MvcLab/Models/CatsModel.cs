using System.ComponentModel.DataAnnotations;

namespace MvcLab.Models;

public class CatsModel {
    //properties

    [Required]
    [Display(Name = "Kattens namn:")]
    public string? Name { get; set; }

    [Required]
    [Display(Name = "Ras:")]
    public string? Breed { get; set; }

    [Required]
    [Display(Name = "Färg:")]
    public string? Color { get; set; }

    [Required]
    [Display(Name = "Ålder:")]
    public string? Age { get; set; }
}