using practicaMonse2xddxxd.Shared.Domain.Repostiroies;
using practicaMonse2xddxxd.work.Domain.Model.Aggregates;
using practicaMonse2xddxxd.work.Domain.Model.Commands;
using practicaMonse2xddxxd.work.Domain.Model.ValueObjects;
using practicaMonse2xddxxd.work.Domain.Repositories;
using practicaMonse2xddxxd.work.Domain.Services;

namespace practicaMonse2xddxxd.work.Application.Internal.CommandServices;

public class WorkOrderCommandService(
    IWorkOrderRepository workOrderRepository,
    IUnitOfWork unitOfWork
    ) : IWorkOrderCommandService
{
    public async Task<WorkOrder?> Handle(CreateWorkOrderCommand command)
    {
        
        if (command.Amount <= 0)
        {
            throw new InvalidOperationException("The amount value should be greater than 0.");
        }
        
        if (command.Priority < 1 || command.Priority > 3)
        {
            throw new InvalidOperationException("The priority value should be between 1 and 3.");
        }
        
        
        if ( await workOrderRepository.WorkOrderExistsByMedicalEquipmentIdAndStaffIdAndPlannedAtAsync(
            new MedicalEquipmentId(command.MedicalEquipmentId),
            new StaffId(command.StaffId),
            command.PlannedAt
        ))
        {
            throw new InvalidOperationException("The work order already exists for the medical equipment, staff and planned date.");
        }
        
        var workOrder = new WorkOrder(command);
        
        await workOrderRepository.AddAsync(workOrder);
        await unitOfWork.CompleteAsync();
        
        return workOrder;
    }
}