using Microsoft.EntityFrameworkCore.Migrations;

namespace NGOManagementSystem.Migrations
{
    public partial class AddNEWModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonorDetail_Payment_PaymentMethod",
                table: "DonorDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_DonorInfo_Category_CategoryId",
                table: "DonorInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_DonorInfo_CategoryId",
                table: "DonorInfo");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "DonorInfo");

            migrationBuilder.AddColumn<int>(
                name: "DonorDetailId",
                table: "Payment",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "AccountNO",
                table: "Payment",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Payment",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IFSC",
                table: "Payment",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DonorInfo",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "DonorDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "DonorDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorDetail_CategoryId",
                table: "DonorDetail",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonorDetail_Category_CategoryId",
                table: "DonorDetail",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonorDetail_Payment_PaymentMethod",
                table: "DonorDetail",
                column: "PaymentMethod",
                principalTable: "Payment",
                principalColumn: "DonorDetailId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonorDetail_Category_CategoryId",
                table: "DonorDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_DonorDetail_Payment_PaymentMethod",
                table: "DonorDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_DonorDetail_CategoryId",
                table: "DonorDetail");

            migrationBuilder.DropColumn(
                name: "DonorDetailId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "AccountNO",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "IFSC",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "DonorInfo");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "DonorDetail");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "DonorInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorInfo_CategoryId",
                table: "DonorInfo",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonorDetail_Payment_PaymentMethod",
                table: "DonorDetail",
                column: "PaymentMethod",
                principalTable: "Payment",
                principalColumn: "OrderDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonorInfo_Category_CategoryId",
                table: "DonorInfo",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
