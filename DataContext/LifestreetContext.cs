using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class LifestreetContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Position> Positions { get; set; }

    public string DbPath { get; }

    public LifestreetContext() 
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("server=localhost;Integrated Security=SSPI;database=lifestreet;persistsecurityinfo=True;TrustServerCertificate=Yes;");
}

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
    public string Position { get; set; }
}

public class Position
{
    [Key]
    public int Id { get; set; }
    public string JobTitle { get; set; }
    public int SalaryBonus { get; set; }
}