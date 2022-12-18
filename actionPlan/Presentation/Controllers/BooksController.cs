using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public BooksController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("author/{authorId:int}")]
        public async Task<IActionResult> GetBooksByAuthorId(int authorId, CancellationToken cancellationToken)
        {
            var books = await _serviceManager.BookService.GetAllByAuthorIdAsync(authorId, cancellationToken);

            return Ok(books);
        }

        [HttpGet("{bookId:int}")]
        public async Task<IActionResult> GetBookByBookId(int bookId, CancellationToken cancellationToken)
        {
            var book = await _serviceManager.BookService.GetByIdAsync(bookId, cancellationToken);

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookCreationDto book)
        {
            var bookDto = await _serviceManager.BookService.CreateAsync(book);

            return Ok(bookDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks(CancellationToken cancellationToken)
        {
            var books = await _serviceManager.BookService.GetAllAsync(cancellationToken);

            return Ok(books);
        }

        [HttpDelete("{bookId:int}")]
        public async Task<IActionResult> DeleteBook(int bookId, CancellationToken cancellationToken)
        {
            await _serviceManager.BookService.DeleteAsync(bookId, cancellationToken);

            return Ok();
        }
    }
}
