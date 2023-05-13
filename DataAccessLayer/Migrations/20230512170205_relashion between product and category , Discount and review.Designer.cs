﻿// <auto-generated />
using System;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230512170205_relashion between product and category , Discount and review")]
    partial class relashionbetweenproductandcategoryDiscountandreview
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Entities.Brand", b =>
                {
                    b.Property<int>("brand_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("brand_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("brand_id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Category", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("category_id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Discount", b =>
                {
                    b.Property<int>("discount_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("discount_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("discount_enabled")
                        .HasColumnType("bit");

                    b.Property<string>("discount_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("discount_persentage")
                        .HasColumnType("int");

                    b.Property<decimal>("maxValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("discount_id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Product", b =>
                {
                    b.Property<int>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("brand_id")
                        .HasColumnType("int");

                    b.Property<int?>("category_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("discount_id")
                        .HasColumnType("int");

                    b.Property<byte[]>("image")
                        .HasColumnType("varbinary(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("product_name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("product_id");

                    b.HasIndex("brand_id");

                    b.HasIndex("category_id");

                    b.HasIndex("discount_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Review", b =>
                {
                    b.Property<int>("review_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Coment_Updated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Commented_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("review_id");

                    b.HasIndex("product_id");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Product", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Brand", "brand")
                        .WithMany("products")
                        .HasForeignKey("brand_id");

                    b.HasOne("DataAccessLayer.Entities.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("category_id");

                    b.HasOne("DataAccessLayer.Entities.Discount", "discount")
                        .WithMany("products")
                        .HasForeignKey("discount_id");

                    b.Navigation("brand");

                    b.Navigation("category");

                    b.Navigation("discount");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Review", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Product", "product")
                        .WithMany("reviews")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Brand", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Discount", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Product", b =>
                {
                    b.Navigation("reviews");
                });
#pragma warning restore 612, 618
        }
    }
}