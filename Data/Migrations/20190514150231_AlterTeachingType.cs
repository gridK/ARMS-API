using Microsoft.EntityFrameworkCore.Migrations;

namespace AUroomAPI.Data.Migrations
{
    public partial class AlterTeachingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                schema: "master",
                table: "TeachingTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                schema: "master",
                table: "TeachingTypes");
        }
    }
}
