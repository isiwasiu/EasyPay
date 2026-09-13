using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NibssNPSPaymentStack.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate823323327 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "TokenMgt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creationdatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    access_token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expires_in = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenMgt", x => x.Id);
                });

                }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
                    }
    }
}
