using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XMLWebApiCore.Migrations
{
    public partial class xmlFileProcessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drawings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revision = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinX = table.Column<double>(type: "float", nullable: false),
                    MinY = table.Column<double>(type: "float", nullable: false),
                    MaxX = table.Column<double>(type: "float", nullable: false),
                    MaxY = table.Column<double>(type: "float", nullable: false),
                    LocationX = table.Column<double>(type: "float", nullable: false),
                    LocationY = table.Column<double>(type: "float", nullable: false),
                    DrawingDBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Drawings_DrawingDBId",
                        column: x => x.DrawingDBId,
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
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinX = table.Column<double>(type: "float", nullable: false),
                    MinY = table.Column<double>(type: "float", nullable: false),
                    MaxX = table.Column<double>(type: "float", nullable: false),
                    MaxY = table.Column<double>(type: "float", nullable: false),
                    LocationX = table.Column<double>(type: "float", nullable: false),
                    LocationY = table.Column<double>(type: "float", nullable: false),
                    PersistentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrawingDBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentComponents_Drawings_DrawingDBId",
                        column: x => x.DrawingDBId,
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
                    ComponentClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinX = table.Column<double>(type: "float", nullable: false),
                    MinY = table.Column<double>(type: "float", nullable: false),
                    MaxX = table.Column<double>(type: "float", nullable: false),
                    MaxY = table.Column<double>(type: "float", nullable: false),
                    LocationX = table.Column<double>(type: "float", nullable: false),
                    LocationY = table.Column<double>(type: "float", nullable: false),
                    PersistentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrawingDBId = table.Column<int>(type: "int", nullable: false),
                    CrossPageDrawingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrossPageLinkLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeConnectorSymbols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipeConnectorSymbols_Drawings_DrawingDBId",
                        column: x => x.DrawingDBId,
                        principalTable: "Drawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PipingNetworkSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinX = table.Column<double>(type: "float", nullable: false),
                    MinY = table.Column<double>(type: "float", nullable: false),
                    MaxX = table.Column<double>(type: "float", nullable: false),
                    MaxY = table.Column<double>(type: "float", nullable: false),
                    PersistentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrawingDBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipingNetworkSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipingNetworkSystems_Drawings_DrawingDBId",
                        column: x => x.DrawingDBId,
                        principalTable: "Drawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessInstruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinX = table.Column<double>(type: "float", nullable: false),
                    MinY = table.Column<double>(type: "float", nullable: false),
                    MaxX = table.Column<double>(type: "float", nullable: false),
                    MaxY = table.Column<double>(type: "float", nullable: false),
                    LocationX = table.Column<double>(type: "float", nullable: false),
                    LocationY = table.Column<double>(type: "float", nullable: false),
                    PersistentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrawingDBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessInstruments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessInstruments_Drawings_DrawingDBId",
                        column: x => x.DrawingDBId,
                        principalTable: "Drawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceTagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetTagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceEquipmentTagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetEquipmentTagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrawingDBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessLines_Drawings_DrawingDBId",
                        column: x => x.DrawingDBId,
                        principalTable: "Drawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignalLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersistentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinX = table.Column<double>(type: "float", nullable: false),
                    MinY = table.Column<double>(type: "float", nullable: false),
                    MaxX = table.Column<double>(type: "float", nullable: false),
                    MaxY = table.Column<double>(type: "float", nullable: false),
                    DrawingDBId = table.Column<int>(type: "int", nullable: false),
                    FromID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignalLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignalLines_Drawings_DrawingDBId",
                        column: x => x.DrawingDBId,
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
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinX = table.Column<double>(type: "float", nullable: false),
                    MinY = table.Column<double>(type: "float", nullable: false),
                    MaxX = table.Column<double>(type: "float", nullable: false),
                    MaxY = table.Column<double>(type: "float", nullable: false),
                    LocationX = table.Column<double>(type: "float", nullable: false),
                    LocationY = table.Column<double>(type: "float", nullable: false),
                    EquipmentDBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nozzles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nozzles_Equipments_EquipmentDBId",
                        column: x => x.EquipmentDBId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PipingNetworkSegments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinX = table.Column<double>(type: "float", nullable: false),
                    MinY = table.Column<double>(type: "float", nullable: false),
                    MaxX = table.Column<double>(type: "float", nullable: false),
                    MaxY = table.Column<double>(type: "float", nullable: false),
                    FromID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PipingNetworkSystemDBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipingNetworkSegments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipingNetworkSegments_PipingNetworkSystems_PipingNetworkSystemDBId",
                        column: x => x.PipingNetworkSystemDBId,
                        principalTable: "PipingNetworkSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_DrawingDBId",
                table: "Equipments",
                column: "DrawingDBId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentComponents_DrawingDBId",
                table: "InstrumentComponents",
                column: "DrawingDBId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_EquipmentDBId",
                table: "Nozzles",
                column: "EquipmentDBId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeConnectorSymbols_DrawingDBId",
                table: "PipeConnectorSymbols",
                column: "DrawingDBId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingNetworkSegments_PipingNetworkSystemDBId",
                table: "PipingNetworkSegments",
                column: "PipingNetworkSystemDBId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingNetworkSystems_DrawingDBId",
                table: "PipingNetworkSystems",
                column: "DrawingDBId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessInstruments_DrawingDBId",
                table: "ProcessInstruments",
                column: "DrawingDBId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessLines_DrawingDBId",
                table: "ProcessLines",
                column: "DrawingDBId");

            migrationBuilder.CreateIndex(
                name: "IX_SignalLines_DrawingDBId",
                table: "SignalLines",
                column: "DrawingDBId");
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
                name: "PipingNetworkSegments");

            migrationBuilder.DropTable(
                name: "ProcessInstruments");

            migrationBuilder.DropTable(
                name: "ProcessLines");

            migrationBuilder.DropTable(
                name: "SignalLines");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "PipingNetworkSystems");

            migrationBuilder.DropTable(
                name: "Drawings");
        }
    }
}
