using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QueenBee = table.Column<bool>(type: "bit", nullable: false),
                    BeeBrood = table.Column<bool>(type: "bit", nullable: false),
                    Eggs = table.Column<bool>(type: "bit", nullable: false),
                    Feed = table.Column<bool>(type: "bit", nullable: false),
                    QueenCell = table.Column<bool>(type: "bit", nullable: false),
                    BeeBread = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeehiveDetails_Id = table.Column<int>(type: "int", nullable: false),
                    BeehiveDetails_BeehiveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeehiveDetails_QueenType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeehiveDetails_LastInspection = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspections");
        }
    }
}
