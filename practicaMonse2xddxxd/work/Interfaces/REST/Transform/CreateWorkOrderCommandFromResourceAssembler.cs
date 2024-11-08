using practicaMonse2xddxxd.work.Domain.Model.Commands;
using practicaMonse2xddxxd.work.Interfaces.REST.Resources;

namespace practicaMonse2xddxxd.work.Interfaces.REST.Transform;

public class CreateWorkOrderCommandFromResourceAssembler
{
    public static CreateWorkOrderCommand toCommandFromResource(
        CreateWorkOrderResource resource, 
        string medicalEquipmentId
        )
    {
        return new CreateWorkOrderCommand(
            medicalEquipmentId,
            resource.StaffId, 
            resource.HealthInstitutionId, 
            resource.WorkType, 
            resource.Description, 
            resource.Priority, 
            resource.Amount, 
            resource.PlannedAt
            );
    }
}