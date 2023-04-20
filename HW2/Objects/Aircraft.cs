using HW2.Enums;

namespace HW2.Objects;

public class Aircraft
{
    public string Name { get; set; }
    public string Size { get; set; }
    public string EngineType { get; set; }
    public AircraftColorway Colorway { get; set; }

    public bool IsAloft { get; set; }

    public Aircraft()
    {
        
    }
    public Aircraft(string name, string size, string engineType, AircraftColor color, string aircraftLogoDir)
    {
        Name = name;
        Size = size;
        EngineType = engineType;
        Colorway = new AircraftColorway(color, aircraftLogoDir);
    }
    
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