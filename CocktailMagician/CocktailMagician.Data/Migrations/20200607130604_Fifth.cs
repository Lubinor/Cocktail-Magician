using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fdb857dd-6f41-4206-a7b3-65cf8024a885", "Bar Crawler", "BAR CRAWLER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce2d0d25-f6f1-42ef-b681-4f238f20fd9f", "Cocktail Magician", "COCKTAIL MAGICIAN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abc6719b-ccf1-4fbb-a8a8-bda3d5c68457", new DateTime(2020, 6, 7, 13, 6, 3, 844, DateTimeKind.Utc).AddTicks(3347), "AQAAAAEAACcQAAAAEDqHf9rK3BzNYLvTdjPAi4zjM6llDj+uG1BljhGsNqGMsceN3FXawT/DTfjymskx6g==", "47b6fc63-4724-4bf3-bac2-cc11ebedac6a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "SecurityStamp" },
                values: new object[] { "0636b35d-277c-4d40-88bc-7190b6d7f3c8", new DateTime(2020, 6, 7, 13, 6, 3, 856, DateTimeKind.Utc).AddTicks(4369), "1446263a-7bbb-48e0-a8ea-30c0d5172168" });

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(8003));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 862, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 862, DateTimeKind.Utc).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 862, DateTimeKind.Utc).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 862, DateTimeKind.Utc).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(4713));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(4730));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(4732));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(1377));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(1904));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(1918));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(1922));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 13, 6, 3, 863, DateTimeKind.Utc).AddTicks(1933));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ba90007-95dc-4a4e-8f73-2985c87627f0", "member", "MEMBER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c295481-d739-4d74-90eb-a7e48d03c1c5", "admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52fe845e-6aff-4ac4-99f3-d6bfc2274889", new DateTime(2020, 6, 7, 0, 48, 56, 382, DateTimeKind.Utc).AddTicks(3605), "AQAAAAEAACcQAAAAED7mR6q15Ac4swnuPXxbPXARUqgwev9RjToBunb86x4yWnP8vf4x58JnliA8ke0SEQ==", "344806a4-9c4e-424e-9117-72d79e6f0568" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "SecurityStamp" },
                values: new object[] { "a8b9988b-4448-4815-ab5a-b41dfbe74734", new DateTime(2020, 6, 6, 10, 42, 2, 240, DateTimeKind.Utc).AddTicks(5062), "4d52020f-ab35-480d-b991-f1f0bef0c7c5" });

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 395, DateTimeKind.Utc).AddTicks(755));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 395, DateTimeKind.Utc).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 395, DateTimeKind.Utc).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 395, DateTimeKind.Utc).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 395, DateTimeKind.Utc).AddTicks(1632));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 395, DateTimeKind.Utc).AddTicks(1634));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(7617));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(8137));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(8161));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(5342));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(5358));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(5360));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(5361));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(5363));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(5365));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(5372));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 0, 48, 56, 394, DateTimeKind.Utc).AddTicks(5373));
        }
    }
}
