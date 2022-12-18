using Contracts;

namespace Services.Interfaces
{
    public interface IMangaService
    {
        Task<IEnumerable<MangaDto>> GetAllByAuthorIdAsync(int authorId, CancellationToken cancellationToken = default);

        Task<MangaDto> GetByIdAsync(int mangaId, CancellationToken cancellationToken = default);

        Task<MangaDto> CreateAsync(MangaCreationDto manga, CancellationToken cancellationToken = default);

        Task DeleteAsync(int mangaId, CancellationToken cancellationToken = default);

        Task<IEnumerable<MangaDto>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
