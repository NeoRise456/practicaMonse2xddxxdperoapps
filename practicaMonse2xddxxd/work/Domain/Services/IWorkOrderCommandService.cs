using practicaMonse2xddxxd.work.Domain.Model.Aggregates;
using practicaMonse2xddxxd.work.Domain.Model.Commands;

namespace practicaMonse2xddxxd.work.Domain.Services;

public interface IWorkOrderCommandService
{
    Task<WorkOrder?> Handle(CreateWorkOrderCommand command);
}