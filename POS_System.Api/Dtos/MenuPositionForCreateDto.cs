using System.ComponentModel.DataAnnotations;

namespace Dtos;

public class MenuPositionForCreateDto
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Name is too long or too short")]
    [RegularExpression("^[A-Za-z -]+$", ErrorMessage = "Not valid Name, must be only latters")]
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    [Required(ErrorMessage = "Cost is required")]
    [Range(0.00001, 100000000, ErrorMessage = "Amount is need to be positive")]
    public double Cost { get; set; }
    [Required(ErrorMessage = "Time is required")]
    [Range(1, 100000000, ErrorMessage = "Time needs to be positive")]
    public int TimeOfPreparation { get; set; }
}