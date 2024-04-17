using Donation_Platform_For_Education.Application.DTOs.Authentication.Request;
using Donation_Platform_For_Education.Application.DTOs.Authentication.Response;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IAuthenticationService = Donation_Platform_For_Education.Application.Abstraction.ServiceAbs.IAuthenticationService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Donation_Platform_For_Education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public AuthenticationController(IAuthenticationService authenticationService, UserManager<IdentityUser<Guid>> userManager)
        {
            _authenticationService = authenticationService;
            _userManager = userManager;
        }

        // GET: api/<AuthenticationController>
        [HttpPost("StudentRegister")]
        public async Task<IActionResult> RegsiterStudent([FromBody] RegisterRequest value)
        {
            var result = await _authenticationService.Register(value.Username,value.Email,value.Password,"Student");

            return Ok(result);
        }

        // GET: api/<AuthenticationController>
        [HttpPost("DonorRegister")]
        public async Task<IActionResult> RegsiterDonor([FromBody] RegisterRequest value)
        {
            var result = await _authenticationService.Register(value.Username, value.Email, value.Password, "Donor");

            return Ok(result);
        }

        // GET: api/<AuthenticationController>
        [HttpPost("StudentLogin")]
        public async Task<IActionResult> StudentLogin([FromBody] LoginRequest value)
        {
            var result = await _authenticationService.Login(value.username,value.password,"Student");

            return Ok(result);
        }

        // GET: api/<AuthenticationController>
        [HttpPost("DonorLogin")]
        public async Task<IActionResult> DonorLogin([FromBody] LoginRequest value)
        {
            var result = await _authenticationService.Login(value.username, value.password, "Donor");

            return Ok(result);
        }

        // GET: api/<AuthenticationController>
        [HttpPost("AdminLogin")]
        public async Task<IActionResult> AdminLogin([FromBody] LoginRequest value)
        {
            var result = await _authenticationService.Login(value.username, value.password, "Admin");

            return Ok(result);
        }

        [HttpGet("AllowAccess/{token}")]
        public async Task<IActionResult> AllowAccess(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            var claims = jsonToken.Claims;

            var claimIdenity = new ClaimsIdentity(jsonToken.Claims);
            var principle = new ClaimsPrincipal(claimIdenity);
            string userid = claims.FirstOrDefault(x => x.Type == "userid").Value;
            string username = claims.FirstOrDefault(x => x.Type == "username").Value;
            string email = claims.FirstOrDefault(x => x.Type == "email").Value;
            string role = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            
            var response = new AllowAccessResponse(userid, username, role, email, token);

            return Ok(response);
        }

        [HttpGet("CheckUsername/{username}")]
        public async Task<IActionResult> CheckUsername(string username)
        {
            var result = _userManager.FindByNameAsync(username).Result;

            return Ok(result != null ? true : false);
        }


        //// GET api/<AuthenticationController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<AuthenticationController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<AuthenticationController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AuthenticationController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
