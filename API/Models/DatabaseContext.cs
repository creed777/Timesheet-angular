using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.SqlServer.Types;

namespace API.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ClientModel> Client { get; set; } = default!;
        public DbSet<ClientStatusModel> ClientStatus { get; set; } = default!;
        public DbSet<ProjectModel> Project { get; set; } = default!;
        public DbSet<ProjectStatusModel> ProjectStatus { get; set; } = default!;
        public DbSet<ResourceModel> Resource { get; set; } = default!;
        public DbSet<ResourceTypeModel> ResourceTypes { get; set; } = default!;
        public DbSet<ResourceStatusModel> ResourceStatus { get; set; } = default!;
        public DbSet<TaskModel> Task { get; set; } = default!;
        public DbSet<TaskStatusModel> TaskStatus { get; set; } = default!;
        public DbSet<TaskTimeModel> TaskTime { get; set; } = default!;

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
            modelBuilder.Entity<TaskTimeModel>()
                .Property(x => x.Time)
                .HasPrecision(7, 4);
            modelBuilder.Entity<ResourceTypeModel>()
                .Property(x => x.Cost)
                .HasPrecision(7, 4);

            //modelBuilder.Entity<ProjectModel>()
            //    .HasMany(s => s.Task);
            //modelBuilder.Entity<ProjectModel>()
            //    .HasOne(p => p.ProjectStatus);
            //modelBuilder.Entity<ProjectModel>()
            //    .HasMany(p => p.Resource);
            //modelBuilder.Entity<ProjectModel>()
            //    .HasOne(p => p.Client);

            //modelBuilder.Entity<ClientModel>()
            //    .HasOne(x => x.ClientStatus);

            //modelBuilder.Entity<ResourceModel>()
            //    .HasOne(s => s.ResourceStatus);
            //modelBuilder.Entity<ResourceModel>()
            //    .HasOne(s => s.ResourceType);

            //modelBuilder.Entity<TaskModel>()
            //    .HasMany(s => s.TaskTime);
            //modelBuilder.Entity<TaskModel>()
            //    .HasMany(s => s.Resource);
            //modelBuilder.Entity<TaskModel>()
            //    .HasOne(s => s.TaskStatus);
           // modelBuilder.Entity<TaskModel>()
                //.Property(e => e.Level)
                //.HasColumnName("Level");
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

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), configuration => { configuration.UseHierarchyId(); });

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
