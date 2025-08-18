using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
 
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
 
namespace AspCoreJwtDb.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Authorize]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private AppDbContext appDbContext;
        public IConfiguration Configuration { get; }
        public AuthController(IConfiguration configuration, AppDbContext appDbContext)
        {
            Configuration = configuration;
            this.appDbContext = appDbContext;
        }


        #region sending credentials in request headers
        //public IActionResult Post()
        //{
        //    var authorizationHeader = Request.Headers["Authorization"].First();
        //    var key = authorizationHeader.Split(' ')[1];
        //    var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(key)).Split(':');
        //    var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:ServerSecret"]));

        //    User userFound = this.productManagementDbContext.Users.Where(u => u.Email == credentials[0].ToString() && u.Password == credentials[1].ToString()).FirstOrDefault();

        //    if (userFound != null)
        //    {
        //        var result = new
        //        {
        //            token = GenerateToken(serverSecret, userFound)
        //        };
        //        return Ok(result);//status code
        //    }
        //    return BadRequest("Invalid Email/Password");//status code
        //}
        #endregion

        #region sending credentials in body
        // public IActionResult Post([FromBody] User user)
        // {
        //     var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:ServerSecret"]));

        //     User userFound = this.appDbContext
        //         .Users
        //         .Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

        //     if (userFound != null)
        //     {
        //         var result = new
        //         {
        //             token = GenerateToken(serverSecret, userFound)
        //         };
        //         return Ok(result);//status code
        //     }
        //     return BadRequest("Invalid Email/Password");//status code
        // }
       
        [HttpPost]
public IActionResult Post(Login login)
{
    if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
    {
        return BadRequest("Email and password are required.");
    }

    var secret = Configuration["JWT:ServerSecret"];
    if (string.IsNullOrEmpty(secret))
    {
        return StatusCode(500, "JWT secret is not configured.");
    }

    var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

    var userFound = appDbContext.Users.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
    var adminFound = appDbContext.Admins.FirstOrDefault(a => a.Email == login.Email && a.Password == login.Password);

    if (userFound == null && adminFound == null)
    {
        return BadRequest("Invalid Email/Password");
    }

    var token = GenerateToken(serverSecret, userFound, adminFound);

    return Ok( new { token });
}



        #endregion

  private string GenerateToken(SecurityKey key, User user, Admin admin)
{
    var now = DateTime.UtcNow;
    var issuer = Configuration["JWT:Issuer"];
    var audience = Configuration["JWT:Audience"];

    var claims = new List<Claim>();

    if (admin != null)
    {
        claims.Add(new Claim(ClaimTypes.Email, admin.Email ?? ""));
        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
    }
    else if (user != null)
    {
        claims.Add(new Claim(ClaimTypes.Email, user.Email ?? ""));
        claims.Add(new Claim(ClaimTypes.Role, user.Role ?? "User"));
    }
    else
    {
        throw new ArgumentException("Both user and admin are null.");
    }

    var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var handler = new JwtSecurityTokenHandler();
    var token = handler.CreateJwtSecurityToken(issuer, audience, new ClaimsIdentity(claims),
        now, now.AddDays(1), now, signingCredentials);

    return handler.WriteToken(token);
}

        
        
    }
}