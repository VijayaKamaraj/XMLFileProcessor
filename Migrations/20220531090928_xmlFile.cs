using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XMLWebApiCore.Migrations
{
    public partial class xmlFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drawings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinX = table.Column<double>(type: "float", nullable: false),
                    MinY = table.Column<double>(type: "float", nullable: false),
                    MaxX = table.Column<double>(type: "float", nullable: false),
                    MaxY = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinX = table.Column<double>(type: "float", nullable: false),
                    MinY = table.Column<double>(type: "float", nullable: false),
                    MaxX = table.Column<double>(type: "float", nullable: false),
                    MaxY = table.Column<double>(type: "float", nullable: false),
                    LocationX = table.Column<double>(type: "float", nullable: false),
                    LocationY = table.Column<double>(type: "float", nullable: false),
                    DrawingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Drawings_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Drawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinX = table.Column<double>(type: "float", nullable: false),
                    MinY = table.Column<double>(type: "float", nullable: false),
                    MaxX = table.Column<double>(type: "float", nullable: false),
                    MaxY = table.Column<double>(type: "float", nullable: false),
                    LocationX = table.Column<double>(type: "float", nullable: false),
                    LocationY = table.Column<double>(type: "float", nullable: false),
                    PersistentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrawingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentComponents_Drawings_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Drawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PipeConnectorSymbols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinX = table.Column<double>(type: "float", nullable: false),
                    MinY = table.Column<double>(type: "float", nullable: false),
                    MaxX = table.Column<double>(type: "float", nullable: false),
                    MaxY = table.Column<double>(type: "float", nullable: false),
                    LocationX = table.Column<double>(type: "float", nullable: false),
                    LocationY = table.Column<double>(type: "float", nullable: false),
                    PersistentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrawingId = table.Column<int>(type: "int", nullable: false),
                    CrossPageDrawingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrossPageLinkLabel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeConnectorSymbols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipeConnectorSymbols_Drawings_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Drawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nozzles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinX = table.Column<double>(type: "float", nullable: false),
                    MinY = table.Column<double>(type: "float", nullable: false),
                    MaxX = table.Column<double>(type: "float", nullable: false),
                    MaxY = table.Column<double>(type: "float", nullable: false),
                    LocationX = table.Column<double>(type: "float", nullable: false),
                    LocationY = table.Column<double>(type: "float", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nozzles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nozzles_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_DrawingId",
                table: "Equipments",
                column: "DrawingId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentComponents_DrawingId",
                table: "InstrumentComponents",
                column: "DrawingId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_EquipmentId",
                table: "Nozzles",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeConnectorSymbols_DrawingId",
                table: "PipeConnectorSymbols",
                column: "DrawingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstrumentComponents");

            migrationBuilder.DropTable(
                name: "Nozzles");

            migrationBuilder.DropTable(
                name: "PipeConnectorSymbols");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Drawings");
        }
    }
}
