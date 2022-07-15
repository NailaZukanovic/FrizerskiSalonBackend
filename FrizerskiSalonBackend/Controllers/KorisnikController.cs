using FrizerskiSalonBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrizerskiSalonBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly FrizerskiSalonContext _context;

        public KorisnikController(FrizerskiSalonContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Korisnik>>> Get()
        {
            return Ok(await _context.Korisnik.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Korisnik>> Get(int id)
        {
            var hero = await _context.Korisnik.FindAsync(id);
            if (hero == null)
                return BadRequest("Proizovd not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Korisnik>>> AddHero(Korisnik hero)
        {
            _context.Korisnik.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Korisnik.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Korisnik>>> UpdateHero(Korisnik request)
        {
            var dbHero = await _context.Korisnik.FindAsync(request.korisnikId);
            if (dbHero == null)
                return BadRequest("Proizvod not found.");

            dbHero.ime = request.ime;
            dbHero.prezime = request.prezime;
            dbHero.adresa = request.adresa;
            dbHero.telefon = request.telefon;
            dbHero.username = request.username;
            dbHero.password = request.password;
            dbHero.email = request.email;
            dbHero.tip = request.tip;

            await _context.SaveChangesAsync();

            return Ok(await _context.Korisnik.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Korisnik>>> Delete(int id)
        {
            var dbHero = await _context.Korisnik.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Proizvod not found.");

            _context.Korisnik.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Korisnik.ToListAsync());
        }

    }
}