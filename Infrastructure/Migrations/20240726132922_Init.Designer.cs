﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240726132922_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.InstallmentPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PlanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InstallmentPlans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PlanName = "Yearly"
                        },
                        new
                        {
                            Id = 2,
                            PlanName = "Quarterly"
                        },
                        new
                        {
                            Id = 3,
                            PlanName = "Semi-Annual"
                        },
                        new
                        {
                            Id = 4,
                            PlanName = "Monthly "
                        });
                });

            modelBuilder.Entity("Domain.Entities.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AvailabilityStatus")
                        .HasColumnType("bit");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("RoomCount")
                        .HasColumnType("int");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("View")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailabilityStatus = true,
                            Floor = 1,
                            RoomCount = 3,
                            UnitName = "400",
                            View = "Nile"
                        },
                        new
                        {
                            Id = 2,
                            AvailabilityStatus = true,
                            Floor = 1,
                            RoomCount = 4,
                            UnitName = "401",
                            View = "Nile"
                        },
                        new
                        {
                            Id = 3,
                            AvailabilityStatus = false,
                            Floor = 2,
                            RoomCount = 2,
                            UnitName = "402",
                            View = "City"
                        },
                        new
                        {
                            Id = 4,
                            AvailabilityStatus = true,
                            Floor = 2,
                            RoomCount = 3,
                            UnitName = "403",
                            View = "Nile"
                        },
                        new
                        {
                            Id = 5,
                            AvailabilityStatus = true,
                            Floor = 3,
                            RoomCount = 3,
                            UnitName = "404",
                            View = "City"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "kirofayez23@gmail.com",
                            Name = "Kerolos Fayez",
                            Password = "S9kdBKUu2pUOQVQPJjyiiGVrhKCRJkSlgv20eeU/qWQ74Jxl",
                            Phone = "01202982836"
                        },
                        new
                        {
                            Id = 2,
                            Email = "mosalah@gmail.com",
                            Name = "Mo Salah",
                            Password = "SciBOug4eixdTH0swqPjOGl+HJzrEY9x53byG3uB9yXwdYaG",
                            Phone = "01202982835"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserPaymentUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InstallmentPlanId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InstallmentStartDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("YearsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstallmentPlanId");

                    b.HasIndex("UnitId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPaymentUnits");
                });

            modelBuilder.Entity("Domain.Entities.UserPaymentUnitInstallment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("InstallmentAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("InstallmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstallmentNumber")
                        .HasColumnType("int");

                    b.Property<int>("InstallmentPaymentUnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstallmentPaymentUnitId");

                    b.ToTable("UserPaymentUnitInstallments");
                });

            modelBuilder.Entity("Domain.Entities.UserPaymentUnit", b =>
                {
                    b.HasOne("Domain.Entities.InstallmentPlan", "InstallmentPlan")
                        .WithMany()
                        .HasForeignKey("InstallmentPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InstallmentPlan");

                    b.Navigation("Unit");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserPaymentUnitInstallment", b =>
                {
                    b.HasOne("Domain.Entities.UserPaymentUnit", "UserPaymentUnit")
                        .WithMany()
                        .HasForeignKey("InstallmentPaymentUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserPaymentUnit");
                });
#pragma warning restore 612, 618
        }
    }
}
