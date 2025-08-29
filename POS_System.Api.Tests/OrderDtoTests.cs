using System.ComponentModel.DataAnnotations;

using Dtos;

public class OrderDtoTests
{
    private List<ValidationResult> ValidateDto(object dto)
    {
        var context = new ValidationContext(dto, null, null);
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(dto, context, results, true);
        return results;
    }

    [Fact]
    public void OrderDto_ValidData_ShouldPassValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "0931112222",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Empty(results);
    }

    [Fact]
    public void OrderDto_MissingFirstName_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            LastName = "Codezavrovich",
            PhoneNumber = "0931112222",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("FirstName"));
    }

    [Fact]
    public void OrderDto_TooLongFirstName_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter is very good name, i am very glade to care it all my life",
            LastName = "Codezavrovich",
            PhoneNumber = "0931112222",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("FirstName"));
    }

    [Fact]
    public void OrderDto_ShortFirstName_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "P",
            LastName = "Codezavrovich",
            PhoneNumber = "0931112222",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("FirstName"));
    }

    [Fact]
    public void OrderDto_NumbersInFirstName_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter1",
            LastName = "Codezavrovich",
            PhoneNumber = "0931112222",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("FirstName"));
    }

    [Fact]
    public void OrderDto_NotOnlyLettersInFirstName_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter!",
            LastName = "Codezavrovich",
            PhoneNumber = "0931112222",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("FirstName"));
    }

    [Fact]
    public void OrderDto_MissingLastName_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter",
            PhoneNumber = "0931112222",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("LastName"));
    }

    [Fact]
    public void OrderDto_TooLongLastName_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich this is my made up surname, in my opinion it looks pretty good and it is quite possible to change my real surname to this",
            PhoneNumber = "0931112222",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("LastName"));
    }

    [Fact]
    public void OrderDto_ShortLastName_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter",
            LastName = "C",
            PhoneNumber = "0931112222",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("LastName"));
    }

    [Fact]
    public void OrderDto_NumbersInLastName_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich1",
            PhoneNumber = "0931112222",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("LastName"));
    }

    [Fact]
    public void OrderDto_NotOnlyLettersInLastName_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich!",
            PhoneNumber = "0931112222",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("LastName"));
    }

    [Fact]
    public void OrderDto_MissingPhoneNumber_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("PhoneNumber"));
    }

    [Fact]
    public void OrderDto_NotValidLengthPhoneNumber_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter",
            PhoneNumber = "911",
            LastName = "Codezavrovich",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("PhoneNumber"));
    }

    [Fact]
    public void OrderDto_NotValidLength2PhoneNumber_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter",
            PhoneNumber = "91152223177854985",
            LastName = "Codezavrovich",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("PhoneNumber"));
    }

    [Fact]
    public void OrderDto_NotOnlyNumbersInPhoneNumber_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter",
            PhoneNumber = "09325525!_",
            LastName = "Codezavrovich",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("PhoneNumber"));
    }

    [Fact]
    public void OrderDto_LettersInPhoneNumber_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter",
            PhoneNumber = "09325525ad",
            LastName = "Codezavrovich",
            Status = "owner"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("PhoneNumber"));
    }

    [Fact]
    public void OrderDto_MissingStatus_ShouldFailValidation()
    {
        var dto = new OrderDto
        {
            FirstName = "Peter",
            PhoneNumber = "09325525ad",
            LastName = "Codezavrovich"
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("Status"));
    }
}

