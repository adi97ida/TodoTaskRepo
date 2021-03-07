﻿// <auto-generated />
using System;
using DataRepository.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TodosService.Migrations
{
    [DbContext(typeof(TodosDbContext))]
    partial class TodosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DataRepository.Models.Notification", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("DataRepository.Models.SubscribedUsers", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("TodoListId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UserId", "TodoListId");

                    b.HasIndex("TodoListId");

                    b.ToTable("SubscribedUsers");
                });

            modelBuilder.Entity("DataRepository.Models.TodoItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<bool>("Completed")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("CompletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ParentTodoListFK")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserFK")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("DataRepository.Models.TodoList", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CompletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserFK")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TodoLists");
                });

            modelBuilder.Entity("DataRepository.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "f542d1a5-5e0d-48c0-8d21-2a33afa76ad1",
                            CreatedAt = new DateTimeOffset(new DateTime(2021, 3, 5, 4, 16, 59, 288, DateTimeKind.Unspecified).AddTicks(7386), new TimeSpan(0, 0, 0, 0, 0)),
                            Password = "test1",
                            PhoneNo = "12345678",
                            UpdatedAt = new DateTimeOffset(new DateTime(2021, 3, 5, 4, 16, 59, 288, DateTimeKind.Unspecified).AddTicks(7400), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "test1"
                        },
                        new
                        {
                            Id = "0db8035f-f5a2-4fe2-89a2-e918363a0e2c",
                            CreatedAt = new DateTimeOffset(new DateTime(2021, 3, 5, 4, 16, 59, 288, DateTimeKind.Unspecified).AddTicks(8952), new TimeSpan(0, 0, 0, 0, 0)),
                            Password = "test2",
                            PhoneNo = "12345678",
                            UpdatedAt = new DateTimeOffset(new DateTime(2021, 3, 5, 4, 16, 59, 288, DateTimeKind.Unspecified).AddTicks(8954), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "test2"
                        },
                        new
                        {
                            Id = "4ecc4884-3f1b-4340-9e2b-ec5b9de100c7",
                            CreatedAt = new DateTimeOffset(new DateTime(2021, 3, 5, 4, 16, 59, 288, DateTimeKind.Unspecified).AddTicks(8999), new TimeSpan(0, 0, 0, 0, 0)),
                            Password = "test3",
                            PhoneNo = "12345678",
                            UpdatedAt = new DateTimeOffset(new DateTime(2021, 3, 5, 4, 16, 59, 288, DateTimeKind.Unspecified).AddTicks(9001), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "test3"
                        });
                });

            modelBuilder.Entity("DataRepository.Models.SubscribedUsers", b =>
                {
                    b.HasOne("DataRepository.Models.TodoList", "TodoList")
                        .WithMany("SubscribedUsers")
                        .HasForeignKey("TodoListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataRepository.Models.User", "User")
                        .WithMany("SubscribedLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
