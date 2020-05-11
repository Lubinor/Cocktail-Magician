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
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsBanned = table.Column<bool>(nullable: false)
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
                    CreatedOn = table.Column<DateTime>(nullable: false),
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
                    CreatedOn = table.Column<DateTime>(nullable: false),
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
                    CreatedOn = table.Column<DateTime>(nullable: false),
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
                    CreatedOn = table.Column<DateTime>(nullable: false),
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
                    CocktailId = table.Column<int>(nullable: false)
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
                    CocktailId = table.Column<int>(nullable: false)
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
                    CreatedOn = table.Column<DateTime>(nullable: false),
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
                    { 1, "f8176da6-41c2-41b5-916b-ff3cb2ad65a6", "member", "MEMBER" },
                    { 2, "dab55eb0-d3c5-4538-89a1-ebb2dd54654a", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "IsBanned", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "cfa5ad19-aad2-4986-88a5-0084cbd6f879", new DateTime(2020, 5, 11, 21, 42, 8, 816, DateTimeKind.Utc).AddTicks(2959), "admin@admin.com", false, false, false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEK15LbB4vvVj198X2kR0MVCkh9Ua/x/kWijkhczmcaUiHwFKxQtoVIXw7fKP2k44/A==", null, false, "10fcb72a-76ee-4b2e-96c9-e74050e33285", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(2783), false, "Sofia" },
                    { 2, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(3253), false, "Plovdiv" },
                    { 3, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(3261), false, "Varna" },
                    { 4, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(3263), false, "Burgas" }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AverageRating", "CreatedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 0.0, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(8382), false, "Mojito" },
                    { 2, 0.0, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(8833), false, "Cuba Libre" },
                    { 3, 0.0, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(8858), false, "Sex on the Beach" },
                    { 4, 0.0, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(8860), false, "Mai Tai" },
                    { 5, 0.0, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(8863), false, "Gin Fizz" },
                    { 6, 0.0, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(8866), false, "Bloody Mary" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 13, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(6017), false, "Lime" },
                    { 12, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(6015), false, "Tabasco" },
                    { 11, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(6013), false, "Tomato Juice" },
                    { 10, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(6011), false, "Orange Juice" },
                    { 9, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(6009), false, "Coffee Liqueur" },
                    { 5, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(6000), false, "Coke" },
                    { 7, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(6005), false, "Sugar" },
                    { 6, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(6002), false, "Lemon juice" },
                    { 4, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(5998), false, "Soda" },
                    { 2, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(5980), false, "Gin" },
                    { 1, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(5534), false, "Vodka" },
                    { 8, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(6007), false, "Milk" },
                    { 3, new DateTime(2020, 5, 11, 21, 42, 8, 829, DateTimeKind.Utc).AddTicks(5996), false, "Rum" }
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
                    { 1, "104 Vitosha blvd.", 0.0, 1, new DateTime(2020, 5, 11, 21, 42, 8, 830, DateTimeKind.Utc).AddTicks(1343), false, "Memento", "0889 555 682" },
                    { 2, "22 Tsar Ivan Shishman str.", 0.0, 1, new DateTime(2020, 5, 11, 21, 42, 8, 830, DateTimeKind.Utc).AddTicks(2139), false, "Bilkova", "0898 639 068" },
                    { 3, "36 Yoakim Gruev str.", 0.0, 2, new DateTime(2020, 5, 11, 21, 42, 8, 830, DateTimeKind.Utc).AddTicks(2155), false, "Petnoto", "0878 509 703" },
                    { 4, "Central Beach", 0.0, 3, new DateTime(2020, 5, 11, 21, 42, 8, 830, DateTimeKind.Utc).AddTicks(2158), false, "Cubo", "0898 425 232" },
                    { 5, "1 Tsar Peter str.", 0.0, 4, new DateTime(2020, 5, 11, 21, 42, 8, 830, DateTimeKind.Utc).AddTicks(2198), false, "Barcode", " 0895 509 659" },
                    { 6, "53 Stefan Stambolov blvd.", 0.0, 4, new DateTime(2020, 5, 11, 21, 42, 8, 830, DateTimeKind.Utc).AddTicks(2201), false, "Fabric Club", "0887 909 019" }
                });

            migrationBuilder.InsertData(
                table: "IngredientsCocktails",
                columns: new[] { "IngredientId", "CocktailId" },
                values: new object[,]
                {
                    { 1, 6 },
                    { 3, 1 },
                    { 4, 1 },
                    { 7, 1 },
                    { 11, 6 },
                    { 12, 6 },
                    { 13, 1 }
                });

            migrationBuilder.InsertData(
                table: "BarsCocktails",
                columns: new[] { "BarId", "CocktailId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 6 },
                    { 2, 1 },
                    { 2, 6 },
                    { 3, 1 },
                    { 3, 6 },
                    { 4, 1 },
                    { 4, 6 },
                    { 5, 1 },
                    { 5, 6 },
                    { 6, 1 },
                    { 6, 6 }
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
