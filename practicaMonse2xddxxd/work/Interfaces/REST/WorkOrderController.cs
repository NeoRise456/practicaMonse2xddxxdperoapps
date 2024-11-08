using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using practicaMonse2xddxxd.work.Domain.Services;
using practicaMonse2xddxxd.work.Interfaces.REST.Resources;
using practicaMonse2xddxxd.work.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace practicaMonse2xddxxd.work.Interfaces.REST;

[ApiController]
[Route("api/v1/medical-equipments")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Work Orders")]
public class WorkOrderController(
    IWorkOrderCommandService workOrderCommandService
    ) : ControllerBase
{
    [HttpPost("{medicalEquipmentId}/work-orders")]
    [SwaggerOperation(
        Summary = "Create a new work order",
        Description = "Create a new Work order in the system",
        OperationId = "CreateWorkOrder")]
    [SwaggerResponse(StatusCodes.Status201Created, "The work order was created", typeof(WorkOrderResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is invalid")]
    public async Task<IActionResult> CreateWorkOrder(
        [FromRoute] string medicalEquipmentId,
        [FromBody] CreateWorkOrderResource resource
        )
    {
        var createWorkOrderCommand = CreateWorkOrderCommandFromResourceAssembler
            .toCommandFromResource(resource, medicalEquipmentId);
        var workOrder = await workOrderCommandService.Handle(createWorkOrderCommand);
        
        if (workOrder is null) return BadRequest();
        
        var workOrderResource = WorkOrderResourceFromEntityAssembler
            .toResourceFromEntity(workOrder);
        
        return Created(
            $"api/v1/medical-equipments/{medicalEquipmentId}/work-orders/{workOrderResource.Id}",
            workOrderResource
        );
        
    }
}