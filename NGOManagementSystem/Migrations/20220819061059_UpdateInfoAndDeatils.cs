using Microsoft.EntityFrameworkCore.Migrations;

namespace NGOManagementSystem.Migrations
{
    public partial class UpdateInfoAndDeatils : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "DonorInfo");

            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "DonorDetail",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "DonorDetail");

            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "DonorInfo",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
