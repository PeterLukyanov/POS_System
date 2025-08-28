using System.ComponentModel.DataAnnotations;

namespace Dtos;

public class PersonDto
{
    [Required(ErrorMessage = "First Name is required")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Name is too lond or too short")]
    [RegularExpression("^[A-Za-z -]+$", ErrorMessage = "Not valid Name, must be only latters")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Second Name is required")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Name is too lond or too short")]
    [RegularExpression("^[A-Za-z -]+$", ErrorMessage = "Not valid Name, must be only latters")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required")]
    [StringLength(11, ErrorMessage = "Phone number must be valid")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "Not valid phone number, must be only numbers")]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public string Status { get; set; } = null!;
    [Required]
    public DateOnly Birthday { get; set; }
}