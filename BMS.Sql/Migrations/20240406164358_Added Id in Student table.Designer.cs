﻿// <auto-generated />
using System;
using BMS.Sql.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BMS.Sql.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240406164358_Added Id in Student table")]
    partial class AddedIdinStudenttable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BMS.Domain.Models.Book", b =>
                {
                    b.Property<Guid>("BookCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Categoryid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CopiesAvailable")
                        .HasColumnType("bit");

                    b.HasKey("BookCode");

                    b.HasIndex("Categoryid");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BMS.Domain.Models.BookCategory", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("BookCategories");
                });

            modelBuilder.Entity("BMS.Domain.Models.Student", b =>
                {
                    b.Property<int>("Std")
                        .HasColumnType("int");

                    b.Property<string>("Div")
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("RollNo")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Std", "Div", "RollNo");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("BMS.Domain.Models.Book", b =>
                {
                    b.HasOne("BMS.Domain.Models.BookCategory", "Category")
                        .WithMany("Books")
                        .HasForeignKey("Categoryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BMS.Domain.Models.BookCategory", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
