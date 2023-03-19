using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication10.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id_Contacts = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    number_phone = table.Column<string>(name: "number_phone ", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    home_phone = table.Column<string>(name: "home _phone", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    mobile_phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sem = table.Column<bool>(type: "bit", nullable: false),
                    id_treat = table.Column<int>(type: "int", nullable: true),
                    remark = table.Column<string>(type: "text", nullable: false),
                    how_comeUs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Contacts__86C6BBA370C5FA70", x => x.Id_Contacts);
                });

            migrationBuilder.CreateTable(
                name: "tbl_account",
                columns: table => new
                {
                    Id_account = table.Column<int>(type: "int", nullable: false),
                    Id_treat = table.Column<int>(type: "int", nullable: false),
                    Id_Contacts = table.Column<int>(type: "int", nullable: false),
                    Pay = table.Column<int>(type: "int", nullable: true),
                    Crdite = table.Column<int>(type: "int", nullable: true),
                    Owes = table.Column<int>(type: "int", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_acco__741F0A2BBECAC350", x => x.Id_account);
                });

            migrationBuilder.CreateTable(
                name: "tbl_appointments",
                columns: table => new
                {
                    Id_appointment = table.Column<int>(type: "int", nullable: false),
                    Id_Contacts = table.Column<int>(type: "int", nullable: true),
                    Id_treat = table.Column<int>(type: "int", nullable: true),
                    Id_employee = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Time = table.Column<TimeSpan>(type: "time", nullable: true),
                    Durction = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    Remined = table.Column<bool>(type: "bit", nullable: true),
                    Discount = table.Column<bool>(type: "bit", nullable: true),
                    Wait = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_appo__D0F3704DB63FEDD6", x => x.Id_appointment);
                });

            migrationBuilder.CreateTable(
                name: "tbl_employees",
                columns: table => new
                {
                    Id_employee = table.Column<int>(type: "int", nullable: false),
                    name_employee = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    permission = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id_treat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_empl__285BF3F77F8FC4CA", x => x.Id_employee);
                });

            migrationBuilder.CreateTable(
                name: "tbl_inquiries",
                columns: table => new
                {
                    Id_inquirie = table.Column<int>(type: "int", nullable: false),
                    Id_appointment = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    Done = table.Column<bool>(type: "bit", nullable: true),
                    From = table.Column<int>(type: "int", nullable: true),
                    To = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_inqu__57640B01E7A2A766", x => x.Id_inquirie);
                });

            migrationBuilder.CreateTable(
                name: "tbl_laser",
                columns: table => new
                {
                    Id_laser = table.Column<int>(type: "int", nullable: false),
                    Id_Contacts = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ms = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Spot_size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Energy = table.Column<int>(type: "int", nullable: true),
                    Reaction = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_lase__87E2B0625B449B8E", x => x.Id_laser);
                });

            migrationBuilder.CreateTable(
                name: "tbl_room",
                columns: table => new
                {
                    Id_room = table.Column<int>(type: "int", nullable: false),
                    Name_room = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Treats = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_room__46CA677C95FF13E0", x => x.Id_room);
                });

            migrationBuilder.CreateTable(
                name: "tbl_special_events",
                columns: table => new
                {
                    Id_special_events = table.Column<int>(type: "int", nullable: false),
                    Id_employee = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    StartHour = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndHour = table.Column<TimeSpan>(type: "time", nullable: true),
                    Work = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_spec__77988C6AD112F0B5", x => x.Id_special_events);
                });

            migrationBuilder.CreateTable(
                name: "tbl_treat",
                columns: table => new
                {
                    Id_treat = table.Column<int>(type: "int", nullable: false),
                    nameTreat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_trea__C3F330BCB802BCFA", x => x.Id_treat);
                });

            migrationBuilder.CreateTable(
                name: "tbl_work_hours",
                columns: table => new
                {
                    Id_work_hours = table.Column<int>(type: "int", nullable: false),
                    Id_employee = table.Column<int>(type: "int", nullable: true),
                    Day = table.Column<int>(type: "int", nullable: true),
                    Shift = table.Column<int>(type: "int", nullable: true),
                    StartHour = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndHour = table.Column<TimeSpan>(type: "time", nullable: true),
                    ReglarWork = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_work__66F155F508FA8686", x => x.Id_work_hours);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "tbl_account");

            migrationBuilder.DropTable(
                name: "tbl_appointments");

            migrationBuilder.DropTable(
                name: "tbl_employees");

            migrationBuilder.DropTable(
                name: "tbl_inquiries");

            migrationBuilder.DropTable(
                name: "tbl_laser");

            migrationBuilder.DropTable(
                name: "tbl_room");

            migrationBuilder.DropTable(
                name: "tbl_special_events");

            migrationBuilder.DropTable(
                name: "tbl_treat");

            migrationBuilder.DropTable(
                name: "tbl_work_hours");
        }
    }
}
