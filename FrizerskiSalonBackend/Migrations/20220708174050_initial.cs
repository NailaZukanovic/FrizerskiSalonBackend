using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrizerskiSalonBackend.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    korisnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    adresa = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    telefon = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    tip = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.korisnikId);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    proizvodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.proizvodId);
                });

            migrationBuilder.CreateTable(
                name: "SlikaProizvoda",
                columns: table => new
                {
                    slikaProizvodaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    putanja = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    proizvod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlikaProizvoda", x => x.slikaProizvodaId);
                });

            migrationBuilder.CreateTable(
                name: "SlikaUsluge",
                columns: table => new
                {
                    slikaUslugeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    putanja = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    usluga = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlikaUsluge", x => x.slikaUslugeId);
                });

            migrationBuilder.CreateTable(
                name: "Usluga",
                columns: table => new
                {
                    UslugaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluga", x => x.UslugaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "SlikaProizvoda");

            migrationBuilder.DropTable(
                name: "SlikaUsluge");

            migrationBuilder.DropTable(
                name: "Usluga");
        }
    }
}
