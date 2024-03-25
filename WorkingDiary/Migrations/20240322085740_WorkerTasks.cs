using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkingDiary.Migrations
{
    /// <inheritdoc />
    public partial class WorkerTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "worker_tasks",
                columns: table => new
                {
                    task_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('tasks_task_id_seq'::regclass)"),
                    task_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    task_description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    task_owner_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    task_owner_surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    task_create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    task_end_date = table.Column<DateOnly>(type: "date", nullable: true),
                    task_status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "worker_tasks");
        }
    }
}
