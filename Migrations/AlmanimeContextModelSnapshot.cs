﻿// <auto-generated />
using System;
using Almanime.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Almanime.Migrations
{
    [DbContext(typeof(AlmanimeContext))]
    partial class AlmanimeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Almanime.Models.Bookmark", b =>
                {
                    b.Property<Guid>("AnimeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AnimeID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("Bookmarks");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AnimeID");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("Almanime.Models.Fansub", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Webpage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Acronym")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Fansubs");
                });

            modelBuilder.Entity("Almanime.Models.FansubRole", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FansubID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID", "FansubID");

                    b.HasIndex("FansubID");

                    b.ToTable("FansubRoles");
                });

            modelBuilder.Entity("Almanime.Models.Membership", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<Guid>("FansubID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("RoleID", "FansubID");

                    b.HasIndex("UserID", "FansubID")
                        .IsUnique();

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("Almanime.Models.Subtitle", b =>
                {
                    b.Property<Guid>("EpisodeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("Format")
                        .HasColumnType("int");

                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EpisodeID");

                    b.ToTable("Subtitles");
                });

            modelBuilder.Entity("Almanime.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Auth0ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Auth0ID")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Users");
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

            modelBuilder.Entity("Almanime.Models.Bookmark", b =>
                {
                    b.HasOne("Almanime.Models.Anime", "Anime")
                        .WithMany()
                        .HasForeignKey("AnimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Almanime.Models.User", "User")
                        .WithMany("Bookmarks")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("User");
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

            modelBuilder.Entity("Almanime.Models.FansubRole", b =>
                {
                    b.HasOne("Almanime.Models.Fansub", "Fansub")
                        .WithMany()
                        .HasForeignKey("FansubID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fansub");
                });

            modelBuilder.Entity("Almanime.Models.Membership", b =>
                {
                    b.HasOne("Almanime.Models.User", "User")
                        .WithMany("Memberships")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Almanime.Models.FansubRole", "FansubRole")
                        .WithMany("Memberships")
                        .HasForeignKey("RoleID", "FansubID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FansubRole");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Almanime.Models.Subtitle", b =>
                {
                    b.HasOne("Almanime.Models.Episode", "Episode")
                        .WithMany("Subtitles")
                        .HasForeignKey("EpisodeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Episode");
                });

            modelBuilder.Entity("Almanime.Models.Anime", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("Almanime.Models.Episode", b =>
                {
                    b.Navigation("Subtitles");
                });

            modelBuilder.Entity("Almanime.Models.FansubRole", b =>
                {
                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("Almanime.Models.User", b =>
                {
                    b.Navigation("Bookmarks");

                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
