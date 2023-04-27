namespace HW3;

public class Factory<T> where T : class, new()
{
    public T Create()
    {
        return new T();
    }
}