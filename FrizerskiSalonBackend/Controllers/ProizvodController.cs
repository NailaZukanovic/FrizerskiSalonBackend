using FrizerskiSalonBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrizerskiSalonBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
        private readonly FrizerskiSalonContext _context;

        public ProizvodController(FrizerskiSalonContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Proizvod>>> Get()
        {
            return Ok(await _context.Proizvod.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proizvod>> Get(int id)
        {
            var hero = await _context.Proizvod.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Proizvod>>> AddHero(Proizvod hero)
        {
            _context.Proizvod.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Proizvod.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Proizvod>>> UpdateHero(Proizvod request)
        {
            var dbHero = await _context.Proizvod.FindAsync(request.proizvodId);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            dbHero.naziv = request.naziv;
            dbHero.opis = request.opis;
            dbHero.cena = request.cena;

            await _context.SaveChangesAsync();

            return Ok(await _context.Proizvod.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Proizvod>>> Delete(int id)
        {
            var dbHero = await _context.Proizvod.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            _context.Proizvod.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Proizvod.ToListAsync());
        }

    }
}