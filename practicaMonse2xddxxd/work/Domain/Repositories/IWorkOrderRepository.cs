using practicaMonse2xddxxd.Shared.Domain.Repostiroies;
using practicaMonse2xddxxd.work.Domain.Model.Aggregates;
using practicaMonse2xddxxd.work.Domain.Model.ValueObjects;

namespace practicaMonse2xddxxd.work.Domain.Repositories;

/// <summary>
/// Interface for the <see cref="WorkOrder"/> repository
/// </summary>
public interface IWorkOrderRepository :IBaseRepository<WorkOrder>
{
    /// <summary>
    /// Find a <see cref="WorkOrder"/> by its id
    /// </summary>
    /// <param name="workOrderId">
    /// The id of the <see cref="WorkOrder"/> to find
    /// </param>
    /// <returns>
    /// The <see cref="WorkOrder"/> if found, otherwise null
    /// </returns>
    Task<WorkOrder?> FindWorkOrderByIdAsync(int workOrderId);
    
    
    /// <summary>
    /// Check if a <see cref="WorkOrder"/> exists by the medical equipment id, staff id and planned date
    /// </summary>
    /// <param name="medicalEquipmentId">
    /// The id of the medical equipment
    /// </param>
    /// <param name="staffId">
    /// The id of the staff
    /// </param>
    /// <param name="plannedAt">
    /// The planned date
    /// </param>
    /// <returns>
    /// True if the <see cref="WorkOrder"/> exists, otherwise false
    /// </returns>
    Task<bool> WorkOrderExistsByMedicalEquipmentIdAndStaffIdAndPlannedAtAsync(
        MedicalEquipmentId medicalEquipmentId,
        StaffId staffId,
        DateTimeOffset? plannedAt
    );

}