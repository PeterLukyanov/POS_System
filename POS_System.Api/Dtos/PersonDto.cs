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

    [Required(ErrorMessage = "Year of birthday is required")]
    [Range(1900,2019, ErrorMessage ="Year of birthday must be in the range from 1900 to 2019")]
    public int BirthdayYear { get; set; }

    [Required(ErrorMessage = "Month of birthday is required")]
    [Range(1,12,ErrorMessage ="Month number must be from 1 to 12")]
    public int BirthdayMonth { get; set; }

    [Required(ErrorMessage = "Day of birthday is required")]
    [Range(1,31, ErrorMessage ="Day number must be from 1 to 31")]
    public int BirthdayDay { get; set; }
}