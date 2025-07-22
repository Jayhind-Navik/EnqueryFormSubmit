using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnqueryFormSubmit.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enquiries",
                columns: table => new
                {
                    EnquiryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnquiryNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnquiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SurveyDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiries", x => x.EnquiryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enquiries");
        }
    }
}
