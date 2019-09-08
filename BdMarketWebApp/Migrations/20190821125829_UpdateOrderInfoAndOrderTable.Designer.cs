﻿// <auto-generated />
using BdMarketWebApp.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BdMarketWebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190821125829_UpdateOrderInfoAndOrderTable")]
    partial class UpdateOrderInfoAndOrderTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BdMarketWebApp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionName");

                    b.Property<string>("ActionTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BdMarketWebApp.Models.Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionDone");

                    b.Property<string>("ActionTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("BdMarketWebApp.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionDone");

                    b.Property<string>("ActionTime");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("DesignationId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("ProfilePicture");

                    b.Property<int>("State");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DesignationId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BdMarketWebApp.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionDone");

                    b.Property<string>("ActionTime");

                    b.Property<int>("CategoryId");

                    b.Property<int>("InfoId");

                    b.Property<int>("IsClientState");

                    b.Property<int>("IsDelivered");

                    b.Property<int>("IsNew");

                    b.Property<int>("IsReceived");

                    b.Property<string>("LastActionBy");

                    b.Property<string>("OrderDate");

                    b.Property<string>("OrderId");

                    b.Property<string>("OrderMonth");

                    b.Property<string>("OrderYear");

                    b.Property<int>("ProductId");

                    b.Property<decimal>("ProductPrice");

                    b.Property<decimal>("Profit");

                    b.Property<int>("Quantity");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("InfoId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BdMarketWebApp.Models.OrderInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionById");

                    b.Property<string>("ActionTime");

                    b.Property<string>("AddressOne");

                    b.Property<string>("AddressTwo");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("IsClientState");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.HasIndex("ActionById");

                    b.ToTable("OrderInfo");
                });

            modelBuilder.Entity("BdMarketWebApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionDone");

                    b.Property<string>("ActionTime");

                    b.Property<decimal>("BasePrice");

                    b.Property<int>("CategoryId");

                    b.Property<string>("EntryDate")
                        .IsRequired();

                    b.Property<int>("EntryMonth");

                    b.Property<int>("EntryYear");

                    b.Property<string>("PictureUrl");

                    b.Property<string>("ProductDescription");

                    b.Property<string>("ProductTitle")
                        .IsRequired();

                    b.Property<decimal>("Profit");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("SellPrice");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BdMarketWebApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountCreatingTime");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<int>("State");

                    b.Property<string>("UserName");

                    b.Property<string>("VerificationCode");

                    b.Property<int>("Verify");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BdMarketWebApp.Models.Employee", b =>
                {
                    b.HasOne("BdMarketWebApp.Models.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BdMarketWebApp.Models.Order", b =>
                {
                    b.HasOne("BdMarketWebApp.Models.Category", "Category")
                        .WithMany("Orders")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BdMarketWebApp.Models.OrderInfo", "OrderInfo")
                        .WithMany("Orders")
                        .HasForeignKey("InfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BdMarketWebApp.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BdMarketWebApp.Models.OrderInfo", b =>
                {
                    b.HasOne("BdMarketWebApp.Models.User", "User")
                        .WithMany("OrderInfos")
                        .HasForeignKey("ActionById")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BdMarketWebApp.Models.Product", b =>
                {
                    b.HasOne("BdMarketWebApp.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
