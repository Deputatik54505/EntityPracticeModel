﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230710175313_test0")]
    partial class test0
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AnimalZookeeper", b =>
                {
                    b.Property<int>("AnimalsId")
                        .HasColumnType("integer");

                    b.Property<int>("ZookeepersId")
                        .HasColumnType("integer");

                    b.HasKey("AnimalsId", "ZookeepersId");

                    b.HasIndex("ZookeepersId");

                    b.ToTable("AnimalZookeeper");
                });

            modelBuilder.Entity("Model.models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AnimalName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CellId")
                        .HasColumnType("integer");

                    b.Property<int>("MainMealId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CellId");

                    b.HasIndex("MainMealId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Model.models.Cell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cells");
                });

            modelBuilder.Entity("Model.models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("Model.models.Zookeeper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Zookeepers");
                });

            modelBuilder.Entity("AnimalZookeeper", b =>
                {
                    b.HasOne("Model.models.Animal", null)
                        .WithMany()
                        .HasForeignKey("AnimalsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.models.Zookeeper", null)
                        .WithMany()
                        .HasForeignKey("ZookeepersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.models.Animal", b =>
                {
                    b.HasOne("Model.models.Cell", "Cell")
                        .WithMany("Animals")
                        .HasForeignKey("CellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.models.Meal", "MainMeal")
                        .WithMany("Animals")
                        .HasForeignKey("MainMealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cell");

                    b.Navigation("MainMeal");
                });

            modelBuilder.Entity("Model.models.Cell", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("Model.models.Meal", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}