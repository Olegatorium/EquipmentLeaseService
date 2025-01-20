using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EquipmentLeaseService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetCascadeForContractUpdateRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("2d84919b-6f8b-45ad-85bb-a9e8ac768f69"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("364fdf70-d9cd-4125-866e-8e2906828725"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("81e4203a-3e2a-4d85-bf17-dd62be88948c"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("bc54fc1b-ff98-4ac0-b487-b0e34ee911d4"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("7f3592f1-5ab8-436f-b85d-1f7f7ff46d69"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("9841f87c-52d0-4a32-847d-472df95d4c22"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("d429719b-2f25-4fe3-a682-5255760a2c38"));

            migrationBuilder.InsertData(
                table: "ProcessEquipmentTypes",
                columns: new[] { "Code", "Area", "Name" },
                values: new object[,]
                {
                    { new Guid("603406f8-8bb6-486c-917c-0550aa0dfd9f"), 120m, "CNC Machine" },
                    { new Guid("73d5a9a4-6961-43a0-b6a4-afb563202efc"), 100m, "Packaging Machine" },
                    { new Guid("9a3b3ab8-9d96-43ad-8ef9-f1f8b291604a"), 80m, "Welding Robot" },
                    { new Guid("e928a938-b03e-4d63-b5cd-831d4169b160"), 150m, "Conveyor Belt" }
                });

            migrationBuilder.InsertData(
                table: "ProductionFacilities",
                columns: new[] { "Code", "Name", "StandardAreaForEquipment" },
                values: new object[,]
                {
                    { new Guid("91396c64-9164-413b-92da-64b219f0596d"), "Factory C - Packaging Area", 1800m },
                    { new Guid("e7b2ff6e-0992-4ef7-adcb-d026a5c5b0c1"), "Factory B - Assembly Line", 2500m },
                    { new Guid("fc503abf-35de-4112-9099-00ebeb75ac13"), "Factory A - Main Building", 1500m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractUpdateRequests_ContractId",
                table: "ContractUpdateRequests",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractUpdateRequests_EquipmentPlacementContracts_ContractId",
                table: "ContractUpdateRequests",
                column: "ContractId",
                principalTable: "EquipmentPlacementContracts",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractUpdateRequests_EquipmentPlacementContracts_ContractId",
                table: "ContractUpdateRequests");

            migrationBuilder.DropIndex(
                name: "IX_ContractUpdateRequests_ContractId",
                table: "ContractUpdateRequests");

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("603406f8-8bb6-486c-917c-0550aa0dfd9f"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("73d5a9a4-6961-43a0-b6a4-afb563202efc"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("9a3b3ab8-9d96-43ad-8ef9-f1f8b291604a"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("e928a938-b03e-4d63-b5cd-831d4169b160"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("91396c64-9164-413b-92da-64b219f0596d"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("e7b2ff6e-0992-4ef7-adcb-d026a5c5b0c1"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("fc503abf-35de-4112-9099-00ebeb75ac13"));

            migrationBuilder.InsertData(
                table: "ProcessEquipmentTypes",
                columns: new[] { "Code", "Area", "Name" },
                values: new object[,]
                {
                    { new Guid("2d84919b-6f8b-45ad-85bb-a9e8ac768f69"), 100m, "Packaging Machine" },
                    { new Guid("364fdf70-d9cd-4125-866e-8e2906828725"), 150m, "Conveyor Belt" },
                    { new Guid("81e4203a-3e2a-4d85-bf17-dd62be88948c"), 120m, "CNC Machine" },
                    { new Guid("bc54fc1b-ff98-4ac0-b487-b0e34ee911d4"), 80m, "Welding Robot" }
                });

            migrationBuilder.InsertData(
                table: "ProductionFacilities",
                columns: new[] { "Code", "Name", "StandardAreaForEquipment" },
                values: new object[,]
                {
                    { new Guid("7f3592f1-5ab8-436f-b85d-1f7f7ff46d69"), "Factory B - Assembly Line", 2500m },
                    { new Guid("9841f87c-52d0-4a32-847d-472df95d4c22"), "Factory C - Packaging Area", 1800m },
                    { new Guid("d429719b-2f25-4fe3-a682-5255760a2c38"), "Factory A - Main Building", 1500m }
                });
        }
    }
}
