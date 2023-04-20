namespace HW2.Objects;

public class Plane : Aircraft
{
    public bool IsManned { get; set; }
    public int PassengerCount { get; set; }

    public override void FullInfo()
    {
        base.FullInfo();
        Console.WriteLine("Controlled by human: {0}", IsManned);
        Console.WriteLine("Passenger count: {0}", PassengerCount);
    }
}