using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EquipmentLeaseService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddContractUpdateRequestDBSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("28a9a8a8-38a7-4a94-973a-adf6e2904ff2"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("46e5e51f-8754-49a9-a8f5-e779a6e5767b"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("a22f2b7a-3173-4faf-81b7-177ee950d132"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("ba4e0fa6-1d11-4059-94df-2aeb60899022"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("679ccc15-4f8a-4132-b16f-a0f03890595b"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("7f7d4ba0-56e0-4569-a363-191f4cec33a2"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("818f4e06-f4de-4b4d-af21-2b876e72bec9"));

            migrationBuilder.CreateTable(
                name: "ContractUpdateRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentQuantity = table.Column<int>(type: "int", nullable: true),
                    ProductionFacilityCode = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProcessEquipmentTypeCode = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractUpdateRequests", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProcessEquipmentTypes",
                columns: new[] { "Code", "Area", "Name" },
                values: new object[,]
                {
                    { new Guid("5d5e7550-dfd4-4c7c-9623-734c5f30e722"), 120m, "CNC Machine" },
                    { new Guid("d651c353-58eb-481c-b6cb-c8aec5b14385"), 80m, "Welding Robot" },
                    { new Guid("d8ef4355-2d36-4f11-921c-cd055d4685a6"), 150m, "Conveyor Belt" },
                    { new Guid("e9c7caf8-397d-4e50-a21a-cbf0ff5e4f1f"), 100m, "Packaging Machine" }
                });

            migrationBuilder.InsertData(
                table: "ProductionFacilities",
                columns: new[] { "Code", "Name", "StandardAreaForEquipment" },
                values: new object[,]
                {
                    { new Guid("1ac95ea0-5c25-45a8-966f-843ac7d6374c"), "Factory C - Packaging Area", 1800m },
                    { new Guid("b2b19dd3-6e18-44ca-8375-ba87a580a020"), "Factory B - Assembly Line", 2500m },
                    { new Guid("bccb72d5-3988-4850-b4e1-00a326c4eef2"), "Factory A - Main Building", 1500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractUpdateRequests");

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("5d5e7550-dfd4-4c7c-9623-734c5f30e722"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("d651c353-58eb-481c-b6cb-c8aec5b14385"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("d8ef4355-2d36-4f11-921c-cd055d4685a6"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("e9c7caf8-397d-4e50-a21a-cbf0ff5e4f1f"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("1ac95ea0-5c25-45a8-966f-843ac7d6374c"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("b2b19dd3-6e18-44ca-8375-ba87a580a020"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("bccb72d5-3988-4850-b4e1-00a326c4eef2"));

            migrationBuilder.InsertData(
                table: "ProcessEquipmentTypes",
                columns: new[] { "Code", "Area", "Name" },
                values: new object[,]
                {
                    { new Guid("28a9a8a8-38a7-4a94-973a-adf6e2904ff2"), 100m, "Packaging Machine" },
                    { new Guid("46e5e51f-8754-49a9-a8f5-e779a6e5767b"), 80m, "Welding Robot" },
                    { new Guid("a22f2b7a-3173-4faf-81b7-177ee950d132"), 150m, "Conveyor Belt" },
                    { new Guid("ba4e0fa6-1d11-4059-94df-2aeb60899022"), 120m, "CNC Machine" }
                });

            migrationBuilder.InsertData(
                table: "ProductionFacilities",
                columns: new[] { "Code", "Name", "StandardAreaForEquipment" },
                values: new object[,]
                {
                    { new Guid("679ccc15-4f8a-4132-b16f-a0f03890595b"), "Factory C - Packaging Area", 1800m },
                    { new Guid("7f7d4ba0-56e0-4569-a363-191f4cec33a2"), "Factory A - Main Building", 1500m },
                    { new Guid("818f4e06-f4de-4b4d-af21-2b876e72bec9"), "Factory B - Assembly Line", 2500m }
                });
        }
    }
}
