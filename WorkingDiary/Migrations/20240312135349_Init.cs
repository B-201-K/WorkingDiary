using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WorkingDiary.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "worker",
                columns: table => new
                {
                    worker_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    worker_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    worker_surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    worker_lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    worker_department = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    worker_login = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    worker_password = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_key", x => x.worker_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "worker");
        }
    }
}
