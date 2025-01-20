using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EquipmentLeaseService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFieldContractUpdateRequestToNonNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductionFacilityCode",
                table: "ContractUpdateRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProcessEquipmentTypeCode",
                table: "ContractUpdateRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentQuantity",
                table: "ContractUpdateRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ProcessEquipmentTypes",
                columns: new[] { "Code", "Area", "Name" },
                values: new object[,]
                {
                    { new Guid("2de99022-b4d7-40b1-89da-bffcf90398e0"), 150m, "Conveyor Belt" },
                    { new Guid("79dea589-b04e-41b1-ae0f-e2b1d4576c80"), 80m, "Welding Robot" },
                    { new Guid("e31a19ac-e635-47a9-8521-9149fcbe2097"), 120m, "CNC Machine" },
                    { new Guid("f20ab86a-c900-4460-aaff-d538c6b4be53"), 100m, "Packaging Machine" }
                });

            migrationBuilder.InsertData(
                table: "ProductionFacilities",
                columns: new[] { "Code", "Name", "StandardAreaForEquipment" },
                values: new object[,]
                {
                    { new Guid("9541b978-8049-4103-bde9-9e945e06452c"), "Factory A - Main Building", 1500m },
                    { new Guid("e645aff1-6560-41f0-8ee8-807b5da06c14"), "Factory B - Assembly Line", 2500m },
                    { new Guid("ef26dc17-e682-4fb6-994d-e0e3539e9620"), "Factory C - Packaging Area", 1800m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("2de99022-b4d7-40b1-89da-bffcf90398e0"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("79dea589-b04e-41b1-ae0f-e2b1d4576c80"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("e31a19ac-e635-47a9-8521-9149fcbe2097"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("f20ab86a-c900-4460-aaff-d538c6b4be53"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("9541b978-8049-4103-bde9-9e945e06452c"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("e645aff1-6560-41f0-8ee8-807b5da06c14"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("ef26dc17-e682-4fb6-994d-e0e3539e9620"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductionFacilityCode",
                table: "ContractUpdateRequests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProcessEquipmentTypeCode",
                table: "ContractUpdateRequests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentQuantity",
                table: "ContractUpdateRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
