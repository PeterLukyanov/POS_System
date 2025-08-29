using System.ComponentModel.DataAnnotations;
using Dtos;

public class MenuPositionDtoForOrderTests
{
    private List<ValidationResult> ValidateDto(object dto)
    {
        var context = new ValidationContext(dto, null, null);
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(dto, context, results, true);
        return results;
    }

    [Fact]
    public void MenuPositionForOrderDto_ValidData_ShouldPassValidation()
    {
        var dto = new MenuPositionForOrderDto { NameOfPosition = "Chicken fried", Amount = 1 };
        var results = ValidateDto(dto);
        Assert.Empty(results);
    }

    [Fact]
    public void MenuPositionForOrderDto_MissNameOfPosition_ShouldFaildValidation()
    {
        var dto = new MenuPositionForOrderDto { Amount = 1 };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("NameOfPosition"));
    }

    [Fact]
    public void MenuPositionForOrderDto_MissAmount_ShouldFailValidation()
    {
        var dto = new MenuPositionForOrderDto { NameOfPosition = "Chicken fried" };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("Amount"));
    }

    [Fact]
    public void MenuPositionForOrderDto_ZeroAmount_ShouldFailValidation()
    {
        var dto = new MenuPositionForOrderDto { NameOfPosition = "Chicken fried", Amount = 0 };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("Amount"));
    }

    [Fact]
    public void MenuPositionForOrderDto_NegativeAmount_ShouldFailValidation()
    {
        var dto = new MenuPositionForOrderDto { NameOfPosition = "Chicken fried", Amount = -1 };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("Amount"));
    }
    
}