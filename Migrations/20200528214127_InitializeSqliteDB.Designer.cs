﻿// <auto-generated />
using System;
using Discord_Bot_Tutorial.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Discord_Bot_Tutorial.Migrations
{
    [DbContext(typeof(SqliteContext))]
    [Migration("20200528214127_InitializeSqliteDB")]
    partial class InitializeSqliteDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("Discord_Bot_Tutorial.Models.MutedUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MemberID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("MutedExpiration")
                        .HasColumnType("TEXT");

                    b.Property<string>("MutedReason")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MutedUsers");
                });

            modelBuilder.Entity("Discord_Bot_Tutorial.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("dps")
                        .HasColumnType("INTEGER");

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
#pragma warning restore 612, 618
        }
    }
}