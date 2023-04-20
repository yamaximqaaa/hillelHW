namespace HW2.Objects;

public class Helicopter : Aircraft
{
    public int BladesCount { get; set; }
    public override void FullInfo()
    {
        base.FullInfo();
        Console.WriteLine("Blades count: {0}", BladesCount);
    }
}