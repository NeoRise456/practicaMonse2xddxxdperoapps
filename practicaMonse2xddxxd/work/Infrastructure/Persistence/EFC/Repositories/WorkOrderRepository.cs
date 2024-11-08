using Microsoft.EntityFrameworkCore;
using practicaMonse2xddxxd.Shared.Infrastructure.Persistence.EFC.Configuration;
using practicaMonse2xddxxd.Shared.Infrastructure.Persistence.EFC.Repositories;
using practicaMonse2xddxxd.work.Domain.Model.Aggregates;
using practicaMonse2xddxxd.work.Domain.Model.ValueObjects;
using practicaMonse2xddxxd.work.Domain.Repositories;

namespace practicaMonse2xddxxd.work.Infrastructure.Persistence.EFC.Repositories;

public class WorkOrderRepository(AppDbContext context) : BaseRepository<WorkOrder>(context),
    IWorkOrderRepository
{
    public async Task<WorkOrder?> FindWorkOrderByIdAsync(int workOrderId) => 
        await Context.Set<WorkOrder>()
            .FirstOrDefaultAsync(w => w.Id == workOrderId);

    
    //TODO: correct the validation
    public async Task<bool> WorkOrderExistsByMedicalEquipmentIdAndStaffIdAndPlannedAtAsync(
        MedicalEquipmentId medicalEquipmentId,
        StaffId staffId,
        DateTimeOffset? plannedAt) => 
        await Context.Set<WorkOrder>()
            .AnyAsync(w => w.MedicalEquipmentId == medicalEquipmentId &&
                           w.StaffId == staffId &&
                           w.PlannedAt == plannedAt);
    
}