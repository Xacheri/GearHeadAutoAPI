using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GearHeadAutoAPI.Data;

public partial class GearHeadAutoContext : DbContext
{
    public GearHeadAutoContext()
    {
    }

    public GearHeadAutoContext(DbContextOptions<GearHeadAutoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminCredential> AdminCredentials { get; set; }

    public virtual DbSet<AutoInformation> AutoInformations { get; set; }

    public virtual DbSet<Credential> Credentials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=fa23-melton.ckwia8qkgyyj.us-east-1.rds.amazonaws.com;Initial Catalog=dw0899439;Persist Security Info=True;User ID=dw0899439;Password=0899439;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminCredential>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.Property(e => e.Username)
                .HasMaxLength(20);
            entity.Property(e => e.AdminPassword)
                .HasMaxLength(20);
            entity.Property(e => e.Password)
                .HasMaxLength(20);
        });


        modelBuilder.Entity<AutoInformation>(entity =>
        {
            entity.HasKey(e => e.AutoId);

            entity.ToTable("AutoInformation");

            entity.Property(e => e.AutoId)
                .HasMaxLength(20)
                .HasColumnName("Auto_ID");
            entity.Property(e => e.Color)
                .HasMaxLength(10);
            entity.Property(e => e.Condition)
                .HasMaxLength(10);
            entity.Property(e => e.Image)
                .HasMaxLength(25);
            entity.Property(e => e.Make)
                .HasMaxLength(20);
            entity.Property(e => e.Model)
                .HasMaxLength(20);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Type)
                .HasMaxLength(10);
        });

        modelBuilder.Entity<Credential>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.Property(e => e.Username)
                .HasMaxLength(20);
            entity.Property(e => e.Password)
                .HasMaxLength(20);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
