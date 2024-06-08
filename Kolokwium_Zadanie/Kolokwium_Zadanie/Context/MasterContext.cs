using Kolokwium_Zadanie.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_Zadanie.Context;

public class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>()
            .HasOne(s => s.Client)
            .WithMany()
            .HasForeignKey(s => s.IdClient);

        modelBuilder.Entity<Sale>()
            .HasOne(s => s.Subscription)
            .WithMany()
            .HasForeignKey(s => s.IdSubscription);

        modelBuilder.Entity<Discount>()
            .HasOne(d => d.Subscription)
            .WithMany()
            .HasForeignKey(d => d.IdSubscription);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Client)
            .WithMany()
            .HasForeignKey(p => p.IdClient);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Subscription)
            .WithMany()
            .HasForeignKey(p => p.IdSubscription);
    } 
}