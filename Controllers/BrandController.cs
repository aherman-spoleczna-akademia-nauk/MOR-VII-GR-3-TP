using Mappery_Relacyjno_Obiektowe.Commands;
using Mappery_Relacyjno_Obiektowe.Database.Entities;
using Mappery_Relacyjno_Obiektowe.DTOS;
using Mappery_Relacyjno_Obiektowe.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mappery_Relacyjno_Obiektowe.Controllers;

[ApiController]
[Route("api/brand")]
public class BrandController : ControllerBase
{
    private readonly IBrandService _service;

    public BrandController(IBrandService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAsync([FromQuery] string? name)
    {
        var data = await _service.GetAsync(name);
        if (data.Count() == 0)
            return NoContent();

        return Ok(data);
    }

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
    {
        var brand = await _service.GetByIdAsync(id);
        if (brand == null)
            return BadRequest("Brak marki o podanym Id");

        return Ok(brand);
    }


    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateBrandCommand command)
    {
        var result = await _service.CreateAsync(command);
        if (!result.Success)
        {
            if (result.ErrorType == ErrorType.NO_DATA)
                return BadRequest(result.Error);
            else
                return Conflict(result.Error);
        }

        var data = result.Data as Brand;
        return Created("", data);

    }
}
