using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Web.Data.Migrations
{
    public partial class AddCreatedByIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CtreatedById",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CtreatedById",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CtreatedById",
                table: "Authors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Authors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CtreatedById",
                table: "Categories",
                column: "CtreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UpdatedById",
                table: "Categories",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CtreatedById",
                table: "Books",
                column: "CtreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UpdatedById",
                table: "Books",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_CtreatedById",
                table: "Authors",
                column: "CtreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_UpdatedById",
                table: "Authors",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_AspNetUsers_CtreatedById",
                table: "Authors",
                column: "CtreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_AspNetUsers_UpdatedById",
                table: "Authors",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_CtreatedById",
                table: "Books",
                column: "CtreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_UpdatedById",
                table: "Books",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_CtreatedById",
                table: "Categories",
                column: "CtreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_UpdatedById",
                table: "Categories",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_AspNetUsers_CtreatedById",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Authors_AspNetUsers_UpdatedById",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_CtreatedById",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_UpdatedById",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_CtreatedById",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_UpdatedById",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CtreatedById",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UpdatedById",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Books_CtreatedById",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_UpdatedById",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Authors_CtreatedById",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_UpdatedById",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "CtreatedById",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CtreatedById",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CtreatedById",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Authors");
        }
    }
}
