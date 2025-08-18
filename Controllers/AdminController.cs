using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]

public class AdminController : ControllerBase
{
  private readonly IAdminRepository _adminRepository;
  public AdminController(IAdminRepository adminRepository)
  {
    this._adminRepository = adminRepository;
  }

  [Authorize(Roles = "Admin")]
  [HttpGet("ListofAdmins")]
  public List<Admin> GetAdmins()
  {
    return _adminRepository.GetAdmins();
  }

  [Authorize(Roles = "Admin")]
  [HttpPost("CreateAdmin")]
  public void Create(Admin admin)
  {
    _adminRepository.Create(admin);
  }
    [AllowAnonymous]
    [HttpGet("Profile")]
    public Admin Profile(string email)
    {
        return _adminRepository.Profile(email);
    }
    [Authorize(Roles = "Admin")]
  [HttpPut("Update")]
  public void Update(int id, Admin admin)
  {
    _adminRepository.Update(id, admin);
  }
 
  [Authorize(Roles = "Admin")]
  [HttpDelete("Delete")]
  public void Delete(int id)
  {
    _adminRepository.Delete(id);
  }
}