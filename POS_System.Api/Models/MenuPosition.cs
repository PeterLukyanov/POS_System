namespace Models;

public class MenuPosition
{
    public int MenuPositionId { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public double Cost { get; private set; }
    public TimeSpan TimeOfPreparation { get; private set; }

    public MenuPosition(string name, string description, double cost, TimeSpan timeOfPreparation)
    {
        Name = name;
        Description = description;
        Cost = cost;
        TimeOfPreparation = timeOfPreparation;
    }
    public void SetName(string newName)
    {
        Name = newName;
    }

    public void SetDescription(string newDescriprion)
    {
        Description = newDescriprion;
    }

    public void SetCost(double newCost)
    {
        Cost = newCost;
    }

    public void SetTimeOfPreparation(TimeSpan timeOfPreparation)
    {
        TimeOfPreparation = timeOfPreparation;
    }
}