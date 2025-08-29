using System.ComponentModel.DataAnnotations;

namespace Dtos;

public class OrderDto
{
    [Required(ErrorMessage = "First Name is required")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Name is too long or too short")]
    [RegularExpression("^[A-Za-z -]+$", ErrorMessage = "Not valid Name, must be only latters")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Second Name is required")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Name is too long or too short")]
    [RegularExpression("^[A-Za-z -]+$", ErrorMessage = "Not valid Name, must be only latters")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required")]
    [StringLength(10, MinimumLength =10, ErrorMessage = "Phone number must be valid")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "Not valid phone number, must be only numbers")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Status is required")]
    public string Status { get; set; } = null!;

}