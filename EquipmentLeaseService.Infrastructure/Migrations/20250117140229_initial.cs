using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EquipmentLeaseService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessEquipmentTypes",
                columns: table => new
                {
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessEquipmentTypes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ProductionFacilities",
                columns: table => new
                {
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandardAreaForEquipment = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionFacilities", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentPlacementContracts",
                columns: table => new
                {
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentQuantity = table.Column<int>(type: "int", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionFacilityCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessEquipmentTypeCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentPlacementContracts", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_EquipmentPlacementContracts_ProcessEquipmentTypes_ProcessEquipmentTypeCode",
                        column: x => x.ProcessEquipmentTypeCode,
                        principalTable: "ProcessEquipmentTypes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentPlacementContracts_ProductionFacilities_ProductionFacilityCode",
                        column: x => x.ProductionFacilityCode,
                        principalTable: "ProductionFacilities",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ProcessEquipmentTypes",
                columns: new[] { "Code", "Area", "Name" },
                values: new object[,]
                {
                    { new Guid("4ad11383-bd54-4e4a-8132-3997e58bff13"), 120m, "CNC Machine" },
                    { new Guid("4c0a0202-8842-4c71-83e5-a9e919b23f3b"), 100m, "Packaging Machine" },
                    { new Guid("7d3a550a-dad8-43eb-a27e-982b9119ef7e"), 150m, "Conveyor Belt" },
                    { new Guid("f44c30d1-a47b-4b3a-bec1-f3af1553bef1"), 80m, "Welding Robot" }
                });

            migrationBuilder.InsertData(
                table: "ProductionFacilities",
                columns: new[] { "Code", "Name", "StandardAreaForEquipment" },
                values: new object[,]
                {
                    { new Guid("b6192d97-2c34-4e0d-8771-d8a6902fe4e1"), "Factory C - Packaging Area", 1800m },
                    { new Guid("dc39d203-a559-4d3b-b030-4b4daa2e3707"), "Factory A - Main Building", 1500m },
                    { new Guid("dcbb0ddb-d3e6-42b8-abd2-5d0fe4ce45d9"), "Factory B - Assembly Line", 2500m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPlacementContracts_ProcessEquipmentTypeCode",
                table: "EquipmentPlacementContracts",
                column: "ProcessEquipmentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPlacementContracts_ProductionFacilityCode",
                table: "EquipmentPlacementContracts",
                column: "ProductionFacilityCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentPlacementContracts");

            migrationBuilder.DropTable(
                name: "ProcessEquipmentTypes");

            migrationBuilder.DropTable(
                name: "ProductionFacilities");
        }
    }
}
