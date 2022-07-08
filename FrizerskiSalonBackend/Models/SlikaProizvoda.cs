using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FrizerskiSalonBackend.Models
{
    public class SlikaProizvoda
    {
        [Key]
        public int slikaProizvodaId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string putanja { get; set; }

        [ForeignKey("Proizvod")]
        public int proizvod { get; set; }
    }
}
