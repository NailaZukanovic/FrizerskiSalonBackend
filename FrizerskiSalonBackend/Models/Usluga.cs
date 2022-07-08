using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrizerskiSalonBackend.Models
{
    public class Usluga
    {
        [Key]
        public int UslugaId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Naziv { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Opis { get; set; }

        public int Cena { get; set; }

    }
}
