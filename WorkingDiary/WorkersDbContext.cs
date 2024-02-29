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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host = localhost; Port = 5432; Database=WorkersDB; Username=postgres; Password=14863");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.WorkerId).HasName("id_key");

            entity.ToTable("worker");

            entity.Property(e => e.WorkerId).HasColumnName("worker_id");
            entity.Property(e => e.WorkerDepartment)
                .HasMaxLength(20)
                .HasColumnName("worker_department");
            entity.Property(e => e.WorkerLastname)
                .HasMaxLength(50)
                .HasColumnName("worker_lastname");
            entity.Property(e => e.WorkerLogin)
                .HasMaxLength(30)
                .HasColumnName("worker_login");
            entity.Property(e => e.WorkerName)
                .HasMaxLength(30)
                .HasColumnName("worker_name");
            entity.Property(e => e.WorkerPassword)
                .HasMaxLength(30)
                .HasColumnName("worker_password");
            entity.Property(e => e.WorkerSurname)
                .HasMaxLength(50)
                .HasColumnName("worker_surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
