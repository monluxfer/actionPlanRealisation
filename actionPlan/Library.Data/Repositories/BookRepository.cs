using Library.Domain.Entities;
using Library.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _libraryDbContext;

        public BookRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task<IEnumerable<Book>> GetAllByAuthorIdAsync(int authorId, CancellationToken cancellationToken = default)
        {
            return await _libraryDbContext.Books.Where(book => book.AuthorId == authorId).ToListAsync(cancellationToken);
        }

        public async Task<Book> GetByIdAsync(int bookId, CancellationToken cancellationToken = default)
        {
            return await _libraryDbContext.Books.FirstOrDefaultAsync(book => book.Id == bookId, cancellationToken);
        }

        public void Insert(Book book)
        {
            _libraryDbContext.Books.Add(book);
        }

        public void Remove(Book book)
        {
            _libraryDbContext.Books.Remove(book);
        }
    }
}
