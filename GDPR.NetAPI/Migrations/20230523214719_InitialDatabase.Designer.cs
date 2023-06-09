﻿// <auto-generated />
using System;
using GDPR.NetAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GDPR.NetAPI.Migrations
{
    [DbContext(typeof(GdprAgreementContext))]
    [Migration("20230523214719_InitialDatabase")]
    partial class InitialDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GDPR.NetAPI.Models.GdprAgreement", b =>
                {
                    b.Property<string>("identificationCode")
                        .HasColumnType("text");

                    b.Property<DateTime>("agreementDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("countyCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("emailCommunication")
                        .IsRequired()
                        .HasColumnType("boolean");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("gdprAgreement")
                        .HasColumnType("boolean");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("marketingAgreement")
                        .IsRequired()
                        .HasColumnType("boolean");

                    b.Property<bool?>("mobileCommunication")
                        .IsRequired()
                        .HasColumnType("boolean");

                    b.Property<string>("mobilePhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("identificationCode");

                    b.ToTable("Agreements");
                });
#pragma warning restore 612, 618
        }
    }
}
