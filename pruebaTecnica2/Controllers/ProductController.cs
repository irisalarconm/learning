using Microsoft.AspNetCore.Mvc;
using pruebaTecnica.Models;
using pruebaTecnica.Services;

namespace pruebaTecnica.Controllers;

[Route("prueba/[controller]")]

public class ProductController : ControllerBase
{
    IProductService productService;

    public ProductController(IProductService service)
    {
        productService = service;
    }

    [HttpGet]

    public IActionResult Get()
    {
        return Ok(productService.Get());
    }

    [HttpPost]

    public IActionResult Post([FromBody] Product product)
    {
        return Ok(productService.Save(product));
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] Product product)
    {
        productService.Update(id, product);
        return Ok();
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(Guid id)
    {
        productService.Delete(id);
        return Ok();
    }

}