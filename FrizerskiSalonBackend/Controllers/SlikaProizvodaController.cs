using FrizerskiSalonBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrizerskiSalonBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlikaProizvodaController : ControllerBase
    {
        private readonly FrizerskiSalonContext _context;

        public SlikaProizvodaController(FrizerskiSalonContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SlikaProizvoda>>> Get()
        {
            return Ok(await _context.SlikaProizvoda.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SlikaProizvoda>> Get(int id)
        {
            var hero = await _context.SlikaProizvoda.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SlikaProizvoda>>> AddHero(SlikaProizvoda hero)
        {
            _context.SlikaProizvoda.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SlikaProizvoda.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SlikaProizvoda>>> UpdateHero(SlikaProizvoda request)
        {
            var dbHero = await _context.SlikaProizvoda.FindAsync(request.slikaProizvodaId);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            dbHero.putanja = request.putanja;
            dbHero.proizvod = request.proizvod;
            await _context.SaveChangesAsync();

            return Ok(await _context.SlikaProizvoda.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SlikaProizvoda>>> Delete(int id)
        {
            var dbHero = await _context.SlikaProizvoda.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            _context.SlikaProizvoda.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SlikaProizvoda.ToListAsync());
        }

    }
}