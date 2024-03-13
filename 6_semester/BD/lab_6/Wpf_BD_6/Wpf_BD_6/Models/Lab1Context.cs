using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Wpf_BD_6.Models;

public partial class Lab1Context : DbContext
{
    private static Lab1Context _instance;
    public Lab1Context()
    {
    }

    public Lab1Context(DbContextOptions<Lab1Context> options)
        : base(options)
    {
    }

    public Lab1Context GetInstance()
    {
        if (_instance == null)
            _instance = new Lab1Context();
        return _instance;
    }


    public virtual DbSet<AllInformationWorkerView> AllInformationWorkerViews { get; set; }

    public virtual DbSet<Brigade> Brigades { get; set; }

    public virtual DbSet<CompanyDirectorsView> CompanyDirectorsViews { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<FullNameView> FullNameViews { get; set; }

    public virtual DbSet<ShowWorkerInBrigadeAndDepartmentView> ShowWorkerInBrigadeAndDepartmentViews { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    public virtual DbSet<WorkersSpecialitiesView> WorkersSpecialitiesViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-501ABTG;Database=lab_1;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllInformationWorkerView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AllInformationWorkerView");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Brigade>(entity =>
        {
            entity.HasKey(e => e.IdBrigade).HasName("PK_IdBrigade");

            entity.ToTable("Brigade");

            entity.Property(e => e.TypeBrigade)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Brigades)
                .HasForeignKey(d => d.IdDepartment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdDepartment");
        });

        modelBuilder.Entity<CompanyDirectorsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CompanyDirectorsView");

            entity.Property(e => e.BrigadeType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WorkerName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.IdDepartment).HasName("PK_IdDepartment");

            entity.ToTable("Department");

            entity.Property(e => e.DescriptionDepartment)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NameDepartment)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FullNameView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("FullNameView");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ShowWorkerInBrigadeAndDepartmentView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ShowWorkerInBrigadeAndDepartmentView");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameSpeciality)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TypeBrigade)
                .HasMaxLength(20)
                .IsUnicode(false);
        });
        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.IdSpeciality).HasName("PK_IdSpeciality");

            entity.ToTable("Speciality");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NameSpeciality)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SalaryOneRate).HasColumnType("money");
            entity.ToView("Speciality", schema: "WorkersSchema");
            entity.ToTable("Speciality", schema: "WorkersSchema");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.IdWorker).HasName("PK_IdWorker");

            entity.ToTable("Worker");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdBrigadeNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.IdBrigade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdBrigade");

            entity.HasOne(d => d.IdSpecialityNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.IdSpeciality)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdSpeciality");
            entity.ToView("Worker", schema: "WorkersSchema");
            entity.ToTable("Worker", schema: "WorkersSchema");
        });

        modelBuilder.Entity<WorkersSpecialitiesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WorkersSpecialitiesView");

            entity.Property(e => e.SpecialityName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.WorkerName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
