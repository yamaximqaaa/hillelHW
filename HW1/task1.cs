namespace HW1;

#region Base Class

public class Aircraft
{
    public string Name { get; set; }
    public string Size { get; set; }
    public string EngineType { get; set; }

    public bool IsAloft { get; set; }

    public void Takeoff()
    {
        IsAloft = true;
    }

    public virtual void FullInfo()
    {
        Console.WriteLine("Name: {0}", Name);
        Console.WriteLine("Size: {0}", Size);
        Console.WriteLine("Engine type: {0}", EngineType);
    }
}

#endregion

#region Derived Class

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

public class Helicopter : Aircraft
{
    public int BladesCount { get; set; }
    public override void FullInfo()
    {
        base.FullInfo();
        Console.WriteLine("Blades count: {0}", BladesCount);
    }
}

public class Airship : Aircraft
{
    public decimal AirTankSize { get; set; }
    public override void FullInfo()
    {
        base.FullInfo();
        Console.WriteLine("Air tank size: {0}", AirTankSize);
    }
}

public class Mig29 : Plane, IMilitary
{
    public int RocketCount { get; set; }
    public void Shoot()
    {
        Console.WriteLine(":(");
        RocketCount--;
    }
}

public class Boeing787 : Plane, ICommercial
{
    public decimal TicketPrice { get; set; }
    public void PurchaseTicket()
    {
        Console.WriteLine("Thanks for using our company!");
    }
}

#endregion


#region Interface

interface IMilitary
{
    public int RocketCount { get; set; }

    public void Shoot();
}

interface ICommercial
{
    public decimal TicketPrice { get; set; }

    public void PurchaseTicket();
}

#endregion