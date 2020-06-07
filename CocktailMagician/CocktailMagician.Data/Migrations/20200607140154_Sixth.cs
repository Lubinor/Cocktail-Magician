using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageSource",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Cocktails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageSource",
                table: "Cocktails",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99d2d86e-62a6-4c49-a649-707d9c96751f", new DateTime(2020, 6, 7, 14, 1, 53, 446, DateTimeKind.Utc).AddTicks(1439), "AQAAAAEAACcQAAAAEAnqRSBj9pJK4+fG8wZrn3H5ALnwRzumb+tb0D1Uf3uEakqYHz0Zs3wUpfQ1CaG9Jg==", "2abf3e55-f155-4bef-8f8d-5dec70661fdb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "SecurityStamp" },
                values: new object[] { "a2fb3006-9324-4994-8d96-70be3901a934", new DateTime(2020, 6, 7, 14, 1, 53, 458, DateTimeKind.Utc).AddTicks(1793), "b41d590a-2887-462a-af72-fe04af048373" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Cocktails");

            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "Cocktails");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "fdb857dd-6f41-4206-a7b3-65cf8024a885");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ce2d0d25-f6f1-42ef-b681-4f238f20fd9f");

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
    }
}
