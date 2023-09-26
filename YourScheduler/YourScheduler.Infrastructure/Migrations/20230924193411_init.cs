using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourScheduler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Displayname = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    AdministratorId = table.Column<int>(type: "int", nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "ApplicationUsersEvents",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsersEvents", x => new { x.ApplicationUserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_ApplicationUsersEvents_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUsersEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamRoles",
                columns: table => new
                {
                    TeamRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRoles", x => x.TeamRoleId);
                    table.ForeignKey(
                        name: "FK_TeamRoles_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsersTeams",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    TeamRoleId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsersTeams", x => new { x.ApplicationUserId, x.TeamId, x.TeamRoleId });
                    table.ForeignKey(
                        name: "FK_ApplicationUsersTeams_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUsersTeams_TeamRoles_TeamRoleId",
                        column: x => x.TeamRoleId,
                        principalTable: "TeamRoles",
                        principalColumn: "TeamRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUsersTeams_Teams_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamRolesFlags",
                columns: table => new
                {
                    TeamRoleId = table.Column<int>(type: "int", nullable: false),
                    CanRemoveTeamMember = table.Column<bool>(type: "bit", nullable: false),
                    CanAddTeamMember = table.Column<bool>(type: "bit", nullable: false),
                    CanAddTeamRole = table.Column<bool>(type: "bit", nullable: false),
                    CanEditTeamRole = table.Column<bool>(type: "bit", nullable: false),
                    CanRemoveTeamRole = table.Column<bool>(type: "bit", nullable: false),
                    CanEditRoleFlags = table.Column<bool>(type: "bit", nullable: false),
                    CanEditTeamPhoto = table.Column<bool>(type: "bit", nullable: false),
                    CanEditDescription = table.Column<bool>(type: "bit", nullable: false),
                    CanEditTeamMessage = table.Column<bool>(type: "bit", nullable: false),
                    CanEditTeamName = table.Column<bool>(type: "bit", nullable: false),
                    CanAddTeamEvent = table.Column<bool>(type: "bit", nullable: false),
                    CanEditTeamEvent = table.Column<bool>(type: "bit", nullable: false),
                    CanRemoveTeamEvent = table.Column<bool>(type: "bit", nullable: false),
                    CanSendEmailToTeam = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRolesFlags", x => x.TeamRoleId);
                    table.ForeignKey(
                        name: "FK_TeamRolesFlags_TeamRoles_TeamRoleId",
                        column: x => x.TeamRoleId,
                        principalTable: "TeamRoles",
                        principalColumn: "TeamRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Displayname", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "", "admin", "admin@gmail.com", false, true, null, "admin", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "ADTwEDtSBjo6ekG8ldjrg7k77RB/fTza4X61cYmyAdMP9ROgF9kSC9FBgCNtI7NvcA==", "111 222 333", false, "DML7LKPSWR3XKEVYP2XQRLQ3WYEBTDTQ", "admin", false, "admin@gmail.com" },
                    { 2, 0, "", "kjarzyna", "jarzyna@gmail.com", false, true, null, "Krzysztof", "JARZYNA@GMAIL.COM", "JARZYNA@GMAIL.COM", "AC1DcQSl8KHPm6HkSo4CZ0p1SFoG7Ntmupwhiy30scFZxo4dLQLkK/Yt8mN3AsyIkQ==", "666 598 456", false, "7QJ22FHS3JZZO74ZAIBLOL2L45MWKZ2V", "Jarzyna", false, "jarzyna@gmail.com" },
                    { 3, 0, "", "Jane", "jane_johnson@gmail.com", false, true, null, "Jane", "JANE_JOHNSON@GMAIL.COM", "JANE_JOHNSON@GMAIL.COM", "AE20jKuyQSuiJdH/ieiyvayo07zu3xrFMHlHg3p6c/+lxxCpcL3bpR+LzdSkPkfo2w==", "666 598 456", false, "KUZ2K5M5B7DNAKWED27DS3HTLW36ER56", "Johnson", false, "jane_johnson@gmail.com" },
                    { 4, 0, "", "willmich", "michaelww@gmail.com", false, true, null, "Michael", "MICHAELWW@GMAIL.COM", "MICHAELWW@GMAIL.COM", "APKYPrxP6vWU6yFjPMSuxU53UGclbDxUIsOKZi5J5x/GqbsePyI4ACiPYhJ9NysT1Q==", "987 654 321", false, "IZFCRVPDF2IN5SGEO4K6ARMIUQRAAZE3", "Williams", false, "michaelww@gmail.com" },
                    { 5, 0, "", "william", "joneswilliam@gmail.com", false, true, null, "William", "JONESWILLIAM@GMAIL.COM", "JONESWILLIAM@GMAIL.COM", "AIkcRh32EqLa0O6rVc/i55Z0svYYgbfVitl+NhojlXpWIXpJg3yKHq+zl2oT+HAxqg==", "123 456 789", false, "BVN4YEHE76YVPX5GWFF72OHANOLOPMEE", "Jones", false, "joneswilliam@gmail.com" },
                    { 6, 0, "", "brownie", "oliviab@gmail.com", false, true, null, "Olivia", "OLIVIAB@GMAIL.COM", "OLIVIAB@GMAIL.COM", "ACpOFq5PcMukfmbK/4OijYFglXMfWXiSWTbrainmSjPG2Lh88WBnmiutecDew5PS+A==", "666 598 456", false, "OGPOB4B4TJEIYY3AOEPQGB6RXBSA4RRA", "Brown", false, "oliviab@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "AdministratorId", "Date", "Description", "IsOpen", "Name", "PicturePath" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 6, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), "Koncert z okazji urodzin TVP", true, "Koncert Zenka Martyniuka", "/Pictures/eventId=1.jpg" },
                    { 2, 1, new DateTime(2023, 12, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "Wyjątkowe spotkanie z autorami bestsellerowych książek", true, "Spotkanie Literackie: Autorzy Bestsellerów", "/Pictures/eventId=2.jpg" },
                    { 3, 2, new DateTime(2023, 10, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), "Spektakl muzyczny pełen magii i emocji", true, "Występ Teatru Muzycznego: Magiczna Melodia", "/Pictures/eventId=3.jpg" },
                    { 4, 3, new DateTime(2023, 9, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), "Najnowsze trendy i innowacje technologiczne na światowym poziomie", true, "Konferencja Technologiczna: Przyszłość Innowacji", "/Pictures/defaultEvent.jpg" },
                    { 5, 4, new DateTime(2024, 1, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), "Przyjemny wieczór filmowy z wyjątkowymi produkcjami z całego świata", false, "Sesja Filmowa: Kino bez Granic", "/Pictures/defaultEvent.jpg" },
                    { 6, 5, new DateTime(2023, 7, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), "Wyjątkowy pokaz kulinarny, podczas którego można odkryć smaki z różnych zakątków świata", false, "Pokaz Kulinarny: Świat Smaków", "/Pictures/eventId=6.jpg" },
                    { 7, 6, new DateTime(2023, 8, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), "Niezwykłe przedstawienie teatralne pełne emocji i wrażeń", true, "Sztuka na Scenie: Wieczór Teatru", "/Pictures/defaultEvent.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Creator", "Description", "Message", "Name", "PicturePath" },
                values: new object[,]
                {
                    { 1, "Olivia", "Grupa szkółki pływackiej Argonaut", null, "Grupa początkująca basen Chełm", "/Pictures/teamId=1.jpg" },
                    { 2, "Wasyl", "Grupa zrzeszająca mieszkańców osiedla Lawendowe Wzgórze w Gdańsku", null, "Mieszkańcy osiedla Lawendowe Wzgórze", "/Pictures/teamId=2.jpg" },
                    { 3, "Billy", "Zapraszamy do naszego kreatywnego warsztatu artystycznego, gdzie możesz rozwijać swoje umiejętności w różnych dziedzinach sztuki.", null, "Kreatywny Warsztat Artystyczny", "/Pictures/defaultTeam.jpg" },
                    { 4, "Maks", "Dołącz do naszego klubu fitness i wellness, gdzie możesz ćwiczyć, relaksować się i dbać o swoje zdrowie pod okiem profesjonalnych instruktorów.", null, "Klub Fitness i Wellness", "/Pictures/teamId=4.jpg" },
                    { 5, "Kokodźambo", "Zapraszamy do naszego klubu fotograficznego, gdzie pasjonaci fotografii mogą się spotkać, dzielić się wiedzą i rozwijać swoje umiejętności fotograficzne.", null, "Klub Fotograficzny Obiektyw", "/Pictures/defaultTeam.jpg" },
                    { 6, "PiknaSukna", "Nasze studio tańca Ritmo oferuje różnorodne style taneczne dla osób w każdym wieku, bez względu na poziom zaawansowania.", null, "Studio Tańca Ritmo", "/Pictures/defaultTeam.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsersEvents",
                columns: new[] { "ApplicationUserId", "EventId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 5 },
                    { 5, 5 },
                    { 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "TeamRoles",
                columns: new[] { "TeamRoleId", "Name", "TeamId" },
                values: new object[,]
                {
                    { 1, "Chobok", 1 },
                    { 2, "Master Blaster", 2 },
                    { 3, "Perturbator", 3 },
                    { 4, "Ciastek", 4 },
                    { 5, "Kaczucha", 5 },
                    { 6, "Karal", 6 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsersTeams",
                columns: new[] { "ApplicationUserId", "TeamId", "TeamRoleId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 2, 3, 3 },
                    { 2, 4, 4 },
                    { 3, 4, 4 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 5, 6, 6 },
                    { 6, 5, 5 },
                    { 6, 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "TeamRolesFlags",
                columns: new[] { "TeamRoleId", "CanAddTeamEvent", "CanAddTeamMember", "CanAddTeamRole", "CanEditDescription", "CanEditRoleFlags", "CanEditTeamEvent", "CanEditTeamMessage", "CanEditTeamName", "CanEditTeamPhoto", "CanEditTeamRole", "CanRemoveTeamEvent", "CanRemoveTeamMember", "CanRemoveTeamRole", "CanSendEmailToTeam" },
                values: new object[,]
                {
                    { 1, true, true, true, true, true, true, true, true, true, true, true, true, true, true },
                    { 2, true, true, true, true, true, true, true, true, true, true, true, true, true, true },
                    { 3, true, true, true, true, true, true, true, true, true, true, true, true, true, true },
                    { 4, true, true, true, true, true, true, true, true, true, true, true, true, true, true },
                    { 5, true, true, true, true, true, true, true, true, true, true, true, true, true, true },
                    { 6, true, true, true, true, true, true, true, true, true, true, true, true, true, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersEvents_EventId",
                table: "ApplicationUsersEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersTeams_TeamRoleId",
                table: "ApplicationUsersTeams",
                column: "TeamRoleId");

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
                name: "IX_TeamRoles_TeamId",
                table: "TeamRoles",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsersEvents");

            migrationBuilder.DropTable(
                name: "ApplicationUsersTeams");

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
                name: "TeamRolesFlags");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TeamRoles");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
