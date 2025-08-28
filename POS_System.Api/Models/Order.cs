namespace Models;

public class Order
{
    public int OrderId { get; private set; }
    public int PersonId { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;
    public string Status { get; private set; } = null!;
    public List<MenuPosition> MenuPositions { get; private set; } = null!;
    public TimeSpan TotalTimeOfPreparation { get; private set; }
    public DateTime TimeOfOrderCreate { get; private set; }
    public double TotalSumWithoutDiscount { get; private set; }
    public double TotalSum { get; private set; }
    public double TotalDiscount { get; private set; }

    public Order(int personId,
                string firstName,
                string lastName,
                string phoneNumber,
                TimeSpan totalTimeOfPreparation,
                DateTime timeOfOrderCreate,
                double totalSumWithoutDiscount,
                double totalSum,
                double totalDiscount,
                string status
                )
    {
        PersonId = personId;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        TotalTimeOfPreparation = totalTimeOfPreparation;
        TimeOfOrderCreate = timeOfOrderCreate;
        TotalSumWithoutDiscount = totalSumWithoutDiscount;
        TotalSum = totalSum;
        TotalDiscount = totalDiscount;
        Status = status;
        MenuPositions = new List<MenuPosition>();
    }

    public void SetPersonId(int newPersonId)
    {
        PersonId = newPersonId;
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

    public void SetTotalTimeOfPreparation(TimeSpan newTotalTimeOfPreparation)
    {
        TotalTimeOfPreparation = newTotalTimeOfPreparation;
    }

    public void SetTimeOfOrderCreate(DateTime newTimeOfOrderCreate)
    {
        TimeOfOrderCreate = newTimeOfOrderCreate;
    }

    public void SetTotalSumWithoutDiscount(double newTotalSumWithoutDiscount)
    {
        TotalSumWithoutDiscount = newTotalSumWithoutDiscount;
    }

    public void SetTotalSum(double newTotalSum)
    {
        TotalSum = newTotalSum;
    }

    public void SetTotalDiscount(double newTotalDiscount)
    {
        TotalDiscount = newTotalDiscount;
    }

    public void SetStatus(string status)
    {
        Status = status;
    }

    public void SetMenuPositions(List<MenuPosition> newMenuPositions)
    {
        MenuPositions = newMenuPositions;
    }
}