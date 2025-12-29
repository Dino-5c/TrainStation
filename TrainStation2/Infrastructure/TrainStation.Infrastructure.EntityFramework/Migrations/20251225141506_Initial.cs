using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainStation.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdministratorLastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AdministratorFirstName = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    AdministratorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buyers_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RouteName = table.Column<string>(type: "text", nullable: false),
                    AdministratorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TarifZones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TariffName = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Distance = table.Column<int>(type: "integer", nullable: false),
                    AdministratorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarifZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TarifZones_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StationName = table.Column<string>(type: "character varying(90)", maxLength: 90, nullable: false),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: false),
                    StationStatus = table.Column<int>(type: "integer", nullable: false),
                    TariffZoneId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stations_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stations_TarifZones_TariffZoneId",
                        column: x => x.TariffZoneId,
                        principalTable: "TarifZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BuyDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartStationId = table.Column<Guid>(type: "uuid", nullable: false),
                    EndStationId = table.Column<Guid>(type: "uuid", nullable: false),
                    BuyerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    TicketType = table.Column<int>(type: "integer", nullable: false),
                    PriceProcent = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Stations_EndStationId",
                        column: x => x.EndStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Stations_StartStationId",
                        column: x => x.StartStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_AdministratorId",
                table: "Buyers",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_AdministratorId",
                table: "Routes",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_RouteId",
                table: "Stations",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_TariffZoneId",
                table: "Stations",
                column: "TariffZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_TarifZones_AdministratorId",
                table: "TarifZones",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BuyerId",
                table: "Tickets",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EndStationId",
                table: "Tickets",
                column: "EndStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StartStationId",
                table: "Tickets",
                column: "StartStationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "TarifZones");

            migrationBuilder.DropTable(
                name: "Administrators");
        }
    }
}
