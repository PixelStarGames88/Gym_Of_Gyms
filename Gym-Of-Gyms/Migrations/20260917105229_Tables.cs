using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gym_Of_Gyms.Migrations
{
    /// <inheritdoc />
    public partial class Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Eating_Days",
                columns: table => new
                {
                    Day_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    User_Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eating_Days", x => x.Day_Id);
                    table.ForeignKey(
                        name: "FK_Eating_Days_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Exercise_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Energy_Cost = table.Column<double>(type: "double precision", nullable: true),
                    Height_Mass = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Exercise_Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFood",
                columns: table => new
                {
                    Food_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Calories = table.Column<double>(type: "double precision", nullable: false),
                    Protein = table.Column<double>(type: "double precision", nullable: false),
                    Fat = table.Column<double>(type: "double precision", nullable: false),
                    Carbohydrates = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFood", x => x.Food_Id);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Workout_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    User_Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Workout_Id);
                    table.ForeignKey(
                        name: "FK_Workouts_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eatings",
                columns: table => new
                {
                    Eating_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Eating_Time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Day_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eatings", x => x.Eating_Id);
                    table.ForeignKey(
                        name: "FK_Eatings_Eating_Days_Day_Id",
                        column: x => x.Day_Id,
                        principalTable: "Eating_Days",
                        principalColumn: "Day_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise_Records",
                columns: table => new
                {
                    Exercise_Record_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Set_Count = table.Column<int>(type: "integer", nullable: false),
                    Workout_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise_Records", x => x.Exercise_Record_Id);
                    table.ForeignKey(
                        name: "FK_Exercise_Records_Workouts_Workout_Id",
                        column: x => x.Workout_Id,
                        principalTable: "Workouts",
                        principalColumn: "Workout_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Records_Food",
                columns: table => new
                {
                    Record_Food_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mass = table.Column<double>(type: "double precision", nullable: false),
                    Eating_Id = table.Column<int>(type: "integer", nullable: false),
                    Food_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records_Food", x => x.Record_Food_Id);
                    table.ForeignKey(
                        name: "FK_Records_Food_Eatings_Eating_Id",
                        column: x => x.Eating_Id,
                        principalTable: "Eatings",
                        principalColumn: "Eating_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_Food_UserFood_Food_Id",
                        column: x => x.Food_Id,
                        principalTable: "UserFood",
                        principalColumn: "Food_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Set_Records",
                columns: table => new
                {
                    Set_Record_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start_Time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    End_Time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Repetitions = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: true),
                    Exercise_Record_Id = table.Column<int>(type: "integer", nullable: false),
                    Exercise_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Set_Records", x => x.Set_Record_Id);
                    table.ForeignKey(
                        name: "FK_Set_Records_Exercise_Records_Exercise_Record_Id",
                        column: x => x.Exercise_Record_Id,
                        principalTable: "Exercise_Records",
                        principalColumn: "Exercise_Record_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Set_Records_Exercises_Exercise_Id",
                        column: x => x.Exercise_Id,
                        principalTable: "Exercises",
                        principalColumn: "Exercise_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eating_Days_User_Id",
                table: "Eating_Days",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Eatings_Day_Id",
                table: "Eatings",
                column: "Day_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Records_Workout_Id",
                table: "Exercise_Records",
                column: "Workout_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Records_Food_Eating_Id",
                table: "Records_Food",
                column: "Eating_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Records_Food_Food_Id",
                table: "Records_Food",
                column: "Food_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Set_Records_Exercise_Id",
                table: "Set_Records",
                column: "Exercise_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Set_Records_Exercise_Record_Id",
                table: "Set_Records",
                column: "Exercise_Record_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_User_Id",
                table: "Workouts",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records_Food");

            migrationBuilder.DropTable(
                name: "Set_Records");

            migrationBuilder.DropTable(
                name: "Eatings");

            migrationBuilder.DropTable(
                name: "UserFood");

            migrationBuilder.DropTable(
                name: "Exercise_Records");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Eating_Days");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "AspNetUsers");
        }
    }
}
