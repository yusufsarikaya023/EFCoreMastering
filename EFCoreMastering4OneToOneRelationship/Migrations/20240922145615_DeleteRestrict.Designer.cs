﻿// <auto-generated />
using EFCoreMastering4OneToOneRelationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreMastering4OneToOneRelationship.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240922145615_DeleteRestrict")]
    partial class DeleteRestrict
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCoreMastering4OneToOneRelationship.Domain.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("EFCoreMastering4OneToOneRelationship.Domain.BrandImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId")
                        .IsUnique();

                    b.ToTable("BrandImages");
                });

            modelBuilder.Entity("EFCoreMastering4OneToOneRelationship.Domain.BrandImage", b =>
                {
                    b.HasOne("EFCoreMastering4OneToOneRelationship.Domain.Brand", "Brand")
                        .WithOne("Image")
                        .HasForeignKey("EFCoreMastering4OneToOneRelationship.Domain.BrandImage", "BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("EFCoreMastering4OneToOneRelationship.Domain.Brand", b =>
                {
                    b.Navigation("Image")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
