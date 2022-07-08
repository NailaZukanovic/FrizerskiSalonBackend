using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrizerskiSalonBackend.Models
{
    public class SlikaUsluge
    {
        [Key]
        public int slikaUslugeId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string putanja { get; set; }

        [ForeignKey("Usluga")]
        public int usluga { get; set; }
    }
}
