using Microsoft.AspNetCore.Mvc;
using pruebaTecnica.Models;
using pruebaTecnica.Services;

namespace pruebaTecnica.Controllers;

[Route("prueba/[controller]")]

public class ClientController : ControllerBase
{
    IClientService clientService;

    public ClientController(IClientService service)
    {
        clientService = service;
    }

    [HttpGet]

    public IActionResult Get()
    {
        return Ok(clientService.Get());
    }

    [HttpPost]

    public IActionResult Post([FromBody] Client client)
    {
        return Ok(clientService.Save(client));
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] Client client)
    {
        clientService.Update(id, client);
        return Ok();
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(Guid id)
    {
        clientService.Delete(id);
        return Ok();
    }

}