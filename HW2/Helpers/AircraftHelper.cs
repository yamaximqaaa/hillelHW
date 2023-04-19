namespace HW2.Objects;

public static class AircraftHelper
{
    public static void PrintPlanes(IEnumerable<Aircraft> planes)
    {
        foreach (var plane in planes)
        {
            plane.FullInfo();
        }
    }

    public static void SetName(Aircraft plane, string name)
    {
        plane.Name = name;
    }
}