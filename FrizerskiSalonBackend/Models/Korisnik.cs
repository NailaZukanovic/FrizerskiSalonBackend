using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrizerskiSalonBackend.Models
{
    public class Korisnik
    {
        [Key]
        public int korisnikId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ime { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string prezime { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string adresa { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string telefon { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string username { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string password { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string email { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string tip { get; set; }

    }
}
