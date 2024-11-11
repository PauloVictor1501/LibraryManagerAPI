using LibraryManagerAPI.Comunication.Request;
using LibraryManagerAPI.Comunication.Response;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private static List<Book> _books = new List<Book> { };

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

        _books.Add(new Book { Id = request.Id, Title = request.Title });

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult GetBook()
    {
        return Ok(_books);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]


    public IActionResult Update([FromRoute] int id, [FromBody] RequestUpdateBookJson request)
    {
        Book? FindBookById(int id)
        {
            foreach (var book in _books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }

            return null;
        }
        var book = FindBookById(id);

        if (book == null)
        {
            return NotFound("Livro não encontrado.");
        }

        book.Title = request.Title;
        book.Author = request.Author;
        book.Price = request.Price;
        book.Genre = request.Genre;

        return Ok(book);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public IActionResult Delete(int id)
    {
        Book? FindBookById(int id)
        {
            foreach (var book in _books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }

            return null;
        }
        var book = FindBookById(id);

        if (book == null)
        {
            return NotFound("Livro não encontrado.");
        }

        _books.Remove(book);

        return Ok($"Livro com Id {id} deletado com sucesso");
    }
    
}
