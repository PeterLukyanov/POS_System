using System.ComponentModel.DataAnnotations;
using Dtos;

namespace POS_System.Api.Tests;

public class MenuPositionDtoForCreateTests
{
    private List<ValidationResult> ValidateDto(object dto)
    {
        var context = new ValidationContext(dto, null, null);
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(dto, context, results, true);
        return results;
    }

    [Fact]
    public void MenuPositionDtoForCreate_ValidData_ShouldPassValidation()
    {
        var dto = new MenuPositionForCreateDto { Name = "Chicken fried", Description = "The chicken is deep fried and served with mashed potatoes.", Cost = 250, TimeOfPreparation = 20 };
        var results = ValidateDto(dto);
        Assert.Empty(results);
    }

    [Fact]
    public void MenuPositionDtoForCreate_MissingName_ShouldFailValidation()
    {
        var dto = new MenuPositionForCreateDto { Description = "The chicken is deep fried and served with mashed potatoes.", Cost = 250, TimeOfPreparation = 20 };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("Name"));
    }

    [Fact]
    public void MenuPositionDtoForCreate_MissingCost_ShouldFailValidation()
    {
        var dto = new MenuPositionForCreateDto { Name = "Chicken fried", Description = "The chicken is deep fried and served with mashed potatoes.", TimeOfPreparation = 20 };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("Cost"));
    }

    [Fact]
    public void MenuPositionDtoForCreate_MissingTimeOfPreparation_ShouldFailValidation()
    {
        var dto = new MenuPositionForCreateDto { Name = "Chicken fried", Description = "The chicken is deep fried and served with mashed potatoes.", Cost = 250 };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("TimeOfPreparation"));
    }

    [Fact]
    public void MenuPositionDtoForCreate_TooShortName_ShouldFailValidation()
    {
        var dto = new MenuPositionForCreateDto { Name = "CK", Description = "The chicken is deep fried and served with mashed potatoes.", Cost = 250, TimeOfPreparation = 20 };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("Name"));
    }

    [Fact]
    public void MenuPositionDtoForCreate_TooLongName_ShouldFailValidation()
    {
        var dto = new MenuPositionForCreateDto { Name = "Chicken roasted by the gods of cooking themselves, chicken of royal blood, given wine in the morning and massaged in the evening", Description = "The chicken is deep fried and served with mashed potatoes.", Cost = 250, TimeOfPreparation = 20 };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("Name"));
    }

    [Fact]
    public void MenuPositionDtoForCreate_ZeroCost_ShouldFailValidation()
    {
        var dto = new MenuPositionForCreateDto { Name = "Chicken fried", Description = "The chicken is deep fried and served with mashed potatoes.", Cost = 0, TimeOfPreparation = 20 };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("Cost"));
    }

    [Fact]
    public void MenuPositionDtoForCreate_NegativeCost_ShouldFailValidation()
    {
        var dto = new MenuPositionForCreateDto { Name = "Chicken fried", Description = "The chicken is deep fried and served with mashed potatoes.", Cost = -250, TimeOfPreparation = 20 };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("Cost"));
    }

    [Fact]
    public void MenuPositionDtoForCreate_ZeroTimeOfPreparation_ShouldFailValidation()
    {
        var dto = new MenuPositionForCreateDto { Name = "Chicken fried", Description = "The chicken is deep fried and served with mashed potatoes.", Cost = 250, TimeOfPreparation = 0 };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("TimeOfPreparation"));
    }

    [Fact]
    public void MenuPositionDtoForCreate_NegativeTimeOfPreparation_ShouldFailValidation()
    {
        var dto = new MenuPositionForCreateDto { Name = "Chicken fried", Description = "The chicken is deep fried and served with mashed potatoes.", Cost = 250, TimeOfPreparation = -20 };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("TimeOfPreparation"));
    }

}
