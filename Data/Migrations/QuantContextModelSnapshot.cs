using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InstaCore.Data;
using InstaCore.Models;

namespace InstaCore.Migrations
{
    [DbContext(typeof(QuantContext))]
    partial class QuantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InstaCore.Models.DataTransferObjects.AccountSummaryDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountNumber");

                    b.Property<double>("Balance");

                    b.Property<string>("Description");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("AccountSummaryDto");
                });

            modelBuilder.Entity("InstaCore.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Currency");

                    b.Property<string>("Description");

                    b.Property<int?>("InstitutionId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("InstaCore.Models.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("InstaCore.Models.Institution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Institution");
                });

            modelBuilder.Entity("InstaCore.Models.Investor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<decimal>("SharePercentage");

                    b.HasKey("Id");

                    b.ToTable("Investor");
                });

            modelBuilder.Entity("InstaCore.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("InstitutionId");

                    b.Property<DateTime>("InvoiceDate");

                    b.Property<string>("InvoiceNumber");

                    b.Property<bool>("IsReceived");

                    b.Property<string>("Participant");

                    b.Property<DateTime?>("PaymentDueDate");

                    b.Property<decimal>("TotalNetCharge");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("InstaCore.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("InstaCore.Models.Account", b =>
                {
                    b.HasOne("InstaCore.Models.Institution")
                        .WithMany("Accounts")
                        .HasForeignKey("InstitutionId");
                });

            modelBuilder.Entity("InstaCore.Models.Invoice", b =>
                {
                    b.HasOne("InstaCore.Models.Institution")
                        .WithMany("Invoices")
                        .HasForeignKey("InstitutionId");
                });

            modelBuilder.Entity("InstaCore.Models.Transaction", b =>
                {
                    b.HasOne("InstaCore.Models.Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId");
                });
        }
    }
}
