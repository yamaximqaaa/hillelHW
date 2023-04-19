namespace HW2.Objects;

public class Airship : Aircraft
{
    public decimal AirTankSize { get; set; }
    public override void FullInfo()
    {
        base.FullInfo();
        Console.WriteLine("Air tank size: {0}", AirTankSize);
    }
}