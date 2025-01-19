using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EquipmentLeaseService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddContractDateComputedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("4ad11383-bd54-4e4a-8132-3997e58bff13"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("4c0a0202-8842-4c71-83e5-a9e919b23f3b"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("7d3a550a-dad8-43eb-a27e-982b9119ef7e"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("f44c30d1-a47b-4b3a-bec1-f3af1553bef1"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("b6192d97-2c34-4e0d-8771-d8a6902fe4e1"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("dc39d203-a559-4d3b-b030-4b4daa2e3707"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("dcbb0ddb-d3e6-42b8-abd2-5d0fe4ce45d9"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractDate",
                table: "EquipmentPlacementContracts",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractDate",
                table: "EquipmentPlacementContracts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

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
        }
    }
}
