using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogDAL.Migrations
{
    public partial class lasteditting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserID",
                table: "Portfolios",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserID",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserID",
                table: "Experiences",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserID",
                table: "Educations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserID",
                table: "Abouts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppUserSkill",
                columns: table => new
                {
                    AppUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserSkill", x => new { x.AppUsersId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_AppUserSkill_AspNetUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_AppUserID",
                table: "Portfolios",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AppUserID",
                table: "Messages",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_AppUserID",
                table: "Experiences",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_AppUserID",
                table: "Educations",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AppUserId",
                table: "Articles",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_AppUserID",
                table: "Abouts",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSkill_SkillsId",
                table: "AppUserSkill",
                column: "SkillsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_AspNetUsers_AppUserID",
                table: "Abouts",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId",
                table: "Articles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_AspNetUsers_AppUserID",
                table: "Educations",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_AspNetUsers_AppUserID",
                table: "Experiences",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_AppUserID",
                table: "Messages",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_AspNetUsers_AppUserID",
                table: "Portfolios",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_AspNetUsers_AppUserID",
                table: "Abouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_AspNetUsers_AppUserID",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_AspNetUsers_AppUserID",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_AppUserID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_AspNetUsers_AppUserID",
                table: "Portfolios");

            migrationBuilder.DropTable(
                name: "AppUserSkill");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_AppUserID",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Messages_AppUserID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_AppUserID",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Educations_AppUserID",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AppUserId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Abouts_AppUserID",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Abouts");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
