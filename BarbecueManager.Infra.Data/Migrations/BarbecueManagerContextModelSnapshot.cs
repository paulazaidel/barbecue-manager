﻿// <auto-generated />
using System;
using BarbecueManager.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BarbecueManager.Infra.Data.Migrations
{
    [DbContext(typeof(BarbecueManagerContext))]
    partial class BarbecueManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("BarbecueManager.Domain.Entities.Barbecue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ContributionAmountWithDrinks")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ContributionAmountWithoutDrinks")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Barbecues", (string)null);
                });

            modelBuilder.Entity("BarbecueManager.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ContributionAmount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Persons", (string)null);
                });

            modelBuilder.Entity("BarbecuePerson", b =>
                {
                    b.Property<int>("BarbecuesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BarbecuesId", "PersonsId");

                    b.HasIndex("PersonsId");

                    b.ToTable("PersonBarbecues", (string)null);
                });

            modelBuilder.Entity("BarbecuePerson", b =>
                {
                    b.HasOne("BarbecueManager.Domain.Entities.Barbecue", null)
                        .WithMany()
                        .HasForeignKey("BarbecuesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarbecueManager.Domain.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
