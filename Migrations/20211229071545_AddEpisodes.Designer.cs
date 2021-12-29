﻿// <auto-generated />
using System;
using Almanime.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Almanime.Migrations
{
    [DbContext(typeof(AlmanimeContext))]
    [Migration("20211229071545_AddEpisodes")]
    partial class AddEpisodes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Almanime.Models.Anime", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("KitsuID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Season")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Synopsis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KitsuID")
                        .IsUnique();

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("Almanime.Models.Episode", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Aired")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("AnimeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int?>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AnimeID");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("Almanime.Models.Anime", b =>
                {
                    b.OwnsOne("Almanime.Models.SizedImage", "CoverImages", b1 =>
                        {
                            b1.Property<Guid>("AnimeID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Original")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Small")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Tiny")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AnimeID");

                            b1.ToTable("Animes");

                            b1.WithOwner()
                                .HasForeignKey("AnimeID");
                        });

                    b.OwnsOne("Almanime.Models.SizedImage", "PosterImages", b1 =>
                        {
                            b1.Property<Guid>("AnimeID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Original")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Small")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Tiny")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AnimeID");

                            b1.ToTable("Animes");

                            b1.WithOwner()
                                .HasForeignKey("AnimeID");
                        });

                    b.Navigation("CoverImages");

                    b.Navigation("PosterImages");
                });

            modelBuilder.Entity("Almanime.Models.Episode", b =>
                {
                    b.HasOne("Almanime.Models.Anime", "Anime")
                        .WithMany("Episodes")
                        .HasForeignKey("AnimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");
                });

            modelBuilder.Entity("Almanime.Models.Anime", b =>
                {
                    b.Navigation("Episodes");
                });
#pragma warning restore 612, 618
        }
    }
}
