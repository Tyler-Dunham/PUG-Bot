﻿// <auto-generated />
using Discord_Bot_Tutorial.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Discord_Bot_Tutorial.Migrations
{
    [DbContext(typeof(SqliteContext))]
    partial class SqliteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("Discord_Bot_Tutorial.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("dps")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("queue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("queueSr")
                        .HasColumnType("INTEGER");

                    b.Property<string>("role")
                        .HasColumnType("TEXT");

                    b.Property<int>("support")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tank")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("userID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("userName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Discord_Bot_Tutorial.Models.Queue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("queueSr")
                        .HasColumnType("INTEGER");

                    b.Property<string>("role")
                        .HasColumnType("TEXT");

                    b.Property<ulong>("userID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("userName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("playerQueue");
                });
#pragma warning restore 612, 618
        }
    }
}
