using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Web.Data.Migrations
{
    public partial class AddCreatedByIdColumn2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CtreatedById",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CtreatedById",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "AspNetUsers");
        }
    }
}
