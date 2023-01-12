﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _01_PrimoEsempio.Data;

#nullable disable

namespace _01_PrimoEsempio.Migrations
{
    [DbContext(typeof(MezziContext))]
    partial class MezziContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("_01_PrimoEsempio.Model.Bus", b =>
                {
                    b.Property<int>("Telaio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Cilindrata")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marca")
                        .HasColumnType("TEXT");

                    b.Property<string>("Modello")
                        .HasColumnType("TEXT");

                    b.HasKey("Telaio");

                    b.ToTable("Bus");
                });

            modelBuilder.Entity("_01_PrimoEsempio.Model.Camion", b =>
                {
                    b.Property<int>("CamionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CamionName")
                        .HasColumnType("TEXT");

                    b.Property<int>("CamionType")
                        .HasColumnType("INTEGER");

                    b.HasKey("CamionId");

                    b.ToTable("Camions");
                });

            modelBuilder.Entity("_01_PrimoEsempio.Model.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marca")
                        .HasColumnType("TEXT");

                    b.Property<string>("Modello")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("_01_PrimoEsempio.Model.Motorino", b =>
                {
                    b.Property<int>("NumeroTelaio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marca")
                        .HasColumnType("TEXT");

                    b.Property<string>("Modello")
                        .HasColumnType("TEXT");

                    b.HasKey("NumeroTelaio");

                    b.ToTable("Motorinos");
                });
#pragma warning restore 612, 618
        }
    }
}