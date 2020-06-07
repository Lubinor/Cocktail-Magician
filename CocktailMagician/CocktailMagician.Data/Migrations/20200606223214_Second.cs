using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "CocktailsUsersReviews",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "BarsUsersReviews",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bars",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "CocktailsUsersReviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "BarsUsersReviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0a35edaf-7731-4bdb-9b4a-82879f556cf9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "be8de06f-ab32-4f30-abd2-06fdfe34fdb5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a1dd05f-4f61-4c37-a09f-00a7643ac1f2", new DateTime(2020, 5, 23, 15, 37, 54, 795, DateTimeKind.Utc).AddTicks(1970), "AQAAAAEAACcQAAAAEK3NNBLgg2zBKG9jpPFPyivmyMBsCZDuKKULRXiL3mya+9FzHf57aBF9Hi8Dz5cFww==", "6f79214d-eb7a-41fe-b213-b1f253139c09" });

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 816, DateTimeKind.Utc).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 816, DateTimeKind.Utc).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 816, DateTimeKind.Utc).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 816, DateTimeKind.Utc).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 816, DateTimeKind.Utc).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 816, DateTimeKind.Utc).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(2054));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 816, DateTimeKind.Utc).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 816, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 816, DateTimeKind.Utc).AddTicks(2216));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 816, DateTimeKind.Utc).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 816, DateTimeKind.Utc).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 816, DateTimeKind.Utc).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(7235));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(7235));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(7235));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 23, 15, 37, 54, 815, DateTimeKind.Utc).AddTicks(7235));
        }
    }
}
