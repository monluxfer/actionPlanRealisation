using Library.Domain.Entities;
using Library.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _libraryDbContext;

        public AuthorRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task<IEnumerable<Author>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _libraryDbContext.Authors.ToListAsync(cancellationToken);
        }

        public async Task<Author> GetByIdAsync(int authorId, CancellationToken cancellationToken = default)
        {
            return await _libraryDbContext.Authors.FirstOrDefaultAsync(author => author.Id == authorId, cancellationToken);
        }

        public void Insert(Author author)
        {
            _libraryDbContext.Authors.Add(author);
        }

        public void Remove(Author author)
        {
            _libraryDbContext.Authors.Remove(author);
        }
    }
}
