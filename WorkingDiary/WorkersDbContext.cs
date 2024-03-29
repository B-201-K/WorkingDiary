using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorkingDiary;

public partial class WorkersDbContext : DbContext
{
    public WorkersDbContext()
    {
    }

    public WorkersDbContext(DbContextOptions<WorkersDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Worker> Workers { get; set; }

    public virtual DbSet<WorkerTask> WorkerTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\cs10dotnet6;Database=WorkersDb; Trusted_Connection=true; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.WorkerId).HasName("id_key");

            entity.ToTable("worker");

            entity.Property(e => e.WorkerId)
                .ValueGeneratedNever()
                .HasColumnName("worker_id");
            entity.Property(e => e.WorkerDepartment)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("worker_department");
            entity.Property(e => e.WorkerLastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("worker_lastname");
            entity.Property(e => e.WorkerLogin)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("worker_login");
            entity.Property(e => e.WorkerName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("worker_name");
            entity.Property(e => e.WorkerPassword)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("worker_password");
            entity.Property(e => e.WorkerSurname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("worker_surname");
        });

        modelBuilder.Entity<WorkerTask>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("worker_tasks_pkey");

            entity.ToTable("worker_tasks");

            entity.Property(e => e.TaskId)
                .ValueGeneratedNever()
                .HasColumnName("task_id");
            entity.Property(e => e.TaskCreateDate)
                .HasColumnType("date")
                .HasColumnName("task_create_date");
            entity.Property(e => e.TaskDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("task_description");
            entity.Property(e => e.TaskEndDate)
                .HasColumnType("date")
                .HasColumnName("task_end_date");
            entity.Property(e => e.TaskName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("task_name");
            entity.Property(e => e.TaskOwnerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("task_owner_name");
            entity.Property(e => e.TaskOwnerSurname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("task_owner_surname");
            entity.Property(e => e.TaskStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("task_status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
