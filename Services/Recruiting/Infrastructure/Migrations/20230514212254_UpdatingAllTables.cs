using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateSubmission",
                columns: table => new
                {
                    CandidatesId = table.Column<int>(type: "int", nullable: false),
                    SubmissionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSubmission", x => new { x.CandidatesId, x.SubmissionsId });
                    table.ForeignKey(
                        name: "FK_CandidateSubmission_Candidates_CandidatesId",
                        column: x => x.CandidatesId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSubmission_Submissions_SubmissionsId",
                        column: x => x.SubmissionsId,
                        principalTable: "Submissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobRequirement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yoe = table.Column<int>(type: "int", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequirement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobRequirement_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSubmission_SubmissionsId",
                table: "CandidateSubmission",
                column: "SubmissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequirement_JobId",
                table: "JobRequirement",
                column: "JobId",
                unique: true,
                filter: "[JobId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateSubmission");

            migrationBuilder.DropTable(
                name: "JobRequirement");
        }
    }
}
