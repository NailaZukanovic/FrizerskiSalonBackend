using Microsoft.EntityFrameworkCore;

namespace FrizerskiSalonBackend.Models
{
    public class FrizerskiSalonContext : DbContext
    {

        public DbSet<Korisnik> Korisnik { get; set; }

        public DbSet<Proizvod> Proizvod { get; set; }

        public DbSet<SlikaProizvoda> SlikaProizvoda { get; set; }

        public DbSet<SlikaUsluge> SlikaUsluge { get; set; }

        public DbSet<Usluga> Usluga { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=salon; Integrated Security=True;");
        }
    }
}
