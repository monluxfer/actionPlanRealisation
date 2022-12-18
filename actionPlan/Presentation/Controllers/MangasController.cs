using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/mangas")]
    public class MangasController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public MangasController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetMangas(CancellationToken cancellationToken)
        {
            var mangas = await _serviceManager.MangaService.GetAllAsync(cancellationToken);

            return Ok(mangas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateManga([FromBody] MangaCreationDto mangaCreationDto, CancellationToken cancellationToken)
        {
            var mangaDto = await _serviceManager.MangaService.CreateAsync(mangaCreationDto, cancellationToken);

            return Ok(mangaDto);
        }

        [HttpDelete("{mangaId:int}")]
        public async Task<IActionResult> DeleteManga(int mangaId, CancellationToken cancellationToken)
        {
            await _serviceManager.MangaService.DeleteAsync(mangaId, cancellationToken);

            return Ok();
        }

        [HttpGet("{mangaId:int}")]
        public async Task<IActionResult> GetMangaByBookId(int mangaId, CancellationToken cancellationToken)
        {
            var manga = await _serviceManager.MangaService.GetByIdAsync(mangaId, cancellationToken);

            return Ok(manga);
        }
    }
}
