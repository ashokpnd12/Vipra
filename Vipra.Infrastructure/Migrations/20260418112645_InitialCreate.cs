using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vipra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Panditjis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Experience = table.Column<byte>(type: "tinyint", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panditjis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    SpecializationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.SpecializationId);
                });

            migrationBuilder.CreateTable(
                name: "Yajmans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gotra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yajmans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PanditjiSpecializations",
                columns: table => new
                {
                    PanditjiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecializationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanditjiSpecializations", x => new { x.PanditjiId, x.SpecializationId });
                    table.ForeignKey(
                        name: "FK_PanditjiSpecializations_Panditjis_PanditjiId",
                        column: x => x.PanditjiId,
                        principalTable: "Panditjis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PanditjiSpecializations_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "SpecializationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YajmanPanditjis",
                columns: table => new
                {
                    PanditjiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YajmanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YajmanPanditjis", x => new { x.PanditjiId, x.YajmanId });
                    table.ForeignKey(
                        name: "FK_YajmanPanditjis_Panditjis_PanditjiId",
                        column: x => x.PanditjiId,
                        principalTable: "Panditjis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YajmanPanditjis_Yajmans_YajmanId",
                        column: x => x.YajmanId,
                        principalTable: "Yajmans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PanditjiSpecializations_SpecializationId",
                table: "PanditjiSpecializations",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_YajmanPanditjis_YajmanId",
                table: "YajmanPanditjis",
                column: "YajmanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PanditjiSpecializations");

            migrationBuilder.DropTable(
                name: "YajmanPanditjis");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Panditjis");

            migrationBuilder.DropTable(
                name: "Yajmans");
        }
    }
}
