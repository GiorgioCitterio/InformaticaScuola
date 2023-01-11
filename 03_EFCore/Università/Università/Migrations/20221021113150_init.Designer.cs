﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Università.Data;

#nullable disable

namespace Università.Migrations
{
    [DbContext(typeof(UniveristàContext))]
    [Migration("20221021113150_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Università.Model.Corso", b =>
                {
                    b.Property<int>("CodiceCorso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CodDocente")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CodiceCorso");

                    b.HasIndex("CodDocente");

                    b.ToTable("Corso");
                });

            modelBuilder.Entity("Università.Model.CorsoLaurea", b =>
                {
                    b.Property<int>("CorsoLaureaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Facoltà")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoLaurea")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CorsoLaureaId");

                    b.ToTable("CorsoLaurea");
                });

            modelBuilder.Entity("Università.Model.Docente", b =>
                {
                    b.Property<int>("CodDocente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Dipartimento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CodDocente");

                    b.ToTable("Docente");
                });

            modelBuilder.Entity("Università.Model.Frequenta", b =>
                {
                    b.Property<int>("Matricola")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CodCorso")
                        .HasColumnType("INTEGER");

                    b.HasKey("Matricola", "CodCorso");

                    b.HasIndex("CodCorso");

                    b.ToTable("Frequenta");
                });

            modelBuilder.Entity("Università.Model.Studente", b =>
                {
                    b.Property<int>("Matricola")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnnoDiNascita")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CorsoLaureaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Matricola");

                    b.HasIndex("CorsoLaureaId");

                    b.ToTable("Studente");
                });

            modelBuilder.Entity("Università.Model.Corso", b =>
                {
                    b.HasOne("Università.Model.Docente", "Docente")
                        .WithMany("Corso")
                        .HasForeignKey("CodDocente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Docente");
                });

            modelBuilder.Entity("Università.Model.Frequenta", b =>
                {
                    b.HasOne("Università.Model.Corso", "Corso")
                        .WithMany("Frequenta")
                        .HasForeignKey("CodCorso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Università.Model.Studente", "Studente")
                        .WithMany("Frequenta")
                        .HasForeignKey("Matricola")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Corso");

                    b.Navigation("Studente");
                });

            modelBuilder.Entity("Università.Model.Studente", b =>
                {
                    b.HasOne("Università.Model.CorsoLaurea", "CorsoLaurea")
                        .WithMany("Studente")
                        .HasForeignKey("CorsoLaureaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CorsoLaurea");
                });

            modelBuilder.Entity("Università.Model.Corso", b =>
                {
                    b.Navigation("Frequenta");
                });

            modelBuilder.Entity("Università.Model.CorsoLaurea", b =>
                {
                    b.Navigation("Studente");
                });

            modelBuilder.Entity("Università.Model.Docente", b =>
                {
                    b.Navigation("Corso");
                });

            modelBuilder.Entity("Università.Model.Studente", b =>
                {
                    b.Navigation("Frequenta");
                });
#pragma warning restore 612, 618
        }
    }
}
