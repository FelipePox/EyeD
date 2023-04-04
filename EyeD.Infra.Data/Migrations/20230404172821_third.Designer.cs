﻿// <auto-generated />
using System;
using EyeD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EyeD.Infra.Data.Migrations
{
    [DbContext(typeof(EyeDContext))]
    [Migration("20230404172821_third")]
    partial class third
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EyeD.Domain.Entities.HMDs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("HMDs");
                });

            modelBuilder.Entity("EyeD.Domain.Entities.People", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("EyeD.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EyeD.Domain.Entities.Vehicles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("EyeD.Domain.Entities.HMDs", b =>
                {
                    b.OwnsOne("EyeD.Domain.ValueObjects.Description", "Description", b1 =>
                        {
                            b1.Property<Guid>("HMDsId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Texto")
                                .IsRequired()
                                .HasColumnType("varchar(120)")
                                .HasColumnName("Description");

                            b1.HasKey("HMDsId");

                            b1.ToTable("HMDs");

                            b1.WithOwner()
                                .HasForeignKey("HMDsId");
                        });

                    b.OwnsOne("EyeD.Domain.ValueObjects.IPV4", "IPV4", b1 =>
                        {
                            b1.Property<Guid>("HMDsId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Texto")
                                .IsRequired()
                                .HasColumnType("varchar(15)")
                                .HasColumnName("IPV4");

                            b1.HasKey("HMDsId");

                            b1.ToTable("HMDs");

                            b1.WithOwner()
                                .HasForeignKey("HMDsId");
                        });

                    b.OwnsOne("EyeD.Domain.ValueObjects.MacAddress", "MacAddress", b1 =>
                        {
                            b1.Property<Guid>("HMDsId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Texto")
                                .IsRequired()
                                .HasColumnType("varchar(17)")
                                .HasColumnName("MacAdress");

                            b1.HasKey("HMDsId");

                            b1.ToTable("HMDs");

                            b1.WithOwner()
                                .HasForeignKey("HMDsId");
                        });

                    b.OwnsOne("EyeD.Domain.ValueObjects.SKU", "SKU", b1 =>
                        {
                            b1.Property<Guid>("HMDsId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Texto")
                                .IsRequired()
                                .HasColumnType("varchar(200)")
                                .HasColumnName("SKU");

                            b1.HasKey("HMDsId");

                            b1.ToTable("HMDs");

                            b1.WithOwner()
                                .HasForeignKey("HMDsId");
                        });

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("IPV4")
                        .IsRequired();

                    b.Navigation("MacAddress")
                        .IsRequired();

                    b.Navigation("SKU")
                        .IsRequired();
                });

            modelBuilder.Entity("EyeD.Domain.Entities.People", b =>
                {
                    b.OwnsOne("EyeD.Domain.ValueObjects.ExternalImageId", "ExternalImageId", b1 =>
                        {
                            b1.Property<Guid>("PeopleId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Texto")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("ExternalImageId");

                            b1.HasKey("PeopleId");

                            b1.ToTable("Peoples");

                            b1.WithOwner()
                                .HasForeignKey("PeopleId");
                        });

                    b.OwnsOne("EyeD.Domain.ValueObjects.FaceId", "FaceId", b1 =>
                        {
                            b1.Property<Guid>("PeopleId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Texto")
                                .IsRequired()
                                .HasColumnType("varchar(35)")
                                .HasColumnName("FaceId");

                            b1.HasKey("PeopleId");

                            b1.ToTable("Peoples");

                            b1.WithOwner()
                                .HasForeignKey("PeopleId");
                        });

                    b.OwnsOne("EyeD.Domain.ValueObjects.FullName", "Name", b1 =>
                        {
                            b1.Property<Guid>("PeopleId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasColumnType("varchar(20)")
                                .HasColumnName("FirstNome");

                            b1.Property<string>("SegundoNome")
                                .IsRequired()
                                .HasColumnType("varchar(60)")
                                .HasColumnName("SecondNome");

                            b1.Property<string>("TerceiroNome")
                                .IsRequired()
                                .HasColumnType("varchar(20)")
                                .HasColumnName("ThirdNome");

                            b1.HasKey("PeopleId");

                            b1.ToTable("Peoples");

                            b1.WithOwner()
                                .HasForeignKey("PeopleId");
                        });

                    b.OwnsOne("EyeD.Domain.ValueObjects.ImageId", "ImageId", b1 =>
                        {
                            b1.Property<Guid>("PeopleId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Texto")
                                .IsRequired()
                                .HasColumnType("varchar(35)")
                                .HasColumnName("ImageId");

                            b1.HasKey("PeopleId");

                            b1.ToTable("Peoples");

                            b1.WithOwner()
                                .HasForeignKey("PeopleId");
                        });

                    b.OwnsOne("EyeD.Domain.ValueObjects.ReferenceDocument", "ReferenceDocument", b1 =>
                        {
                            b1.Property<Guid>("PeopleId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Texto")
                                .IsRequired()
                                .HasColumnType("varchar(16)")
                                .HasColumnName("ReferenceDocument");

                            b1.HasKey("PeopleId");

                            b1.ToTable("Peoples");

                            b1.WithOwner()
                                .HasForeignKey("PeopleId");
                        });

                    b.Navigation("ExternalImageId")
                        .IsRequired();

                    b.Navigation("FaceId")
                        .IsRequired();

                    b.Navigation("ImageId")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("ReferenceDocument")
                        .IsRequired();
                });

            modelBuilder.Entity("EyeD.Domain.Entities.User", b =>
                {
                    b.OwnsOne("EyeD.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("EyeD.Domain.ValueObjects.Name", "Nome", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Texto")
                                .IsRequired()
                                .HasColumnType("varchar(60)")
                                .HasColumnName("Nome");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("EyeD.Domain.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Texto")
                                .IsRequired()
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Senha");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Nome")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });

            modelBuilder.Entity("EyeD.Domain.Entities.Vehicles", b =>
                {
                    b.OwnsOne("EyeD.Domain.ValueObjects.Brand", "Brand", b1 =>
                        {
                            b1.Property<Guid>("VehiclesId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Texto")
                                .IsRequired()
                                .HasColumnType("varchar(60)")
                                .HasColumnName("Marca");

                            b1.HasKey("VehiclesId");

                            b1.ToTable("Vehicles");

                            b1.WithOwner()
                                .HasForeignKey("VehiclesId");
                        });

                    b.OwnsOne("EyeD.Domain.ValueObjects.Model", "Model", b1 =>
                        {
                            b1.Property<Guid>("VehiclesId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Texto")
                                .IsRequired()
                                .HasColumnType("varchar(60)")
                                .HasColumnName("Modelo");

                            b1.HasKey("VehiclesId");

                            b1.ToTable("Vehicles");

                            b1.WithOwner()
                                .HasForeignKey("VehiclesId");
                        });

                    b.OwnsOne("EyeD.Domain.ValueObjects.ModelYear", "ModelYear", b1 =>
                        {
                            b1.Property<Guid>("VehiclesId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Texto")
                                .IsRequired()
                                .HasColumnType("varchar(4)")
                                .HasColumnName("ModeloAno");

                            b1.HasKey("VehiclesId");

                            b1.ToTable("Vehicles");

                            b1.WithOwner()
                                .HasForeignKey("VehiclesId");
                        });

                    b.OwnsOne("EyeD.Domain.ValueObjects.Plate", "Plate", b1 =>
                        {
                            b1.Property<Guid>("VehiclesId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Texto")
                                .IsRequired()
                                .HasColumnType("varchar(7)")
                                .HasColumnName("Placa");

                            b1.HasKey("VehiclesId");

                            b1.ToTable("Vehicles");

                            b1.WithOwner()
                                .HasForeignKey("VehiclesId");
                        });

                    b.Navigation("Brand")
                        .IsRequired();

                    b.Navigation("Model")
                        .IsRequired();

                    b.Navigation("ModelYear")
                        .IsRequired();

                    b.Navigation("Plate")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
