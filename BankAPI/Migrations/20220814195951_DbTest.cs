using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankAPI.Migrations
{
    public partial class DbTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    AccountName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CurrentAccountBalance = table.Column<decimal>(nullable: false),
                    AccountType = table.Column<int>(nullable: false),
                    AccountNumberGenerated = table.Column<string>(nullable: true),
                    PinHash = table.Column<byte[]>(nullable: true),
                    Pinsalt = table.Column<byte[]>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateLastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionUniqueReference = table.Column<string>(nullable: true),
                    TransactionAmount = table.Column<decimal>(nullable: false),
                    TransactionStatus = table.Column<int>(nullable: false),
                    TransactionSourceAccount = table.Column<string>(nullable: true),
                    TransactionDestinationAccount = table.Column<string>(nullable: true),
                    TransactionParticulars = table.Column<string>(nullable: true),
                    TransactionType = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
