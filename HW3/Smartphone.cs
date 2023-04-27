namespace HW3;

public class Smartphone: IPrintable, IMessenger
{
    public string Name { get; set; }
    public int CoresNumbers { get; set; }
    public void Print()
    {
        Console.WriteLine("Smartphone name: {0}. Number of cores: {1}", Name, CoresNumbers);
    }

    public void SendMessage()
    {
        Console.WriteLine("You got 1 new message form {0}!", Name);
    }
}