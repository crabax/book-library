using Microsoft.AspNetCore.Mvc;
using webapi.Application.Contracts;
using webapi.Application.Dto;

namespace webapi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedItems<List<BookDto>>>> GetBooks(int page, int pageSize, string? filter, string? searchBy)
        {
            return await _bookService.SearchBooks(page, pageSize, filter, searchBy);
        }
    }
}
