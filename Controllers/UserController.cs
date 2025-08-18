using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  private IUserRepository userRepository;
  public UserController(IUserRepository userRepository)
  {
    this.userRepository = userRepository;
  }
  [Authorize]
  [Authorize(Roles = "Admin")]
  [HttpGet("GetAllUsers")]
  public IActionResult GetUsers()
  {
    var users = userRepository.GetUsers();
    return Ok(users);
  }
  [AllowAnonymous]
  [HttpPost("Register")]
  public void Register(User user)
  {
    userRepository.Register(user);
  }
    [Authorize]
    [AllowAnonymous]
    [HttpPost("Login")]
    public void Login(string Email, string Password)
    {
        userRepository.Login(Email, Password);
    }
   [AllowAnonymous]
  [HttpGet("Profile")]
  public User Profile(string email)
  {
    return userRepository.Profile(email);
  }
  [Authorize]
 
  [HttpPut("Update")]
  public void Update(int id, User user)
  {
    userRepository.Update(id, user);
  }
 [Authorize]

  [HttpDelete("Delete")]
  public void Delete(int id)
  {
    userRepository.Delete(id);
  }
}