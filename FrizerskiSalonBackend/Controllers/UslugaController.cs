using FrizerskiSalonBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrizerskiSalonBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UslugaController : ControllerBase
    {
        private readonly FrizerskiSalonContext _context;

        public UslugaController(FrizerskiSalonContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usluga>>> Get()
        {
            return Ok(await _context.Usluga.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usluga>> Get(int id)
        {
            var hero = await _context.Usluga.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Usluga>>> AddHero(Usluga hero)
        {
            _context.Usluga.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Usluga.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Usluga>>> UpdateHero(Usluga request)
        {
            var dbHero = await _context.Usluga.FindAsync(request.UslugaId);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            dbHero.Naziv = request.Naziv;
            dbHero.Opis = request.Opis;
            dbHero.Cena = request.Cena;

            await _context.SaveChangesAsync();

            return Ok(await _context.Usluga.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Usluga>>> Delete(int id)
        {
            var dbHero = await _context.Usluga.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            _context.Usluga.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Usluga.ToListAsync());
        }

    }
}