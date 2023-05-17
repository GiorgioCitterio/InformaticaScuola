﻿// <auto-generated />
using System;
using EsercizioPreVerifica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EsercizioPreVerifica.Migrations
{
    [DbContext(typeof(FilmDbContext))]
    partial class FilmDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EsercizioPreVerifica.Model.Cinema", b =>
                {
                    b.Property<int>("CinemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Città")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Indirizzo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CinemaId");

                    b.ToTable("Cinemas");

                    b.HasData(
                        new
                        {
                            CinemaId = 1,
                            Città = "città1",
                            Indirizzo = "indirizzo1",
                            Nome = "nome1"
                        },
                        new
                        {
                            CinemaId = 2,
                            Città = "città2",
                            Indirizzo = "indirizzo2",
                            Nome = "nome2"
                        },
                        new
                        {
                            CinemaId = 3,
                            Città = "città3",
                            Indirizzo = "indirizzo3",
                            Nome = "nome3"
                        });
                });

            modelBuilder.Entity("EsercizioPreVerifica.Model.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDiProduzione")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.Property<int>("RegistaId")
                        .HasColumnType("int");

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("FilmId");

                    b.HasIndex("RegistaId");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            FilmId = 1,
                            DataDiProduzione = new DateTime(2023, 5, 15, 11, 39, 23, 755, DateTimeKind.Local).AddTicks(2608),
                            Durata = 180,
                            RegistaId = 1,
                            Titolo = "c"
                        },
                        new
                        {
                            FilmId = 2,
                            DataDiProduzione = new DateTime(2023, 5, 15, 9, 39, 23, 755, DateTimeKind.Utc).AddTicks(2659),
                            Durata = 300,
                            RegistaId = 2,
                            Titolo = "d"
                        },
                        new
                        {
                            FilmId = 3,
                            DataDiProduzione = new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            Durata = 700,
                            RegistaId = 2,
                            Titolo = "e"
                        },
                        new
                        {
                            FilmId = 4,
                            DataDiProduzione = new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            Durata = 60,
                            RegistaId = 3,
                            Titolo = "j"
                        });
                });

            modelBuilder.Entity("EsercizioPreVerifica.Model.Proiezione", b =>
                {
                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Ora")
                        .HasColumnType("datetime(6)");

                    b.HasKey("CinemaId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("Proieziones");

                    b.HasData(
                        new
                        {
                            CinemaId = 1,
                            FilmId = 1,
                            Data = new DateTime(2023, 5, 15, 11, 39, 23, 755, DateTimeKind.Local).AddTicks(2702),
                            Ora = new DateTime(2023, 5, 15, 11, 39, 23, 755, DateTimeKind.Local).AddTicks(2705)
                        },
                        new
                        {
                            CinemaId = 2,
                            FilmId = 2,
                            Data = new DateTime(2023, 5, 15, 11, 39, 23, 755, DateTimeKind.Local).AddTicks(2707),
                            Ora = new DateTime(2023, 5, 15, 11, 39, 23, 755, DateTimeKind.Local).AddTicks(2709)
                        },
                        new
                        {
                            CinemaId = 1,
                            FilmId = 3,
                            Data = new DateTime(2023, 5, 15, 11, 39, 23, 755, DateTimeKind.Local).AddTicks(2711),
                            Ora = new DateTime(2023, 5, 15, 11, 39, 23, 755, DateTimeKind.Local).AddTicks(2712)
                        },
                        new
                        {
                            CinemaId = 3,
                            FilmId = 1,
                            Data = new DateTime(2023, 5, 15, 11, 39, 23, 755, DateTimeKind.Local).AddTicks(2714),
                            Ora = new DateTime(2023, 5, 15, 11, 39, 23, 755, DateTimeKind.Local).AddTicks(2716)
                        });
                });

            modelBuilder.Entity("EsercizioPreVerifica.Model.Regista", b =>
                {
                    b.Property<int>("RegistaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nazionalità")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RegistaId");

                    b.ToTable("Registas");

                    b.HasData(
                        new
                        {
                            RegistaId = 1,
                            Cognome = "a",
                            Nazionalità = "IT",
                            Nome = "b"
                        },
                        new
                        {
                            RegistaId = 2,
                            Cognome = "f",
                            Nazionalità = "IT",
                            Nome = "g"
                        },
                        new
                        {
                            RegistaId = 3,
                            Cognome = "h",
                            Nazionalità = "IT",
                            Nome = "i"
                        });
                });

            modelBuilder.Entity("EsercizioPreVerifica.Model.Film", b =>
                {
                    b.HasOne("EsercizioPreVerifica.Model.Regista", "Regista")
                        .WithMany("Films")
                        .HasForeignKey("RegistaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Regista");
                });

            modelBuilder.Entity("EsercizioPreVerifica.Model.Proiezione", b =>
                {
                    b.HasOne("EsercizioPreVerifica.Model.Cinema", "Cinema")
                        .WithMany("Proieziones")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EsercizioPreVerifica.Model.Film", "Film")
                        .WithMany("Proieziones")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("EsercizioPreVerifica.Model.Cinema", b =>
                {
                    b.Navigation("Proieziones");
                });

            modelBuilder.Entity("EsercizioPreVerifica.Model.Film", b =>
                {
                    b.Navigation("Proieziones");
                });

            modelBuilder.Entity("EsercizioPreVerifica.Model.Regista", b =>
                {
                    b.Navigation("Films");
                });
#pragma warning restore 612, 618
        }
    }
}
