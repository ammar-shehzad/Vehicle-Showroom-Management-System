using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Vehicle_Showroom_Management_System.Models;

public class Vehicle_Showroom_Management_System_Context : DbContext
{
    public Vehicle_Showroom_Management_System_Context(DbContextOptions<Vehicle_Showroom_Management_System_Context> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("conn");
        }
    }

    public DbSet<admin_register> admin_Registers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<Car_Brand> car_Brands { get; set; }
    public DbSet<Vehicle_registration> vehicle_Registrations { get; set; }
    public DbSet<branch> Branches { get; set; }

    //this is for the website
    public DbSet<Customers> customers { get; set; }




}
