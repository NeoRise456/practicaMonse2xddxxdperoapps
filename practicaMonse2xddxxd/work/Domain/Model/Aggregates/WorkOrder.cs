using practicaMonse2xddxxd.work.Domain.Model.Commands;
using practicaMonse2xddxxd.work.Domain.Model.ValueObjects;

namespace practicaMonse2xddxxd.work.Domain.Model.Aggregates;

public partial class WorkOrder
{
    public int Id { get; set; }
    
    public MedicalEquipmentId MedicalEquipmentId { get; private set; }
    
    public StaffId StaffId { get; private set; }
    
    public HealthInstitutionId HealthInstitutionId { get; private set; }
    
    public EWorkTypes Type { get; private set; }
    
    public string Description { get; set; }
    
    public int Priority { get; set; }
    
    public float Amount { get; set; }
    
    public DateTimeOffset? PlannedAt { get; set; }

    private WorkOrder() { }
    public WorkOrder(CreateWorkOrderCommand command)
    {
        MedicalEquipmentId = new MedicalEquipmentId(command.MedicalEquipmentId);
        StaffId = new StaffId(command.StaffId);
        HealthInstitutionId = new HealthInstitutionId(command.HealthInstitutionId);
        Type = Enum.Parse<EWorkTypes>(command.WorkType);
        Description = command.Description;
        Priority = command.Priority;
        Amount = command.Amount;
        PlannedAt = command.PlannedAt;
    }
    
    public WorkOrder(
        string medicalEquipmentId,
        long staffId,
        long healthInstitutionId,
        string workType,
        string description,
        int priority,
        float amount,
        DateTimeOffset? plannedAt
        )
    {
        MedicalEquipmentId = new MedicalEquipmentId(medicalEquipmentId);
        StaffId = new StaffId(staffId);
        HealthInstitutionId = new HealthInstitutionId(healthInstitutionId);
        Type = Enum.Parse<EWorkTypes>(workType);
        Description = description;
        Priority = priority;
        Amount = amount;
        PlannedAt = plannedAt;
    }
    
    
    
}