using Microsoft.EntityFrameworkCore.Migrations;

namespace NGOManagementSystem.Migrations
{
    public partial class addPaymentDonorDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethods = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.OrderDetailId);
                });

            migrationBuilder.CreateTable(
                name: "DonorDetail",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorId = table.Column<int>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorDetail", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_DonorDetail_DonorInfo_DonorId",
                        column: x => x.DonorId,
                        principalTable: "DonorInfo",
                        principalColumn: "DonorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonorDetail_Payment_PaymentMethod",
                        column: x => x.PaymentMethod,
                        principalTable: "Payment",
                        principalColumn: "OrderDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonorDetail_DonorId",
                table: "DonorDetail",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorDetail_PaymentMethod",
                table: "DonorDetail",
                column: "PaymentMethod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonorDetail");

            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
