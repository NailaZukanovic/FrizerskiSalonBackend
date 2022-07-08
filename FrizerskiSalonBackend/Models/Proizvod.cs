using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrizerskiSalonBackend.Models
{
    public class Proizvod
    {
        [Key]
        public int proizvodId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string naziv { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string opis { get; set; }

        public int cena { get; set; }


    }
}
