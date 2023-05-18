using HW7_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW7_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static List<UserModel?> _users = new List<UserModel?>()
    {
        new UserModel()
        {
            Id = Guid.NewGuid(),
            Name = "Jack",
            Login = "jacky666"
        },
        new UserModel()
        {
            Id = Guid.NewGuid(),
            Name = "LeBron",
            Login = "bug007"
        }
    };

    #region Create

    [HttpPost]
    public Guid CreateNewUser([FromBody]User user)
    {
        var id = Guid.NewGuid();
        _users.Add(new UserModel()
        {
            Id = id,
            Name = user.Name,
            Login = user.Login
        });
        return id;
    }

    #endregion

    #region Read

    [HttpGet]
    public IEnumerable<UserModel?> GetUsers()
    {
        return _users.ToArray();
    }
    
    [HttpGet("{id}")]
    public UserModel? GetUserModelById([FromRoute]Guid id)
    {
        return _users.Find((x) => x.Id == id);
    }

    #endregion

    #region Update

    [HttpPut("{id}")]
    public UserModel? UpdateUserModelById(Guid id, [FromQuery]string name, [FromQuery]string login)
    {
        var userIndex = _users.FindIndex((x) => x.Id == id);
        if (userIndex == -1) return null;
        _users[userIndex].Name = name;
        _users[userIndex].Login = login;
        return _users[userIndex];
    }

    #endregion

    #region Delete

    [HttpDelete]
    public bool DeleteById([FromRoute] Guid id)
    {
        return _users.Remove(_users.Find((x) => x.Id == id));
    }

    #endregion
    
    
    
}