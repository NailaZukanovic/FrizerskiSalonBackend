using FrizerskiSalonBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FrizerskiSalonBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly FrizerskiSalonContext _context;

        public IConfiguration _configuration;

        public TokenController(FrizerskiSalonContext context, IConfiguration configuration)
        {
            _context = context;

            _configuration = configuration;
        }

        private async Task<Korisnik> getKorisnikByUsernamePassword(string email, string password)
        {
            return await _context.Korisnik.FirstOrDefaultAsync(k => k.email == email && k.password == password);
        }

        [HttpPost]
        public async Task<IActionResult> post(Korisnik korisnik)
        {
            if(korisnik != null && korisnik.email != null && korisnik.password != null)
            {
                Korisnik korisnikInfo = await getKorisnikByUsernamePassword(korisnik.email, korisnik.password);

                if(korisnikInfo != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("korisnikId",korisnik.korisnikId.ToString()),
                        new Claim("email",korisnik.email),
                        new Claim("password",korisnik.password)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
