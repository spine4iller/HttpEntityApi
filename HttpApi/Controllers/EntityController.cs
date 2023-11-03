using Api.Infrastructure.Dto;
using Api.Infrastructure.Entities;
using Api.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace HttpApi.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class EntityController : Controller
{
    private readonly IStorageService _searchService;
    private readonly IMapper _mapper;

    public EntityController(IStorageService searchService, IMapper mapper)
    {
        _searchService = searchService;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Post([FromBody] EntityDto entityDto)
    {
        Entity entity = _mapper.Map<Entity>(entityDto);
        _searchService.SaveEntity(entity);

        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces("application/json")]
    public IActionResult Get(Guid entityId)
    {
        try
        {
            return Ok(_searchService.GetEntity(entityId));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}

