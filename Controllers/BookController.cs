using LibraryManagerAPI.Comunication.Request;
using LibraryManagerAPI.Comunication.Response;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerAPI.Controllers;

public class BookController : ControllerBase
{
    [Route("api/[controller]")]
    [HttpPost]
    [ProducesResponseType(typeof(RequestRegisterBookJson), StatusCodes.Status201Created)]

    public IActionResult Create([FromBody] RequestRegisterBookJson request)
    {
        
        var response = new ResponseRegisterBookJson
        {
            Id = request.Id,
            Title = request.Title
        };

        if (request.Id == 0)
        {
            return BadRequest("O campo 'Id' é obrigatório.");
        }

        return Created(string.Empty, response);
    }
    
}
