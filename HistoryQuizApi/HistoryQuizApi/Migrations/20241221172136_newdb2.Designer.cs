﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HistoryQuizApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241221172136_newdb2")]
    partial class newdb2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HistoryQuizApi.Models.Data.ClassHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("classHistory");
                });

            modelBuilder.Entity("HistoryQuizApi.Models.Data.Enrollment", b =>
                {
                    b.Property<Guid>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("ClassHistoryId");

                    b.HasIndex("UserId");

                    b.ToTable("enrollments");
                });

            modelBuilder.Entity("HistoryQuizApi.Models.Data.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LessonId")
                        .IsUnique();

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("HistoryQuizApi.Models.Data.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassHistoryId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("HistoryQuizApi.Models.Data.LessonCompletion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("LessonCompletions");
                });

            modelBuilder.Entity("HistoryQuizApi.Models.Data.Submission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Grade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("IsGraded")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("LessonId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("HistoryQuizApi.Models.Data.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HistoryQuizApi.Models.Data.Enrollment", b =>
                {
                    b.HasOne("HistoryQuizApi.Models.Data.ClassHistory", "Class")
                        .WithMany()
                        .HasForeignKey("ClassHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HistoryQuizApi.Models.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HistoryQuizApi.Models.Data.Exam", b =>
                {
                    b.HasOne("HistoryQuizApi.Models.Data.Lesson", "Lesson")
                        .WithOne("Exam")
                        .HasForeignKey("HistoryQuizApi.Models.Data.Exam", "LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("HistoryQuizApi.Models.Data.Lesson", b =>
                {
                    b.HasOne("HistoryQuizApi.Models.Data.ClassHistory", "ClassHistory")
                        .WithMany("Lessons")
                        .HasForeignKey("ClassHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassHistory");
                });

            modelBuilder.Entity("HistoryQuizApi.Models.Data.LessonCompletion", b =>
                {
                    b.HasOne("HistoryQuizApi.Models.Data.Lesson", null)
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HistoryQuizApi.Models.Data.Submission", b =>
                {
                    b.HasOne("HistoryQuizApi.Models.Data.Exam", "Exam")
                        .WithMany("Submissions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HistoryQuizApi.Models.Data.Lesson", null)
                        .WithMany("Submissions")
                        .HasForeignKey("LessonId");

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("HistoryQuizApi.Models.Data.ClassHistory", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("HistoryQuizApi.Models.Data.Exam", b =>
                {
                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("HistoryQuizApi.Models.Data.Lesson", b =>
                {
                    b.Navigation("Exam")
                        .IsRequired();

                    b.Navigation("Submissions");
                });
#pragma warning restore 612, 618
        }
    }
}
