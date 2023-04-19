namespace HW2.Interfases;

interface ICommercial
{
    public decimal TicketPrice { get; set; }

    public void PurchaseTicket();
}