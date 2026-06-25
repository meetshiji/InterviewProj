using InterviewProj.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace InterviewProj.Data
{
    public class OnlineShopDbContext:DbContext
    {
    public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
        : base(options)
    {
    }

    public DbSet<Orders> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Orders>()
            .ToTable("Orders");

        modelBuilder.Entity<Orders>()
            .HasKey(x => x.OrderId);
    }

}
}
