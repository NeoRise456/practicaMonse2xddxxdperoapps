using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using practicaMonse2xddxxd.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using practicaMonse2xddxxd.work.Domain.Model.Aggregates;
using practicaMonse2xddxxd.work.Domain.Model.ValueObjects;

namespace practicaMonse2xddxxd.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    
    public DbSet<WorkOrder> WorkOrders { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        
        var medicalEquipmentIdConverter = new ValueConverter<MedicalEquipmentId, string>(
            v => v.Id,
            v => new MedicalEquipmentId(v));

        var staffIdConverter = new ValueConverter<StaffId, long>(
            v => v.Id,
            v => new StaffId(v));

        var healthInstitutionIdConverter = new ValueConverter<HealthInstitutionId, long>(
            v => v.Id,
            v => new HealthInstitutionId(v));
        
        var workTypeConverter = new ValueConverter<EWorkTypes, string>(
            v => v.ToString(),
            v => (EWorkTypes)Enum.Parse(typeof(EWorkTypes), v));
        
        builder.Entity<WorkOrder>().HasKey(w => w.Id);
        builder.Entity<WorkOrder>().Property(w => w.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<WorkOrder>().Property(w => w.MedicalEquipmentId)
            .IsRequired()
            .HasConversion(medicalEquipmentIdConverter);
        builder.Entity<WorkOrder>().Property(w => w.StaffId)
            .IsRequired()
            .HasConversion(staffIdConverter);
        builder.Entity<WorkOrder>().Property(w => w.HealthInstitutionId)
            .IsRequired()
            .HasConversion(healthInstitutionIdConverter);
        builder.Entity<WorkOrder>().Property(w => w.Type)
            .IsRequired()
            .HasConversion(workTypeConverter);
        builder.Entity<WorkOrder>().Property(w => w.Type).IsRequired();
        builder.Entity<WorkOrder>().Property(w => w.Description).HasMaxLength(240);
        builder.Entity<WorkOrder>().Property(w => w.Priority).IsRequired();
        builder.Entity<WorkOrder>().Property(w => w.Amount).IsRequired();
        builder.Entity<WorkOrder>().Property(w => w.PlannedAt).IsRequired();
        
        
        
        
        builder.UseSnakeCaseNamingConvention();
    }

}