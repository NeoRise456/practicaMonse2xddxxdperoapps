using practicaMonse2xddxxd.work.Domain.Model.Aggregates;
using practicaMonse2xddxxd.work.Interfaces.REST.Resources;

namespace practicaMonse2xddxxd.work.Interfaces.REST.Transform;

public class WorkOrderResourceFromEntityAssembler
{
    public static WorkOrderResource toResourceFromEntity(
        WorkOrder entity
        )
    {
        return new WorkOrderResource(
            entity.Id,
            entity.MedicalEquipmentId.Id,
            entity.StaffId.Id,
            entity.HealthInstitutionId.Id,
            entity.Type.ToString(),
            entity.Description,
            entity.Priority,
            entity.Amount,
            entity.PlannedAt
            );
    }
}