﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestEntityFrameworkExceptions;

#nullable disable

namespace TestEntityFrameworkExceptions.Migrations
{
    [DbContext(typeof(TestContext))]
    [Migration("20240731133414_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.Montant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)")
                        .HasColumnName("discriminator");

                    b.HasKey("Id")
                        .HasName("pk_montants");

                    b.ToTable("montants", (string)null);

                    b.HasDiscriminator().HasValue("Montant");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.Piece", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)")
                        .HasColumnName("discriminator");

                    b.HasKey("Id")
                        .HasName("pk_pieces");

                    b.ToTable("pieces", (string)null);

                    b.HasDiscriminator().HasValue("Piece");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.Prescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.HasKey("Id")
                        .HasName("pk_prescriptions");

                    b.ToTable("prescriptions", (string)null);
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.Transport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("PrescriptionId")
                        .HasColumnType("uuid")
                        .HasColumnName("prescription_id");

                    b.HasKey("Id")
                        .HasName("pk_transports");

                    b.HasIndex("PrescriptionId")
                        .HasDatabaseName("ix_transports_prescription_id");

                    b.ToTable("transports", (string)null);
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.MontantCrediteur", b =>
                {
                    b.HasBaseType("TestEntityFrameworkExceptions.Models.Montant");

                    b.Property<Guid>("PieceId")
                        .HasColumnType("uuid")
                        .HasColumnName("piece_id");

                    b.HasIndex("PieceId")
                        .HasDatabaseName("ix_montants_piece_id");

                    b.HasDiscriminator().HasValue("MontantCrediteur");
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.MontantDebiteur", b =>
                {
                    b.HasBaseType("TestEntityFrameworkExceptions.Models.Montant");

                    b.Property<Guid>("PieceId")
                        .HasColumnType("uuid")
                        .HasColumnName("piece_id");

                    b.HasIndex("PieceId")
                        .HasDatabaseName("ix_montants_piece_id");

                    b.HasDiscriminator().HasValue("MontantDebiteur");
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.PieceCreditrice", b =>
                {
                    b.HasBaseType("TestEntityFrameworkExceptions.Models.Piece");

                    b.ToTable("pieces", (string)null);

                    b.HasDiscriminator().HasValue("PieceCreditrice");
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.PieceDebitrice", b =>
                {
                    b.HasBaseType("TestEntityFrameworkExceptions.Models.Piece");

                    b.ToTable("pieces", (string)null);

                    b.HasDiscriminator().HasValue("PieceDebitrice");
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.Avoir", b =>
                {
                    b.HasBaseType("TestEntityFrameworkExceptions.Models.PieceCreditrice");

                    b.HasDiscriminator().HasValue("Avoir");
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.Facture", b =>
                {
                    b.HasBaseType("TestEntityFrameworkExceptions.Models.PieceDebitrice");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("numero");

                    b.HasDiscriminator().HasValue("Facture");
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.Transport", b =>
                {
                    b.HasOne("TestEntityFrameworkExceptions.Models.Prescription", "Prescription")
                        .WithMany("Transport")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_transports_prescriptions_prescription_id");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.MontantCrediteur", b =>
                {
                    b.HasOne("TestEntityFrameworkExceptions.Models.PieceCreditrice", "Piece")
                        .WithMany("Montants")
                        .HasForeignKey("PieceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_montants_pieces_piece_id");

                    b.Navigation("Piece");
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.MontantDebiteur", b =>
                {
                    b.HasOne("TestEntityFrameworkExceptions.Models.PieceDebitrice", "Piece")
                        .WithMany("Montants")
                        .HasForeignKey("PieceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_montants_pieces_piece_id");

                    b.Navigation("Piece");
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.Prescription", b =>
                {
                    b.Navigation("Transport");
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.PieceCreditrice", b =>
                {
                    b.Navigation("Montants");
                });

            modelBuilder.Entity("TestEntityFrameworkExceptions.Models.PieceDebitrice", b =>
                {
                    b.Navigation("Montants");
                });
#pragma warning restore 612, 618
        }
    }
}
