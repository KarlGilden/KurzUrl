﻿// <auto-generated />
using KurzUrl.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KurzUrl.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231203034100_AddSlug")]
    partial class AddSlug
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("KurzUrl.Models.Url", b =>
                {
                    b.Property<string>("Slug")
                        .HasColumnType("varchar(255)");

                    b.Property<short>("Clicks")
                        .HasColumnType("smallint");

                    b.Property<string>("OriginalUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Slug");

                    b.ToTable("Urls");
                });
#pragma warning restore 612, 618
        }
    }
}
