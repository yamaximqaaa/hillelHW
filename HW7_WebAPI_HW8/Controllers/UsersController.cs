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
    public ActionResult<Guid> CreateNewUser([FromBody]User user)
    {
        var id = Guid.NewGuid();
        _users.Add(new UserModel()
        {
            Id = id,
            Name = user.Name,
            Login = user.Login
        });
        return Ok(id);
    }

    #endregion

    #region Read

    [HttpGet]
    public ActionResult GetUsers()
    {
        return Ok(_users.ToArray());
    }
    
    [HttpGet("{id}")]
    public ActionResult<UserModel?> GetUserModelById([FromRoute]Guid id)
    {
        var user = _users.FirstOrDefault((x) => x?.Id == id);
        if (user == null) return BadRequest(user);
        return Ok(user);
    }

    #endregion

    #region Update

    [HttpPut("{id}")]
    public ActionResult<UserModel?> UpdateUserModelById(Guid id, [FromQuery]string name, [FromQuery]string login)
    {
        var userIndex = _users.FindIndex((x) => x?.Id == id);
        if (userIndex == -1) return StatusCode(418, new {ErrorMessage = "No such object"});
        _users[userIndex]!.Name = name;
        _users[userIndex]!.Login = login;
        return Ok(_users[userIndex]);
    }

    #endregion

    #region Delete

    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteById([FromRoute] Guid id)
    {
        var result = _users.Remove(_users.Find((x) => x.Id == id));
        if (result == false) return BadRequest(result);
        return Ok(result);
    }

    #endregion
    
    
    
}