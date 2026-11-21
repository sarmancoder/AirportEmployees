using System;
using System.Collections.Generic;
using AirportEmployees.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportEmployees.Data;

public partial class AirportContext : DbContext
{
    public AirportContext(DbContextOptions<AirportContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee", tb => tb.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0"));

            entity.HasIndex(e => e.Username, "user_unq").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Birthdate)
                .HasColumnType("date")
                .HasColumnName("birthdate");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Department)
                .HasColumnType("enum('Marketing','Buchhaltung','Management','Logistik','Flugfeld')")
                .HasColumnName("department");
            entity.Property(e => e.Emailaddress)
                .HasMaxLength(120)
                .HasColumnName("emailaddress");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Salary)
                .HasPrecision(8)
                .HasColumnName("salary");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("sex");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .HasColumnName("street");
            entity.Property(e => e.Telephoneno)
                .HasMaxLength(30)
                .HasColumnName("telephoneno");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
            entity.Property(e => e.Zip).HasColumnName("zip");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
