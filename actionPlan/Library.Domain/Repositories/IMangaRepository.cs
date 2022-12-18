using Library.Domain.Entities;

namespace Library.Domain.Repositories
{
    public interface IMangaRepository
    {
        Task<IEnumerable<Manga>> GetAllByAuthorIdAsync(int authorId, CancellationToken cancellationToken = default);

        Task<Manga> GetByIdAsync(int mangaId, CancellationToken cancellationToken = default);

        void Insert(Manga manga);

        void Remove(Manga manga);

        Task<IEnumerable<Manga>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
