using Contracts;
using Library.Domain.Entities;
using Library.Domain.Repositories;
using Mapster;
using Services.Interfaces;

namespace Services
{
    public class MangaService : IMangaService
    {
        private readonly IRepositoryManager _repositoryManager;

        public MangaService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<MangaDto> CreateAsync(MangaCreationDto manga, CancellationToken cancellationToken = default)
        {
            var newManga = manga.Adapt<Manga>();

            _repositoryManager.MangaRepository.Insert(newManga);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return newManga.Adapt<MangaDto>();
        }

        public async Task DeleteAsync(int mangaId, CancellationToken cancellationToken = default)
        {
            var manga = await _repositoryManager.MangaRepository.GetByIdAsync(mangaId, cancellationToken);

            if (manga is null)
            {
                throw new Exception();
            }

            _repositoryManager.MangaRepository.Remove(manga);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<MangaDto>> GetAllByAuthorIdAsync(int authorId, CancellationToken cancellationToken = default)
        {
            var mangas = await _repositoryManager.MangaRepository.GetAllByAuthorIdAsync(authorId, cancellationToken);

            var mangasDto = mangas.Adapt<IEnumerable<MangaDto>>();

            return mangasDto;
        }

        public async Task<MangaDto> GetByIdAsync(int mangaId, CancellationToken cancellationToken = default)
        {
            var manga = await _repositoryManager.MangaRepository.GetByIdAsync(mangaId, cancellationToken);

            if (manga is null)
            {
                throw new Exception();
            }

            var mangaDto = manga.Adapt<MangaDto>();

            return mangaDto;
        }

        public async Task<IEnumerable<MangaDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var mangas = await _repositoryManager.MangaRepository.GetAllAsync(cancellationToken);

            var mangasDto = mangas.Adapt<IEnumerable<MangaDto>>();

            return mangasDto;
        }
    }
}
