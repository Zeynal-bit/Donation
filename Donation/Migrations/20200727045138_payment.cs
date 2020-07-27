using Microsoft.EntityFrameworkCore.Migrations;

namespace Donation.Migrations
{
    public partial class payment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ReturnUrl = table.Column<string>(nullable: true),
                    FailUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ErrorCode = table.Column<int>(nullable: false),
                    ErrorMessage = table.Column<string>(nullable: true),
                    OrderStatus = table.Column<int>(nullable: false),
                    orderId = table.Column<string>(nullable: true),
                    formUrl = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentLists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentLists");
        }
    }
}
