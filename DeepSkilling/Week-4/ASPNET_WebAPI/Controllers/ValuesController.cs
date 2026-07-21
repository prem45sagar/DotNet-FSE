using Microsoft.AspNetCore.Mvc;

namespace _1.web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[] { "Apple", "Banana", "Mango" });
    }

    [HttpPost]
    public IActionResult Post()
    {
        return Ok("Product Added");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id)
    {
        return Ok($"Updated Product {id}");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok($"Deleted Product {id}");
    }
}