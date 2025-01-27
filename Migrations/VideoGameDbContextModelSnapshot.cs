﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using asp_net_web_api_course.Data;

#nullable disable

namespace asp_net_web_api_course.Migrations
{
    [DbContext(typeof(VideoGameDbContext))]
    partial class VideoGameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("asp_net_web_api_course.Models.Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VideoGameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VideoGameId")
                        .IsUnique();

                    b.ToTable("Details");
                });

            modelBuilder.Entity("asp_net_web_api_course.Models.VideoGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Developer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Platform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VideoGames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Developer = "Nintendo EPD",
                            Platform = "Nintendo Switch",
                            Publisher = "Nintendo",
                            Title = "The Legend of Zelda: Breath of the Wild"
                        },
                        new
                        {
                            Id = 2,
                            Developer = "Nintendo EPD",
                            Platform = "Nintendo Switch",
                            Publisher = "Nintendo",
                            Title = "Super Mario Odyssey"
                        },
                        new
                        {
                            Id = 3,
                            Developer = "CD Projekt Red",
                            Platform = "PlayStation 4",
                            Publisher = "CD Projekt",
                            Title = "The Witcher 3: Wild Hunt"
                        });
                });

            modelBuilder.Entity("asp_net_web_api_course.Models.Details", b =>
                {
                    b.HasOne("asp_net_web_api_course.Models.VideoGame", null)
                        .WithOne("Details")
                        .HasForeignKey("asp_net_web_api_course.Models.Details", "VideoGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("asp_net_web_api_course.Models.VideoGame", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
