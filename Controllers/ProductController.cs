using Mappery_Relacyjno_Obiektowe.Commands;
using Mappery_Relacyjno_Obiektowe.Database.Entities;
using Mappery_Relacyjno_Obiektowe.DTOS;
using Mappery_Relacyjno_Obiektowe.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mappery_Relacyjno_Obiektowe.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task <IActionResult> Get()
    {
        // chcemy dostać listę produktów promowanych, zwierającą nazwę produktu, dwie ceny, 
        // nazwę kategorii, markę produktu i jedno zdjęcie
        return Ok("Tu będzie lista produktów");
    }


    [HttpPost]
    public async Task<IActionResult> Addasync(CreateProductCommand command)
    {
        var result = await _service.CreateAsync(command);
        if (!result.Success)
            return BadRequest(result.Error);
         
        var data = result.Data as ProductDto;
        return Created("", data);
    }
}
