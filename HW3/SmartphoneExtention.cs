namespace HW3;


public static class SmartphoneExtention 
{
    public static void DoubleWork<T>(this T value) where T: IPrintable, IMessenger
    {
        value.Print();
        value.SendMessage();
    }
}