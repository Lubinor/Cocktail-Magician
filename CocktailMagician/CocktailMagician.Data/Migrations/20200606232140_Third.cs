using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Bars",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Bars");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "72802b88-9b15-4b81-9948-2eb26f7bfaf0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "bf807891-bb96-48c8-9602-7c828b35f334");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32f1b34c-2bc2-418c-bae0-f929d4970d59", new DateTime(2020, 6, 6, 22, 32, 14, 109, DateTimeKind.Utc).AddTicks(485), "AQAAAAEAACcQAAAAEJBjesMr0yCptsJlCRzlGHdvVmXsqmDl2kOl7GaKJkHaILwkNyhTYFiNkxAVB6JjrA==", "8cb66a29-9664-4fc7-a595-51513b31ee08" });

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 123, DateTimeKind.Utc).AddTicks(280));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 123, DateTimeKind.Utc).AddTicks(299));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 123, DateTimeKind.Utc).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 123, DateTimeKind.Utc).AddTicks(303));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 123, DateTimeKind.Utc).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(1429));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(6485));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(7008));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(7025));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(3561));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(4067));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(4091));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(4093));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(4094));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(4095));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(4097));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(4099));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(4101));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(4103));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 6, 22, 32, 14, 122, DateTimeKind.Utc).AddTicks(4104));
        }
    }
}
