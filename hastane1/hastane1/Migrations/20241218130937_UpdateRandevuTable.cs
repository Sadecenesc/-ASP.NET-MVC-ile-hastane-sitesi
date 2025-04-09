using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hastane1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRandevuTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nobetler_Asistanlar_AsistanId",
                table: "Nobetler");

            migrationBuilder.DropForeignKey(
                name: "FK_Nobetler_Bolumler_BolumId",
                table: "Nobetler");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Asistanlar_AsistanId",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_OgretimUyeleri_OgretimUyesiId",
                table: "Randevular");

            migrationBuilder.AlterColumn<int>(
                name: "OgretimUyesiId",
                table: "Randevular",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AsistanId",
                table: "Randevular",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "OgretimUyeleri",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Adres",
                table: "OgretimUyeleri",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BolumId",
                table: "Nobetler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AsistanId",
                table: "Nobetler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HastaSayisi",
                table: "Bolumler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BosYatakSayisi",
                table: "Bolumler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UzmanlikBolgesi",
                table: "Asistanlar",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Asistanlar",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "NobetBilgisi",
                table: "Asistanlar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Adres",
                table: "Asistanlar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Nobetler_Asistanlar_AsistanId",
                table: "Nobetler",
                column: "AsistanId",
                principalTable: "Asistanlar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nobetler_Bolumler_BolumId",
                table: "Nobetler",
                column: "BolumId",
                principalTable: "Bolumler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Asistanlar_AsistanId",
                table: "Randevular",
                column: "AsistanId",
                principalTable: "Asistanlar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_OgretimUyeleri_OgretimUyesiId",
                table: "Randevular",
                column: "OgretimUyesiId",
                principalTable: "OgretimUyeleri",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nobetler_Asistanlar_AsistanId",
                table: "Nobetler");

            migrationBuilder.DropForeignKey(
                name: "FK_Nobetler_Bolumler_BolumId",
                table: "Nobetler");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Asistanlar_AsistanId",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_OgretimUyeleri_OgretimUyesiId",
                table: "Randevular");

            migrationBuilder.AlterColumn<int>(
                name: "OgretimUyesiId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AsistanId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "OgretimUyeleri",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adres",
                table: "OgretimUyeleri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BolumId",
                table: "Nobetler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AsistanId",
                table: "Nobetler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HastaSayisi",
                table: "Bolumler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BosYatakSayisi",
                table: "Bolumler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UzmanlikBolgesi",
                table: "Asistanlar",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Asistanlar",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NobetBilgisi",
                table: "Asistanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adres",
                table: "Asistanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Nobetler_Asistanlar_AsistanId",
                table: "Nobetler",
                column: "AsistanId",
                principalTable: "Asistanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nobetler_Bolumler_BolumId",
                table: "Nobetler",
                column: "BolumId",
                principalTable: "Bolumler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Asistanlar_AsistanId",
                table: "Randevular",
                column: "AsistanId",
                principalTable: "Asistanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_OgretimUyeleri_OgretimUyesiId",
                table: "Randevular",
                column: "OgretimUyesiId",
                principalTable: "OgretimUyeleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
