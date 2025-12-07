using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BrainHub.DomainLayer.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permissions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sbus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sbus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SbuId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CustomRoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_CustomRoles_CustomRoleId",
                        column: x => x.CustomRoleId,
                        principalTable: "CustomRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Sbus_SbuId",
                        column: x => x.SbuId,
                        principalTable: "Sbus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "8a078065-9b31-49c2-8660-c86bdf6f9242", "admin@brainhub.com", true, false, null, "ADMIN@BRAINHUB.COM", "ADMIN@BRAINHUB.COM", "AQAAAAIAAYagAAAAEGnCQmiIP+R6QGj0ylUaZf0dODZvPh9ViXXMrXc9mOrklht+8GS2SXY1++6ajcMqhA==", null, false, "410988e0-b88e-474d-867f-3e073045e11a", false, "admin@brainhub.com" },
                    { 101, 0, "4f6ba237-5c7d-4bfd-9ecf-462eb5f7aaf8", "johndoe@brainhub.com", true, false, null, "JOHNDOE@BRAINHUB.COM", "JOHNDOE@BRAINHUB.COM", "AQAAAAIAAYagAAAAEKvW2Dw6F8cKoRfSb8PDgEVCsGDGJABfUtke9nnZakSDqkkWrc72AaRngkDCxxfpbg==", null, false, "a9c4ac73-8ad4-47f0-a88c-15a837333a39", false, "johndoe@brainhub.com" },
                    { 102, 0, "ad1ca2f4-7771-451f-81e8-27d1ed256d26", "janesmith@brainhub.com", true, false, null, "JANESMITH@BRAINHUB.COM", "JANESMITH@BRAINHUB.COM", "AQAAAAIAAYagAAAAEE0YYl+6Av6msNX4XtjWeNd/vFnyOc05SY1VymZ5a17REfjFg5a7A9Gcdi8RdhqxaQ==", null, false, "5ce0cefc-e06b-4ffa-8e52-a2b667952334", false, "janesmith@brainhub.com" },
                    { 103, 0, "20878ced-8824-4edf-88f6-76d19075bcde", "michaeljohnson@brainhub.com", true, false, null, "MICHAELJOHNSON@BRAINHUB.COM", "MICHAELJOHNSON@BRAINHUB.COM", "AQAAAAIAAYagAAAAENuMsXQbVGasgQhbBWu+aMY4dJCbRbj2txTe2Hdv/sK+wDFgPLu99kSw24dk6hQf7Q==", null, false, "bda3965a-5419-4054-a32d-152d65fcd2e0", false, "michaeljohnson@brainhub.com" },
                    { 104, 0, "dbe792d1-ffe4-431e-aea4-56c7fd94ccbe", "emilydavis@brainhub.com", true, false, null, "EMILYDAVIS@BRAINHUB.COM", "EMILYDAVIS@BRAINHUB.COM", "AQAAAAIAAYagAAAAEIP3uk9JHRhfUMxXcgXYhCYTfe//+6FOlYSZ4jrjvnj9f5DNcXyktLule6JzWZeV3Q==", null, false, "31bd2582-4caa-44af-a73d-edd4db5f7949", false, "emilydavis@brainhub.com" },
                    { 105, 0, "96bbc135-8552-4782-b2d6-0b4029fd6c77", "danielbrown@brainhub.com", true, false, null, "DANIELBROWN@BRAINHUB.COM", "DANIELBROWN@BRAINHUB.COM", "AQAAAAIAAYagAAAAEM2mVgcjGgCkRWJh5QWnR/Xp/2SgoLCENlNgl35GaDk8LmpTmr+xl6S6j10P0w8ZMA==", null, false, "52054539-d30a-43be-b50e-b648842816f2", false, "danielbrown@brainhub.com" },
                    { 106, 0, "4ba39099-73bf-4663-b67e-1c1a7b0ae61f", "sophiawilson@brainhub.com", true, false, null, "SOPHIAWILSON@BRAINHUB.COM", "SOPHIAWILSON@BRAINHUB.COM", "AQAAAAIAAYagAAAAEJLvSf+26WfbO60S5CR7OhU4KYVo0WDVyHma1sQNNN29UJgaJRkfgPI+UcspBdZArg==", null, false, "28edf3bf-d46c-4eee-aac1-8b55fed79ed3", false, "sophiawilson@brainhub.com" },
                    { 107, 0, "ba1f1de2-7d29-47b0-8108-4ad0d948635d", "davidmiller@brainhub.com", true, false, null, "DAVIDMILLER@BRAINHUB.COM", "DAVIDMILLER@BRAINHUB.COM", "AQAAAAIAAYagAAAAEJyoGKOqZ956rwoIWknL3Q6E81i9RWwkvFlxjwvQ7hfF6w0lNo5i+YX2koUJTlmk7w==", null, false, "7c804196-265c-44e3-ad84-f706c7ade16b", false, "davidmiller@brainhub.com" },
                    { 108, 0, "af8dd45e-3f81-4829-8e68-6866485f0da6", "oliviaanderson@brainhub.com", true, false, null, "OLIVIAANDERSON@BRAINHUB.COM", "OLIVIAANDERSON@BRAINHUB.COM", "AQAAAAIAAYagAAAAEO6lETU2IZp7PCAEBVKfBEhtCyiiCVMQeS724uvlUNsRmRvm88FhUiY/1HUO1BMLkA==", null, false, "e9109f8a-d2fa-431a-8716-cd14c3e389d2", false, "oliviaanderson@brainhub.com" },
                    { 109, 0, "e2f9889f-1839-4339-8494-975d25168d56", "jamesthomas@brainhub.com", true, false, null, "JAMESTHOMAS@BRAINHUB.COM", "JAMESTHOMAS@BRAINHUB.COM", "AQAAAAIAAYagAAAAEJdHBp6HaBsb/Ve2mLbTSZJV2JnKjUwAOi3FgE1bmdglGf6PVKhMW5T5mdo7UZKv7Q==", null, false, "8a1cc781-8fe2-4a72-8a7f-6c06416f719c", false, "jamesthomas@brainhub.com" },
                    { 110, 0, "a29c572b-19cb-4cc4-b172-7774249c67a5", "isabellamartinez@brainhub.com", true, false, null, "ISABELLAMARTINEZ@BRAINHUB.COM", "ISABELLAMARTINEZ@BRAINHUB.COM", "AQAAAAIAAYagAAAAEAlDQoieu1r/qi+l719mvYrPxbtGzWKYxcjrnWnO9gg5Gt7BEhML0YVsb8hERz2hPw==", null, false, "1e9556a5-7e1b-49ae-be81-4b1779edd209", false, "isabellamartinez@brainhub.com" },
                    { 111, 0, "cf38bfec-24be-4266-a761-6510e527d70c", "a@brainhub.com", true, false, null, "A@BRAINHUB.COM", "A@BRAINHUB.COM", "AQAAAAIAAYagAAAAEEA6pMwQrsSyj71OmT4WuHSOavFP/tEM422BWhMWEGSEpggqMEn0gAh5OMQ989f1JA==", null, false, "3a82cb04-5903-4244-bf3f-923165cde0ae", false, "a@brainhub.com" }
                });

            migrationBuilder.InsertData(
                table: "CustomRoles",
                columns: new[] { "Id", "Name", "Permissions" },
                values: new object[,]
                {
                    { 1, "Employee Manager", "EmployeeIndex,EmployeeAdd,EmployeeUpdate,EmployeeDelete" },
                    { 2, "Sbu Manager", "SbuIndex,SbuAdd,SbuUpdate,SbuDelete" },
                    { 3, "CustomRole Manager", "CustomRoleIndex,CustomRoleAdd,CustomRoleUpdate,CustomRoleDelete" }
                });

            migrationBuilder.InsertData(
                table: "Sbus",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, null, "Admin" },
                    { 2, null, "Finance" },
                    { 3, null, "IT" },
                    { 4, null, "HR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 101 },
                    { 2, 102 },
                    { 2, 103 },
                    { 2, 104 },
                    { 2, 105 },
                    { 2, 106 },
                    { 2, 107 },
                    { 2, 108 },
                    { 2, 109 },
                    { 2, 110 },
                    { 2, 111 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CustomRoleId", "Name", "Number", "SbuId", "UserId" },
                values: new object[,]
                {
                    { 1, null, "Admin", "01111111111", 1, 1 },
                    { 2, null, "John Doe", "01710000001", 2, 101 },
                    { 3, null, "Jane Smith", "01710000002", 3, 102 },
                    { 4, null, "Michael Johnson", "01710000003", 4, 103 },
                    { 5, null, "Emily Davis", "01710000004", 2, 104 },
                    { 6, null, "Daniel Brown", "01710000005", 3, 105 },
                    { 7, null, "Sophia Wilson", "01710000006", 4, 106 },
                    { 8, null, "David Miller", "01710000007", 2, 107 },
                    { 9, null, "Olivia Anderson", "01710000008", 3, 108 },
                    { 10, null, "James Thomas", "01710000009", 4, 109 },
                    { 11, null, "Isabella Martinez", "01710000010", 2, 110 },
                    { 12, null, "a", "01710000011", 2, 111 }
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
                name: "IX_Employees_CustomRoleId",
                table: "Employees",
                column: "CustomRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SbuId",
                table: "Employees",
                column: "SbuId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        /// <inheritdoc />
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
                name: "Employees");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CustomRoles");

            migrationBuilder.DropTable(
                name: "Sbus");
        }
    }
}
