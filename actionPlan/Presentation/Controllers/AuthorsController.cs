using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthorsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors(CancellationToken cancellationToken)
        {
            var authors = await _serviceManager.AuthorService.GetAllAsync(cancellationToken);

            return Ok(authors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorCreationDto authorDto)
        {
            var author = await _serviceManager.AuthorService.CreateAsync(authorDto);

            return Ok(author);
        }

        [HttpDelete("{authorId:int}")]
        public async Task<IActionResult> DeleteAuthor(int authorId, CancellationToken cancellationToken)
        {
            await _serviceManager.AuthorService.DeleteAsync(authorId, cancellationToken);

            return Ok();
        }
    }
}
