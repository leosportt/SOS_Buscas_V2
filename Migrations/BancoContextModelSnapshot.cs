﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SOS_Buscas_V2.Data;

#nullable disable

namespace SOS_Buscas_V2.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SOS_Buscas_V2.Models.DesaparecidoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Altura")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("CaminhoImagem")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CorPele")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("DataHoraDesaparecimento")
                        .HasColumnType("DateTime");

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Estilocabelo")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<string>("Observacoes")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Roupa")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Tatoagem")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EmailUsuario");

                    b.ToTable("Desaparecidos");
                });

            modelBuilder.Entity("SOS_Buscas_V2.Models.UsuarioModel", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("varchar(45)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("DateTime");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.HasKey("Email");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SOS_Buscas_V2.Models.DesaparecidoModel", b =>
                {
                    b.HasOne("SOS_Buscas_V2.Models.UsuarioModel", "Email")
                        .WithMany()
                        .HasForeignKey("EmailUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Email");
                });
#pragma warning restore 612, 618
        }
    }
}
