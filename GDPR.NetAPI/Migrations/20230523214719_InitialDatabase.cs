using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GDPR.NetAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    identificationCode = table.Column<string>(type: "text", nullable: false),
                    firstName = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false),
                    companyName = table.Column<string>(type: "text", nullable: false),
                    countyCode = table.Column<string>(type: "text", nullable: false),
                    mobilePhone = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    gdprAgreement = table.Column<bool>(type: "boolean", nullable: false),
                    marketingAgreement = table.Column<bool>(type: "boolean", nullable: false),
                    emailCommunication = table.Column<bool>(type: "boolean", nullable: false),
                    mobileCommunication = table.Column<bool>(type: "boolean", nullable: false),
                    agreementDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.identificationCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements");
        }
    }
}
