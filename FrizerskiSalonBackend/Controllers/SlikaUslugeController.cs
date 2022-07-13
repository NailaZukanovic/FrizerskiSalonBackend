using FrizerskiSalonBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrizerskiSalonBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlikaUslugeController : ControllerBase
    {
        private readonly FrizerskiSalonContext _context;

        public SlikaUslugeController(FrizerskiSalonContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SlikaUsluge>>> Get()
        {
            return Ok(await _context.SlikaUsluge.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SlikaUsluge>> Get(int id)
        {
            var hero = await _context.SlikaUsluge.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SlikaUsluge>>> AddHero(SlikaUsluge hero)
        {
            _context.SlikaUsluge.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SlikaUsluge.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SlikaUsluge>>> UpdateHero(SlikaUsluge request)
        {
            var dbHero = await _context.SlikaUsluge.FindAsync(request.slikaUslugeId);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            dbHero.putanja = request.putanja;
            dbHero.usluga = request.usluga;
            await _context.SaveChangesAsync();

            return Ok(await _context.SlikaUsluge.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SlikaUsluge>>> Delete(int id)
        {
            var dbHero = await _context.SlikaUsluge.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            _context.SlikaUsluge.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SlikaUsluge.ToListAsync());
        }

    }
}