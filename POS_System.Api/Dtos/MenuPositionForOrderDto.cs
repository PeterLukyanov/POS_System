using System.ComponentModel.DataAnnotations;

namespace Dtos;

public class MenuPositionForOrderDto
{
    [Required(ErrorMessage ="Name is required")]
    public string NameOfPosition { get; set; } = null!;
    
    [Required(ErrorMessage = "Amount is required")]
    [Range(1, 50, ErrorMessage = "Amount is need to be positive and realistic")]
    public int Amount { get; set; }
}