// <auto-generated />
using System;
using BankAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankAPI.Migrations
{
    [DbContext(typeof(YourBankDbContext))]
    [Migration("20220814195951_DbTest")]
    partial class DbTest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankAPI.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountNumberGenerated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<decimal>("CurrentAccountBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateLastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PinHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Pinsalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("BankAPI.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("TransactionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionDestinationAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionParticulars")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionSourceAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionStatus")
                        .HasColumnType("int");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<string>("TransactionUniqueReference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transaction");
                });
#pragma warning restore 612, 618
        }
    }
}
