using GDPR.NetAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GDPR.NetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly UsersContext context;
        private readonly Login tokenService;

        public AuthController(UserManager<IdentityUser> userManager, UsersContext context, Login tokenService)
        {
            this.userManager = userManager;
            this.context = context;
            this.tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Registration request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await userManager.CreateAsync(
                new IdentityUser { UserName = request.Username},
                request.Password
            );
            if (result.Succeeded)
            {
                request.Password = "";
                return CreatedAtAction(nameof(Register), new { username = request.Username}, request);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managedUser = await userManager.FindByNameAsync(request.Username);
            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }
            var isPasswordValid = await userManager.CheckPasswordAsync(managedUser, request.Password);
            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }
            var userInDb = context.Users.FirstOrDefault(u => u.UserName == request.Username);
            if (userInDb is null)
                return Unauthorized();
            var accessToken = tokenService.CreateToken(userInDb);
            await context.SaveChangesAsync();
            return Ok(new AuthResponse
            {
                Token = accessToken
            });
        }
    }
}