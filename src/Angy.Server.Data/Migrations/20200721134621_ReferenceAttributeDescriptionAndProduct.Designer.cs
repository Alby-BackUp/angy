﻿// <auto-generated />
using System;
using Angy.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Angy.Server.Data.Migrations
{
    [DbContext(typeof(LuciferContext))]
    [Migration("20200721134621_ReferenceAttributeDescriptionAndProduct")]
    partial class ReferenceAttributeDescriptionAndProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "5.0.0-preview.6.20312.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Angy.Model.Attribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("Angy.Model.AttributeDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AttributeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("ProductId");

                    b.ToTable("AttributeDescriptions");
                });

            modelBuilder.Entity("Angy.Model.MicroCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("MicroCategoryParentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MicroCategoryParentId");

                    b.ToTable("MicroCategories");
                });

            modelBuilder.Entity("Angy.Model.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("MicroCategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MicroCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Angy.Model.AttributeDescription", b =>
                {
                    b.HasOne("Angy.Model.Attribute", "Attribute")
                        .WithMany("Descriptions")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Angy.Model.Product", "Product")
                        .WithMany("Descriptions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Angy.Model.MicroCategory", b =>
                {
                    b.HasOne("Angy.Model.MicroCategory", "MicroCategoryParent")
                        .WithMany()
                        .HasForeignKey("MicroCategoryParentId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Angy.Model.Product", b =>
                {
                    b.HasOne("Angy.Model.MicroCategory", "MicroCategory")
                        .WithMany("Products")
                        .HasForeignKey("MicroCategoryId")
                        .OnDelete(DeleteBehavior.NoAction);
                });
#pragma warning restore 612, 618
        }
    }
}