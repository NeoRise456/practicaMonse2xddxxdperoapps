namespace practicaMonse2xddxxd.work.Domain.Model.ValueObjects;

public record MedicalEquipmentId(string Id)
{
    public MedicalEquipmentId() : this(string.Empty) { }
};