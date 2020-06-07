using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageSource",
                table: "Bars",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4ba90007-95dc-4a4e-8f73-2985c87627f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2c295481-d739-4d74-90eb-a7e48d03c1c5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52fe845e-6aff-4ac4-99f3-d6bfc2274889", new DateTime(2020, 6, 7, 0, 48, 56, 382, DateTimeKind.Utc).AddTicks(3605), "AQAAAAEAACcQAAAAED7mR6q15Ac4swnuPXxbPXARUqgwev9RjToBunb86x4yWnP8vf4x58JnliA8ke0SEQ==", "344806a4-9c4e-424e-9117-72d79e6f0568" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "Bars");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "2fbbc890-aa24-4b0b-b29f-309e39cc7b23");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e639c948-52e7-4060-a00a-1daa4a96f3b3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f59742c-8731-4da5-9331-26ddca62d0da", new DateTime(2020, 6, 6, 23, 21, 39, 549, DateTimeKind.Utc).AddTicks(9224), "AQAAAAEAACcQAAAAEOL6i6s/2Kc3YrQ9fASyhJT9cOSYYfTm9ECH/X1zTDJGqvyf8pEneRzgq6dCgeVLYA==", "336e9b4c-a06c-4222-96a7-02e2615d6ab9" });

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 561, DateTimeKind.Utc).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 561, DateTimeKind.Utc).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 561, DateTimeKind.Utc).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 561, DateTimeKind.Utc).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(3026));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(3030));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 561, DateTimeKind.Utc).AddTicks(9672));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(173));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(190));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(191));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(194));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(196));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(202));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(203));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 23, 21, 39, 562, DateTimeKind.Utc).AddTicks(205));
        }
    }
}
