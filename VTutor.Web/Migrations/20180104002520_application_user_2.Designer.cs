﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using VTutor.Model;

namespace VTutor.Web.Migrations
{
    [DbContext(typeof(VTutorContext))]
    [Migration("20180104002520_application_user_2")]
    partial class application_user_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VTutor.Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("VTutor.Model.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("StartTime");

                    b.Property<Guid?>("StudentId");

                    b.Property<Guid?>("TutorId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TutorId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("VTutor.Model.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("VTutor.Model.ScheduleBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("ScheduleBlocks");
                });

            modelBuilder.Entity("VTutor.Model.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("VTutor.Model.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<Guid?>("SubjectGradeId");

                    b.Property<Guid?>("TutorId");

                    b.HasKey("Id");

                    b.HasIndex("SubjectGradeId");

                    b.HasIndex("TutorId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("VTutor.Model.Tutor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("VTutor.Model.TutorSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("TutorId");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.ToTable("TutorSchedules");
                });

            modelBuilder.Entity("VTutor.Model.Appointment", b =>
                {
                    b.HasOne("VTutor.Model.Student", "Student")
                        .WithMany("Appointments")
                        .HasForeignKey("StudentId");

                    b.HasOne("VTutor.Model.Tutor", "Tutor")
                        .WithMany("Appointments")
                        .HasForeignKey("TutorId");
                });

            modelBuilder.Entity("VTutor.Model.Subject", b =>
                {
                    b.HasOne("VTutor.Model.Grade", "SubjectGrade")
                        .WithMany()
                        .HasForeignKey("SubjectGradeId");

                    b.HasOne("VTutor.Model.Tutor")
                        .WithMany("Subjects")
                        .HasForeignKey("TutorId");
                });

            modelBuilder.Entity("VTutor.Model.TutorSchedule", b =>
                {
                    b.HasOne("VTutor.Model.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId");
                });
#pragma warning restore 612, 618
        }
    }
}
