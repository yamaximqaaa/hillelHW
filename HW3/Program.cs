// See https://aka.ms/new-console-template for more information
using HW3;
#region Task 1-2
{
    var phone = new Factory<Smartphone>().Create();
    phone.Name = "Xiaomi";
    phone.CoresNumbers = 10;

    phone.Print();
}
#endregion

#region Task 3-4
{
    var phone = new Factory<Smartphone>().Create();
    phone.Name = "Xiaomi";
    phone.CoresNumbers = 10;

    phone.DoubleWork(); 
}
#endregion




Console.ReadLine();