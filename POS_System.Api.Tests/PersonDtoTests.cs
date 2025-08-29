using System.ComponentModel.DataAnnotations;

using Dtos;

public class PersonDtoTests
{
    private List<ValidationResult> ValidateDto(object dto)
    {
        var context = new ValidationContext(dto, null, null);
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(dto, context, results, true);
        return results;
    }

    [Fact]
    public void PersonDto_ValidData_ShouldPassValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Empty(results);
    }

    [Fact]
    public void PersonDto_MissingFirstName_ShouldFaildValidation()
    {
        var dto = new PersonDto
        {
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("FirstName"));
    }

    [Fact]
    public void PersonDto_ShortFirstName_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "P",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("FirstName"));
    }

    [Fact]
    public void PersonDto_TooLongFirstName_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter is very good name, i am very glade to care it all my life",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("FirstName"));
    }

    [Fact]
    public void PersonDto_NotOnlyLattersInFirstName_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter!",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("FirstName"));
    }
    [Fact]
    public void PersonDto_NumbersInFirstName_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter10",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("FirstName"));
    }

    [Fact]
    public void PersonDto_MissingLastName_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("LastName"));
    }

    [Fact]
    public void PersonDto_ShortLastName_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "C",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("LastName"));
    }

    [Fact]
    public void PersonDto_TooLongLastName_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich this is my made up surname, in my opinion it looks pretty good and it is quite possible to change my real surname to this",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("LastName"));
    }

    [Fact]
    public void PersonDto_NotOnlyLattersInLastName_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich!",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("LastName"));
    }

    [Fact]
    public void PersonDto_NumbersInLastName_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich1",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("LastName"));
    }

    [Fact]
    public void PersonDto_MissingPhoneNumber_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("PhoneNumber"));
    }

    [Fact]
    public void PersonDto_NotValidLengthPhoneNumber_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "093",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("PhoneNumber"));
    }

    [Fact]
    public void PersonDto_LettersInPhoneNumber_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "09311112ab",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("PhoneNumber"));
    }

    [Fact]
    public void PersonDto_NotNumbersInPhoneNumber_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "09311112!_",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("PhoneNumber"));
    }

    [Fact]
    public void PersonDto_MissingStatus_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            BirthdayYear = 2000,
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("Status"));
    }

    [Fact]
    public void PersonDto_MissingBirthdayYear_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("BirthdayYear"));
    }

    [Fact]
    public void PersonDto_OutOfRangeBirthdayYear_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            BirthdayYear = 1500,
            Status = "owner",
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("BirthdayYear"));
    }

    [Fact]
    public void PersonDto_OutOfRange2BirthdayYear_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            BirthdayYear = 2026,
            Status = "owner",
            BirthdayMonth = 6,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("BirthdayYear"));
    }
    [Fact]
    public void PersonDto_MissingBirthdayMonth_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("BirthdayMonth"));
    }

    [Fact]
    public void PersonDto_OutOfRangeBirthdayMonth_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear = 2000,
            BirthdayMonth = 0,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("BirthdayMonth"));
    }

    [Fact]
    public void PersonDto_OutOfRange2BirthdayMonth_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            BirthdayYear = 2026,
            Status = "owner",
            BirthdayMonth = 13,
            BirthdayDay = 15
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("BirthdayMonth"));
    }
    
     [Fact]
    public void PersonDto_MissingBirthdayDay_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear=2000,
            BirthdayMonth=6,
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("BirthdayDay"));
    }

    [Fact]
    public void PersonDto_OutOfRangeBirthdayDay_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            Status = "owner",
            BirthdayYear=2000,
            BirthdayMonth = 6,
            BirthdayDay = 0
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("BirthdayDay"));
    }

    [Fact]
    public void PersonDto_OutOfRange2BirthdayDay_ShouldFailValidation()
    {
        var dto = new PersonDto
        {
            FirstName = "Peter",
            LastName = "Codezavrovich",
            PhoneNumber = "0931111222",
            BirthdayYear = 2026,
            Status = "owner",
            BirthdayMonth = 6,
            BirthdayDay = 32
        };
        var results = ValidateDto(dto);
        Assert.Contains(results, r => r.MemberNames.Contains("BirthdayDay"));
    }  
}