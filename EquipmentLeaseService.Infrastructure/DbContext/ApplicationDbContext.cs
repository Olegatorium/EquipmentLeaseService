using EquipmentLeaseService.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<ProductionFacility> ProductionFacilities { get; set; }
    public DbSet<ProcessEquipmentType> ProcessEquipmentTypes { get; set; }
    public DbSet<EquipmentPlacementContract> EquipmentPlacementContracts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EquipmentPlacementContract>()
            .HasOne(e => e.ProductionFacility)
            .WithMany(p => p.EquipmentPlacementContracts)
            .HasForeignKey(e => e.ProductionFacilityCode)
            .OnDelete(DeleteBehavior.Restrict);  // Можно задать тип каскадного удаления

        modelBuilder.Entity<EquipmentPlacementContract>()
            .HasOne(e => e.ProcessEquipmentType)
            .WithMany(p => p.EquipmentPlacementContracts)
            .HasForeignKey(e => e.ProcessEquipmentTypeCode)
            .OnDelete(DeleteBehavior.Restrict);  // Можно задать тип каскадного удаления


        // seedind data for ProductionFacility and ProcessEquipmentType:

        modelBuilder.Entity<ProductionFacility>().HasData(
           new ProductionFacility
           {
               Code = Guid.NewGuid(),
               Name = "Factory A - Main Building",
               StandardAreaForEquipment = 1500m  
           },
           new ProductionFacility
           {
               Code = Guid.NewGuid(),
               Name = "Factory B - Assembly Line",
               StandardAreaForEquipment = 2500m  
           },
           new ProductionFacility
           {
               Code = Guid.NewGuid(),
               Name = "Factory C - Packaging Area",
               StandardAreaForEquipment = 1800m  
           }
        );

        modelBuilder.Entity<ProcessEquipmentType>().HasData(
            new ProcessEquipmentType
            {
                Code = Guid.NewGuid(),
                Name = "CNC Machine",
                Area = 120m  
            },
            new ProcessEquipmentType
            {
                Code = Guid.NewGuid(),
                Name = "Welding Robot",
                Area = 80m  
            },
            new ProcessEquipmentType
            {
                Code = Guid.NewGuid(),
                Name = "Conveyor Belt",
                Area = 150m  
            },
            new ProcessEquipmentType
            {
                Code = Guid.NewGuid(),
                Name = "Packaging Machine",
                Area = 100m  
            }
        );
    }
}
