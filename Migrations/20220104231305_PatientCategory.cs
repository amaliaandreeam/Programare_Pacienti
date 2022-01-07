using Microsoft.EntityFrameworkCore.Migrations;

namespace Programare_Pacienti.Migrations
{
    public partial class PatientCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultationID",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryAge = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Consultation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultationReview = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PatientCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientCategory_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ConsultationID",
                table: "Patient",
                column: "ConsultationID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCategory_CategoryID",
                table: "PatientCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCategory_PatientID",
                table: "PatientCategory",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Consultation_ConsultationID",
                table: "Patient",
                column: "ConsultationID",
                principalTable: "Consultation",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Consultation_ConsultationID",
                table: "Patient");

            migrationBuilder.DropTable(
                name: "Consultation");

            migrationBuilder.DropTable(
                name: "PatientCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Patient_ConsultationID",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "ConsultationID",
                table: "Patient");
        }
    }
}
