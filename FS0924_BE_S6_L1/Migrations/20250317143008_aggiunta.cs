using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FS0924_BE_S6_L1.Migrations
{
    /// <inheritdoc />
    public partial class aggiunta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Studenti",
                columns: new[] { "StudenteId", "Cognome", "DataDiNascita", "Email", "Nome" },
                values: new object[] { new Guid("7b3c3520-95c5-4e9b-b7ce-d29eee9319c1"), "Tonti", new DateTime(1996, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "federico.tonti@gmail.com", "Federico" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "StudenteId",
                keyValue: new Guid("7b3c3520-95c5-4e9b-b7ce-d29eee9319c1"));
        }
    }
}
