using Library.Domain.Entities;
using Library.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repositories
{
    public class MangaRepository : IMangaRepository
    {
        private readonly LibraryDbContext _libraryDbContext;

        public MangaRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }


        public async Task<IEnumerable<Manga>> GetAllByAuthorIdAsync(int authorId, CancellationToken cancellationToken = default)
        {
            return await _libraryDbContext.Mangas.Where(manga => manga.AuthorId == authorId).ToListAsync(cancellationToken);
        }

        public async Task<Manga> GetByIdAsync(int mangaId, CancellationToken cancellationToken = default)
        {
            return await _libraryDbContext.Mangas.FirstOrDefaultAsync(manga => manga.Id == mangaId, cancellationToken);
        }

        public void Insert(Manga manga)
        {
            _libraryDbContext.Mangas.Add(manga);
        }

        public void Remove(Manga manga)
        {
            _libraryDbContext.Mangas.Remove(manga);
        }
    }
}
