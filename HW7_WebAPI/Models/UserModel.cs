namespace HW7_WebAPI.Models;

public class UserModel
{
    public Guid Id { get; init; }
    public string? Name { get; set; }
    public string? Login { get; set; }
}

public record User(string Name, string Login);
