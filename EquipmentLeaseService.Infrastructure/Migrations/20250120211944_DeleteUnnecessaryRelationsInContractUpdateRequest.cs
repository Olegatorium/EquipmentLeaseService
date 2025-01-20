using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EquipmentLeaseService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteUnnecessaryRelationsInContractUpdateRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("352c67e3-5943-42b3-a112-fad57e9f8c0a"), 100m, "Packaging Machine" },
                    { new Guid("9676ac5e-c7a4-403c-8186-c91422c2cf50"), 80m, "Welding Robot" },
                    { new Guid("b17f62bf-6073-4df6-862a-65a35bbc81a8"), 150m, "Conveyor Belt" },
                    { new Guid("be36a363-a19f-492b-83f1-9b18e97539fb"), 120m, "CNC Machine" }
                });

            migrationBuilder.InsertData(
                table: "ProductionFacilities",
                columns: new[] { "Code", "Name", "StandardAreaForEquipment" },
                values: new object[,]
                {
                    { new Guid("4e0d3341-5af4-4054-91f2-9cf16a719134"), "Factory C - Packaging Area", 1800m },
                    { new Guid("f10dd7d5-df00-4d0b-a528-e6b477273b21"), "Factory A - Main Building", 1500m },
                    { new Guid("f5f80771-ab3a-482d-89af-3ee616215539"), "Factory B - Assembly Line", 2500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("352c67e3-5943-42b3-a112-fad57e9f8c0a"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("9676ac5e-c7a4-403c-8186-c91422c2cf50"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("b17f62bf-6073-4df6-862a-65a35bbc81a8"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Code",
                keyValue: new Guid("be36a363-a19f-492b-83f1-9b18e97539fb"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("4e0d3341-5af4-4054-91f2-9cf16a719134"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("f10dd7d5-df00-4d0b-a528-e6b477273b21"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Code",
                keyValue: new Guid("f5f80771-ab3a-482d-89af-3ee616215539"));

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
    }
}
