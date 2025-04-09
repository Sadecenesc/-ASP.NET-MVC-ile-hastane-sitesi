using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hastane1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcilDurumHaberleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EkipEpostalari = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcilDurumHaberleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BolumHakkinda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarihce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Misyon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vizyon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OzelNotlar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolumHakkinda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bolumler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HastaSayisi = table.Column<int>(type: "int", nullable: false),
                    BosYatakSayisi = table.Column<int>(type: "int", nullable: false),
                    Aciklamalar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolumler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asistanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UzmanlikBolgesi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NobetBilgisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    BolumId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asistanlar_Bolumler_BolumId",
                        column: x => x.BolumId,
                        principalTable: "Bolumler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Asistanlar_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OgretimUyeleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SorumluBolumId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgretimUyeleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgretimUyeleri_Bolumler_SorumluBolumId",
                        column: x => x.SorumluBolumId,
                        principalTable: "Bolumler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OgretimUyeleri_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nobetler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Saat = table.Column<TimeSpan>(type: "time", nullable: false),
                    AsistanId = table.Column<int>(type: "int", nullable: false),
                    BolumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nobetler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nobetler_Asistanlar_AsistanId",
                        column: x => x.AsistanId,
                        principalTable: "Asistanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nobetler_Bolumler_BolumId",
                        column: x => x.BolumId,
                        principalTable: "Bolumler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorusmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Başlamazamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bitişzamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AsistanId = table.Column<int>(type: "int", nullable: false),
                    OgretimUyesiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Randevular_Asistanlar_AsistanId",
                        column: x => x.AsistanId,
                        principalTable: "Asistanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_OgretimUyeleri_OgretimUyesiId",
                        column: x => x.OgretimUyesiId,
                        principalTable: "OgretimUyeleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistanlar_BolumId",
                table: "Asistanlar",
                column: "BolumId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistanlar_UserId",
                table: "Asistanlar",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Nobetler_AsistanId",
                table: "Nobetler",
                column: "AsistanId");

            migrationBuilder.CreateIndex(
                name: "IX_Nobetler_BolumId",
                table: "Nobetler",
                column: "BolumId");

            migrationBuilder.CreateIndex(
                name: "IX_OgretimUyeleri_SorumluBolumId",
                table: "OgretimUyeleri",
                column: "SorumluBolumId");

            migrationBuilder.CreateIndex(
                name: "IX_OgretimUyeleri_UserId",
                table: "OgretimUyeleri",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_AsistanId",
                table: "Randevular",
                column: "AsistanId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_OgretimUyesiId",
                table: "Randevular",
                column: "OgretimUyesiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcilDurumHaberleri");

            migrationBuilder.DropTable(
                name: "BolumHakkinda");

            migrationBuilder.DropTable(
                name: "Nobetler");

            migrationBuilder.DropTable(
                name: "Randevular");

            migrationBuilder.DropTable(
                name: "Asistanlar");

            migrationBuilder.DropTable(
                name: "OgretimUyeleri");

            migrationBuilder.DropTable(
                name: "Bolumler");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
