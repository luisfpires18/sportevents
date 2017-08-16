using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SE.Repository.Context;
using SE.Domain.Entities.Enum;

namespace SE.Repository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SE.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AthleteType");

                    b.Property<Guid>("CompetitionID");

                    b.Property<string>("Description");

                    b.Property<int>("Gender");

                    b.Property<int>("MaxAge");

                    b.Property<int>("MinAge");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfWinners");

                    b.Property<string>("Responsible");

                    b.HasKey("CategoryID");

                    b.HasIndex("CompetitionID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("SE.Domain.Entities.Competition", b =>
                {
                    b.Property<Guid>("CompetitionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<float>("Distance");

                    b.Property<Guid>("EventID");

                    b.Property<string>("Name");

                    b.Property<string>("Responsible");

                    b.HasKey("CompetitionID");

                    b.HasIndex("EventID");

                    b.ToTable("Competition");
                });

            modelBuilder.Entity("SE.Domain.Entities.Enrollment", b =>
                {
                    b.Property<Guid>("EnrollmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryID");

                    b.Property<string>("Notes");

                    b.Property<Guid>("PersonID");

                    b.Property<string>("RegistrationBy");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<int>("Size");

                    b.Property<bool>("Status");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("PersonID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("SE.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("EventID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("FilePath");

                    b.Property<string>("ImagePath");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Local");

                    b.Property<string>("Name");

                    b.Property<string>("Responsible");

                    b.Property<Guid>("SportID");

                    b.Property<string>("Website");

                    b.HasKey("EventID");

                    b.HasIndex("SportID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("SE.Domain.Entities.Extra", b =>
                {
                    b.Property<Guid>("ExtraID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid>("EventID");

                    b.Property<string>("Name");

                    b.Property<float>("Price");

                    b.Property<string>("Responsible");

                    b.HasKey("ExtraID");

                    b.HasIndex("EventID");

                    b.ToTable("Extra");
                });

            modelBuilder.Entity("SE.Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("PaymentID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EnrollmentID");

                    b.Property<Guid>("ExtraID");

                    b.HasKey("PaymentID");

                    b.HasIndex("EnrollmentID");

                    b.HasIndex("ExtraID");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("SE.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("PersonID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("City");

                    b.Property<string>("Contact");

                    b.Property<string>("Email");

                    b.Property<string>("Gender");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Nacionality");

                    b.Property<string>("Name");

                    b.Property<Guid>("TeamID");

                    b.HasKey("PersonID");

                    b.HasIndex("TeamID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("SE.Domain.Entities.Request", b =>
                {
                    b.Property<Guid>("RequestID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("PersonID");

                    b.Property<DateTime>("RequestDate");

                    b.Property<string>("RequestType");

                    b.Property<string>("Subject");

                    b.HasKey("RequestID");

                    b.HasIndex("PersonID");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("SE.Domain.Entities.Result", b =>
                {
                    b.Property<Guid>("ResultID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<Guid>("PersonID");

                    b.Property<string>("Responsible");

                    b.HasKey("ResultID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("PersonID");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("SE.Domain.Entities.Sport", b =>
                {
                    b.Property<Guid>("SportID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Responsible");

                    b.HasKey("SportID");

                    b.HasIndex("Name");

                    b.ToTable("Sport");
                });

            modelBuilder.Entity("SE.Domain.Entities.Team", b =>
                {
                    b.Property<Guid>("TeamID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("TeamID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("SE.Domain.Entities.Category", b =>
                {
                    b.HasOne("SE.Domain.Entities.Competition", "Competition")
                        .WithMany("Categories")
                        .HasForeignKey("CompetitionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SE.Domain.Entities.Competition", b =>
                {
                    b.HasOne("SE.Domain.Entities.Event", "Event")
                        .WithMany("Competitions")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SE.Domain.Entities.Enrollment", b =>
                {
                    b.HasOne("SE.Domain.Entities.Category", "Category")
                        .WithMany("Enrollments")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SE.Domain.Entities.Person", "Person")
                        .WithMany("Enrollments")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SE.Domain.Entities.Event", b =>
                {
                    b.HasOne("SE.Domain.Entities.Sport", "Sport")
                        .WithMany("Events")
                        .HasForeignKey("SportID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SE.Domain.Entities.Extra", b =>
                {
                    b.HasOne("SE.Domain.Entities.Event", "Event")
                        .WithMany("Extras")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SE.Domain.Entities.Payment", b =>
                {
                    b.HasOne("SE.Domain.Entities.Enrollment", "Enrollment")
                        .WithMany("Payments")
                        .HasForeignKey("EnrollmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SE.Domain.Entities.Extra", "Extra")
                        .WithMany("Payments")
                        .HasForeignKey("ExtraID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SE.Domain.Entities.Person", b =>
                {
                    b.HasOne("SE.Domain.Entities.Team", "Team")
                        .WithMany("Persons")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SE.Domain.Entities.Request", b =>
                {
                    b.HasOne("SE.Domain.Entities.Person", "Person")
                        .WithMany("Requests")
                        .HasForeignKey("PersonID");
                });

            modelBuilder.Entity("SE.Domain.Entities.Result", b =>
                {
                    b.HasOne("SE.Domain.Entities.Category", "Category")
                        .WithMany("Results")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SE.Domain.Entities.Person", "Person")
                        .WithMany("Results")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
