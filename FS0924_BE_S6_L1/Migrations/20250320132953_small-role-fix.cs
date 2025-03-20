using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FS0924_BE_S6_L1.Migrations
{
    /// <inheritdoc />
    public partial class smallrolefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "StudenteId",
                keyValue: new Guid("7b3c3520-95c5-4e9b-b7ce-d29eee9319c1"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "DB5AE2D5-1966-4885-82BF-05FB79EEDDF5", "DB5AE2D5-1966-4885-82BF-05FB79EEDDF5", "Studente", "STUDENTE" },
                    { "E47D581A-E477-40DA-AC5D-276F07F59142", "E47D581A-E477-40DA-AC5D-276F07F59142", "Admin", "ADMIN" },
                    { "EB589A41-5B71-41E7-A754-81764E7CCA23", "EB589A41-5B71-41E7-A754-81764E7CCA23", "Docente", "DOCENTE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "DB5AE2D5-1966-4885-82BF-05FB79EEDDF5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "E47D581A-E477-40DA-AC5D-276F07F59142");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EB589A41-5B71-41E7-A754-81764E7CCA23");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "1", "Owner", "OWNER" },
                    { "2", "2", "Admin", "ADMIN" },
                    { "3", "3", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Studenti",
                columns: new[] { "StudenteId", "Cognome", "DataDiNascita", "Email", "Nome" },
                values: new object[] { new Guid("7b3c3520-95c5-4e9b-b7ce-d29eee9319c1"), "Tonti", new DateTime(1996, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "federico.tonti@gmail.com", "Federico" });
        }
    }
}
