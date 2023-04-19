using HW2.Interfases;

namespace HW2.Objects;

public class Boeing787 : Plane, ICommercial
{
    public decimal TicketPrice { get; set; }
    public void PurchaseTicket()
    {
        Console.WriteLine("Thanks for using our company!");
    }
}