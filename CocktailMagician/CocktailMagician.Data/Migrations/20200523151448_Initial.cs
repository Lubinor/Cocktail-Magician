using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cocktails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    AverageRating = table.Column<double>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocktails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    AverageRating = table.Column<double>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bars_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CocktailsUsersReviews",
                columns: table => new
                {
                    CocktailId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailsUsersReviews", x => new { x.CocktailId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CocktailsUsersReviews_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktailsUsersReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientsCocktails",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false),
                    CocktailId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsCocktails", x => new { x.IngredientId, x.CocktailId });
                    table.ForeignKey(
                        name: "FK_IngredientsCocktails_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientsCocktails_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarsCocktails",
                columns: table => new
                {
                    BarId = table.Column<int>(nullable: false),
                    CocktailId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarsCocktails", x => new { x.BarId, x.CocktailId });
                    table.ForeignKey(
                        name: "FK_BarsCocktails_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarsCocktails_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarsUsersReviews",
                columns: table => new
                {
                    BarId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarsUsersReviews", x => new { x.BarId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BarsUsersReviews_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarsUsersReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "ddadcf30-7c71-410c-a360-f05b1aaefd7a", "member", "MEMBER" },
                    { 2, "7a93e1e2-8816-4edb-a90e-b261c1619209", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "3e48b09e-1456-45c7-916b-6754611b9d1c", new DateTime(2020, 5, 23, 15, 14, 47, 830, DateTimeKind.Utc).AddTicks(2359), "admin@admin.com", false, false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEBIFLMzz6RHEeVE658tcVwFth6QdKaJNPAQp6tbt7tfci5fIZnX0XkSxaYrOsCcdfg==", null, false, "7ef4551e-7082-4df3-afa1-c77bee26bada", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 23, 15, 14, 47, 843, DateTimeKind.Utc).AddTicks(6982), false, "Sofia" },
                    { 2, new DateTime(2020, 5, 23, 15, 14, 47, 843, DateTimeKind.Utc).AddTicks(7604), false, "Plovdiv" },
                    { 3, new DateTime(2020, 5, 23, 15, 14, 47, 843, DateTimeKind.Utc).AddTicks(7617), false, "Varna" },
                    { 4, new DateTime(2020, 5, 23, 15, 14, 47, 843, DateTimeKind.Utc).AddTicks(7619), false, "Burgas" }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AverageRating", "CreatedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 0.0, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(2624), false, "Mojito" },
                    { 2, 0.0, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(3257), false, "Cuba Libre" },
                    { 3, 0.0, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(3292), false, "Sex on the Beach" },
                    { 4, 0.0, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(3299), false, "Mai Tai" },
                    { 5, 0.0, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(3305), false, "Gin Fizz" },
                    { 6, 0.0, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(3311), false, "Bloody Mary" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 13, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(249), false, "Lime" },
                    { 12, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(247), false, "Tabasco" },
                    { 11, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(246), false, "Tomato juice" },
                    { 10, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(244), false, "Orange juice" },
                    { 9, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(243), false, "Coffee liqueur" },
                    { 5, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(236), false, "Coke" },
                    { 7, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(240), false, "Sugar" },
                    { 6, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(238), false, "Lemon juice" },
                    { 4, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(235), false, "Soda" },
                    { 2, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(212), false, "Gin" },
                    { 1, new DateTime(2020, 5, 23, 15, 14, 47, 843, DateTimeKind.Utc).AddTicks(9712), false, "Vodka" },
                    { 8, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(241), false, "Milk" },
                    { 3, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(233), false, "Rum" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "Bars",
                columns: new[] { "Id", "Address", "AverageRating", "CityId", "CreatedOn", "IsDeleted", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "104 Vitosha blvd.", 0.0, 1, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(6520), false, "Memento", "0889 555 682" },
                    { 2, "22 Tsar Ivan Shishman str.", 0.0, 1, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(7454), false, "Bilkova", "0898 639 068" },
                    { 3, "36 Yoakim Gruev str.", 0.0, 2, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(7472), false, "Petnoto", "0878 509 703" },
                    { 4, "Central Beach", 0.0, 3, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(7475), false, "Cubo", "0898 425 232" },
                    { 5, "1 Tsar Peter str.", 0.0, 4, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(7477), false, "Barcode", "0895 509 659" },
                    { 6, "53 Stefan Stambolov blvd.", 0.0, 4, new DateTime(2020, 5, 23, 15, 14, 47, 844, DateTimeKind.Utc).AddTicks(7479), false, "Fabric Club", "0887 909 019" }
                });

            migrationBuilder.InsertData(
                table: "IngredientsCocktails",
                columns: new[] { "IngredientId", "CocktailId", "IsDeleted" },
                values: new object[,]
                {
                    { 1, 6, false },
                    { 3, 1, false },
                    { 4, 1, false },
                    { 7, 1, false },
                    { 11, 6, false },
                    { 12, 6, false },
                    { 13, 1, false }
                });

            migrationBuilder.InsertData(
                table: "BarsCocktails",
                columns: new[] { "BarId", "CocktailId", "IsDeleted" },
                values: new object[,]
                {
                    { 1, 1, false },
                    { 1, 6, false },
                    { 2, 1, false },
                    { 2, 6, false },
                    { 3, 1, false },
                    { 3, 6, false },
                    { 4, 1, false },
                    { 4, 6, false },
                    { 5, 1, false },
                    { 5, 6, false },
                    { 6, 1, false },
                    { 6, 6, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bars_CityId",
                table: "Bars",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BarsCocktails_CocktailId",
                table: "BarsCocktails",
                column: "CocktailId");

            migrationBuilder.CreateIndex(
                name: "IX_BarsUsersReviews_UserId",
                table: "BarsUsersReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailsUsersReviews_UserId",
                table: "CocktailsUsersReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsCocktails_CocktailId",
                table: "IngredientsCocktails",
                column: "CocktailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BarsCocktails");

            migrationBuilder.DropTable(
                name: "BarsUsersReviews");

            migrationBuilder.DropTable(
                name: "CocktailsUsersReviews");

            migrationBuilder.DropTable(
                name: "IngredientsCocktails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cocktails");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
