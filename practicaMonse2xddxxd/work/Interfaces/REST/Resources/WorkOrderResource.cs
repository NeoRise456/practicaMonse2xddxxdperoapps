namespace practicaMonse2xddxxd.work.Interfaces.REST.Resources;

public record WorkOrderResource(
    int Id,
    string MedicalEquipmentId,
    long StaffId,
    long HealthInstitutionId,
    string WorkType,
    string Description,
    int Priority,
    float Amount,
    DateTimeOffset? PlannedAt
    );