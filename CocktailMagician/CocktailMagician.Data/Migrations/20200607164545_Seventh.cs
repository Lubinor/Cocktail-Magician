using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class Seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f0d143d3-bab2-4d60-83ad-72544d586b37");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9de2bedb-a25d-45a5-888c-fb2154e02276");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ccf7443e-80bc-4029-9842-4216b09631dd", new DateTime(2020, 6, 7, 16, 45, 45, 269, DateTimeKind.Utc).AddTicks(6761), true, "AQAAAAEAACcQAAAAEPgi3TqVVfbLHsQm73bdJYpAA/BFG5sTrtjiRsQeg5P9dk0Jc2297suho9oN6W/Asw==", "2205c918-613a-4578-aeed-888a8331ca2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7914ef6-f453-4293-a9cf-7c253b712f6c", new DateTime(2020, 6, 7, 16, 45, 45, 281, DateTimeKind.Utc).AddTicks(6054), true, "AQAAAAEAACcQAAAAEFY3gQS0Usm/6rEBp6l8TFOZv8eGBPRCXLd/JcgcZvIQ8aUPV6JfqorMwhywGu+VeQ==", "9fbc75f9-ac9d-4f76-860d-9114927297f6" });

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(8896));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(9788));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(9792));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(9794));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(1007));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(6454));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(6469));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(6471));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(3696));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(3698));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(3700));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(3703));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(3706));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(3709));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 16, 45, 45, 288, DateTimeKind.Utc).AddTicks(3711));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c9d0bae3-b793-4beb-9a2f-6c5f5fceb339");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "002765dd-8dc2-4d59-8b62-c8d4df2fd903");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99d2d86e-62a6-4c49-a649-707d9c96751f", new DateTime(2020, 6, 7, 14, 1, 53, 446, DateTimeKind.Utc).AddTicks(1439), false, "AQAAAAEAACcQAAAAEAnqRSBj9pJK4+fG8wZrn3H5ALnwRzumb+tb0D1Uf3uEakqYHz0Zs3wUpfQ1CaG9Jg==", "2abf3e55-f155-4bef-8f8d-5dec70661fdb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2fb3006-9324-4994-8d96-70be3901a934", new DateTime(2020, 6, 7, 14, 1, 53, 458, DateTimeKind.Utc).AddTicks(1793), false, null, "b41d590a-2887-462a-af72-fe04af048373" });

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 465, DateTimeKind.Utc).AddTicks(5215));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 465, DateTimeKind.Utc).AddTicks(6081));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 465, DateTimeKind.Utc).AddTicks(6109));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 465, DateTimeKind.Utc).AddTicks(6111));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 465, DateTimeKind.Utc).AddTicks(6113));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 465, DateTimeKind.Utc).AddTicks(6115));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(7293));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(7296));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 465, DateTimeKind.Utc).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 465, DateTimeKind.Utc).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 465, DateTimeKind.Utc).AddTicks(2759));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 465, DateTimeKind.Utc).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 465, DateTimeKind.Utc).AddTicks(2807));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 465, DateTimeKind.Utc).AddTicks(2809));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(9924));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(9938));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(9939));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(9942));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(9944));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(9947));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(9951));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 7, 14, 1, 53, 464, DateTimeKind.Utc).AddTicks(9954));
        }
    }
}
