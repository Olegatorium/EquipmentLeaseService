using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EquipmentLeaseService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigationPropetiesToContractUpdateRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_ContractUpdateRequests_ProcessEquipmentTypeCode",
                table: "ContractUpdateRequests",
                column: "ProcessEquipmentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_ContractUpdateRequests_ProductionFacilityCode",
                table: "ContractUpdateRequests",
                column: "ProductionFacilityCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractUpdateRequests_ProcessEquipmentTypes_ProcessEquipmentTypeCode",
                table: "ContractUpdateRequests",
                column: "ProcessEquipmentTypeCode",
                principalTable: "ProcessEquipmentTypes",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractUpdateRequests_ProductionFacilities_ProductionFacilityCode",
                table: "ContractUpdateRequests",
                column: "ProductionFacilityCode",
                principalTable: "ProductionFacilities",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractUpdateRequests_ProcessEquipmentTypes_ProcessEquipmentTypeCode",
                table: "ContractUpdateRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractUpdateRequests_ProductionFacilities_ProductionFacilityCode",
                table: "ContractUpdateRequests");

            migrationBuilder.DropIndex(
                name: "IX_ContractUpdateRequests_ProcessEquipmentTypeCode",
                table: "ContractUpdateRequests");

            migrationBuilder.DropIndex(
                name: "IX_ContractUpdateRequests_ProductionFacilityCode",
                table: "ContractUpdateRequests");

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
    }
}
