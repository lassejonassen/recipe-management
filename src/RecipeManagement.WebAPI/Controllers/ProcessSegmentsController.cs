using Microsoft.AspNetCore.Mvc;
using RecipeManagement.Application.MaterialDefinitions.Queries;
using RecipeManagement.Application.ProcessSegments.Queries;
using RecipeManagement.WebAPI.Contracts.MaterialDefinitions;
using RecipeManagement.WebAPI.Contracts.ProcessSegments;

namespace RecipeManagement.WebAPI.Controllers;

[Route("api/process-segments")]
public class ProcessSegmentsController : BaseController
{
    [ProducesResponseType(typeof(ProcessSegmentListResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllProcessSegmentsQuery();

        var result = await Mediator.Send(query, cancellationToken);

        if (!result.Any())
        {
            return NoContent();
        }

        var dtos = result.Select(x => new ProcessSegmentResponseDTO
        {
            Id = x.Id,
            CreatedAtUtc = x.CreatedAtUtc,
            UpdatedAtUtc = x.UpdatedAtUtc,
            Name = x.Name,
            StableId = x.StableId,
            State = x.State,
            Version = x.Version,
        });

        var _result = new ProcessSegmentListResponseDTO
        {
            Data = dtos,
        };

        return Ok(_result);
    }

    [ProducesResponseType(typeof(ProcessSegmentResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProcessSegmentByIdQuery(id);

        var result = await Mediator.Send(query, cancellationToken);

        if (result.IsFailure)
        {
            return HandleFailure(result.Error);
        }

        var _result = new ProcessSegmentResponseDTO
        {
            Id = result.Value.Id,
            CreatedAtUtc = result.Value.CreatedAtUtc,
            UpdatedAtUtc = result.Value.UpdatedAtUtc,
            Name = result.Value.Name,
            StableId = result.Value.StableId,
            State = result.Value.State,
            Version = result.Value.Version,
            Parameters = result.Value.Parameters?.Select(p => new ProcessSegmentParameterResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Value = p.Value,
                Description = p.Description,
                DataType = p.DataType,
                CreatedAtUtc = p.CreatedAtUtc,
                UpdatedAtUtc = p.UpdatedAtUtc,
                ProcessSegmentId = result.Value.Id,
                DefaultValue = p.DefaultValue,
                IsReadOnly = p.IsReadOnly
            }).ToList(),
        };

        return Ok(_result);
    }
}
