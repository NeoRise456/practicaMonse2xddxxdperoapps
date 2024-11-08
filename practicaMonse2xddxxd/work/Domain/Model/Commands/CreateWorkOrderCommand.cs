namespace practicaMonse2xddxxd.work.Domain.Model.Commands;

public record CreateWorkOrderCommand(
    string MedicalEquipmentId,
    long StaffId,
    long HealthInstitutionId,
    string WorkType,
    string Description,
    int Priority,
    float Amount,
    DateTimeOffset? PlannedAt
    );