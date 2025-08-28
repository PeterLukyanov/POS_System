using Microsoft.IdentityModel.Tokens;

namespace Models;

public class Person
{
    public int PersonId { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;
    public string Status { get; private set; } = null!;
    public DateOnly Birthday { get; private set; }

    public Person(string firstName, string lastName, string phoneNumber, DateOnly birthday)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Birthday = birthday;
    }
    public void SetFirstName(string newFirstName)
    {
        FirstName = newFirstName;
    }

    public void SetLastName(string newLastName)
    {
        LastName = newLastName;
    }
    public void SetPhoneNumber(string newPhoneNumber)
    {
        PhoneNumber = newPhoneNumber;
    }
    public void SetBirthday(DateOnly newBirthday)
    {
        Birthday = newBirthday;
    }
    public void SetStatus(string status)
    {
        Status = status;
    }
}