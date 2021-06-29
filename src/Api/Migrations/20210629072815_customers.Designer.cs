﻿// <auto-generated />
using System;
using Api.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Migrations
{
    [DbContext(typeof(ApiDotNetDbContext))]
    [Migration("20210629072815_customers")]
    partial class customers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Db.Entities.AddressEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CustomerEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerEntityId");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("Api.Db.Entities.CustomerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(14)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CpfCnpj" }, "UK_CpfCnpj")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Api.Db.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserName" }, "UK_UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Api.Db.Entities.AddressEntity", b =>
                {
                    b.HasOne("Api.Db.Entities.CustomerEntity", null)
                        .WithMany("Adresses")
                        .HasForeignKey("CustomerEntityId");
                });

            modelBuilder.Entity("Api.Db.Entities.CustomerEntity", b =>
                {
                    b.Navigation("Adresses");
                });
#pragma warning restore 612, 618
        }
    }
}