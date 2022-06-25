﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ClientModel> Client { get; set; } = default!;
        public DbSet<ClientStatusModel> ClientStatus { get; set; } = default!;
        public DbSet<ProjectModel> Project { get; set; } = default!;
        public DbSet<ProjectStatusModel> ProjectStatus { get; set; } = default!;
        public DbSet<ResourceModel> ProjectResources { get; set; } = default!;
        public DbSet<ResourceTypeModel> ResourceTypes { get; set; } = default!;
        public DbSet<ResourceStatusModel> ResourceStatus { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectModel>()
                .Property(x => x.EstimatedTotalHours)
                .HasPrecision(7, 4);
            modelBuilder.Entity<ProjectModel>()
                .Property(x => x.ActualTotalHours)
                .HasPrecision(7, 4);
            modelBuilder.Entity<ProjectModel>()
                .Property(x => x.ActualLaborCost)
                .HasPrecision(7, 4);
            modelBuilder.Entity<ProjectModel>()
                .Property(x => x.EstimatedLaborCost)
                .HasPrecision(7, 4);
            modelBuilder.Entity<ProjectModel>()
                .Property(x => x.ActualMaterialCost)
                .HasPrecision(7, 4);
            modelBuilder.Entity<ProjectModel>()
                .Property(x => x.EstimatedMaterialCost)
                .HasPrecision(7, 4);

            modelBuilder.Entity<ProjectModel>()
                .HasOne(p => p.ProjectStatus);
            modelBuilder.Entity<ClientModel>()
                .HasOne(x => x.ClientStatus);
            modelBuilder.Entity<ResourceModel>()
                .HasOne(s => s.ResourceStatus);
            modelBuilder.Entity<ResourceModel>()
                .HasOne(s => s.ResourceType);
        }


        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }
    }

    public class TimesheetContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
