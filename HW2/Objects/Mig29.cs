using HW2.Interfases;

namespace HW2.Objects;

public class Mig29 : Plane, IMilitary
{
    public int RocketCount { get; set; }
    public void Shoot()
    {
        Console.WriteLine(":(");
        RocketCount--;
    }
}