﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebChess.Data;

namespace WebChess.Migrations
{
    [DbContext(typeof(WebChessContext))]
    [Migration("20200816113505_ChessGameMig")]
    partial class ChessGameMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebChess.Models.ChessGame", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fens")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gameType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pgn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("playerBlack")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("playerWhite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("winner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ChessGame");
                });
#pragma warning restore 612, 618
        }
    }
}