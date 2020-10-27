using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SafeCity.Core.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 256, nullable: true),
                    LongDescription = table.Column<string>(maxLength: 8192, nullable: true),
                    AddressName = table.Column<string>(maxLength: 1024, nullable: true),
                    Logo = table.Column<string>(maxLength: 256, nullable: true),
                    State = table.Column<int>(nullable: false),
                    RequiredAmount = table.Column<decimal>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Lon = table.Column<double>(nullable: false),
                    Images = table.Column<string>(nullable: true),
                    Attachments = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Currency = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    TransactionId = table.Column<string>(nullable: true),
                    Action = table.Column<int>(nullable: false),
                    ReceiverCommission = table.Column<decimal>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AddressName", "Attachments", "CreatedBy", "CreatedDate", "Images", "IsDeleted", "Lat", "Logo", "Lon", "LongDescription", "Name", "RequiredAmount", "ShortDescription", "State", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { -1, "Lviv, Kopernyka", "", "chuck.norris@gmail.com", new DateTime(2020, 10, 25, 14, 9, 9, 848, DateTimeKind.Local).AddTicks(6693), "https://lviv.depo.ua/uploads/posts/20190424/754x/nQBX5BSgx0VcY49gVyZyBQz8p7SuwCZlyL2yGusa.jpeg,https://img.depo.ua/745xX/Dec2018/466290.jpg", false, 49.836319000000003, "https://city-adm.lviv.ua/img/843x500/7/-40d71b48.jpg", 24.023026000000002, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy", "Doors renovation", 1200m, "Doors renovation in the old building", 0, null, null },
                    { -2, "Lviv, Zamarstynivska 79", "", "pavlo.kyrylenko@gmail.com", new DateTime(2020, 10, 25, 14, 9, 9, 850, DateTimeKind.Local).AddTicks(7542), "https://i.imgur.com/3QtX0ea.jpg,https://i.imgur.com/xrwczlk.png,https://i.imgur.com/a66KMDd.png", false, 49.857537999999998, "https://i.imgur.com/3QtX0ea.jpg", 24.026658000000001, "Думаю, ви пам'ятаєте прекрасні платани, яки ми завдяки спільнокошту посадили на проспекті Чорновола. Торік крайнє від залізничного мосту дерево хтось надломив (скоріш за все - машиною при маневруванні), ми намагалися зафіксувати його брусками, воно зрослося і так прожило ще рік, але одного з літніх буревіїв таки не витримало. Тепер там порожня лунка і на це місце проситься нове дерево.", "Платан на Чорновола", 5000m, "Заміна платану на чочноаола", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "Action", "Amount", "Currency", "DateTime", "Description", "Email", "Ip", "ProjectId", "ReceiverCommission", "Source", "Status", "TransactionId" },
                values: new object[,]
                {
                    { "637393849118004257-kirilenko.pavlo@gmail.com--2", 1, 200m, 980, new DateTime(2020, 10, 27, 14, 9, 9, 852, DateTimeKind.Local).AddTicks(520), "Project: Платан на Чорновола", "kirilenko.pavlo@gmail.com", "92.253.252.0", -2, 0m, "liqpay", "success", "1460920565" },
                    { "637393849118001254-emma.kyrylenko@gmail.com--2", 1, 140m, 980, new DateTime(2020, 10, 26, 14, 9, 9, 852, DateTimeKind.Local).AddTicks(3172), "Project: Платан на Чорновола", "emma.kyrylenko@gmail.com", "92.253.252.0", -2, 0m, "liqpay", "success", "1460908734" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_ProjectId",
                table: "Donations",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
