using HW2.Enums;

namespace HW2.Objects;

public class AircraftColorway
{
    public AircraftColor Color { get; set; }
    public string AircraftLogoDir { get; set; }

    public AircraftColorway(AircraftColor color, string aircraftLogoDir)
    {
        Color = color;
        AircraftLogoDir = aircraftLogoDir;
    }
}