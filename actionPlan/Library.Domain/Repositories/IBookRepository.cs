using Library.Domain.Entities;

namespace Library.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllByAuthorIdAsync(int authorId, CancellationToken cancellationToken = default);

        Task<Book> GetByIdAsync(int bookId, CancellationToken cancellationToken = default);

        void Insert(Book book);

        void Remove(Book book);

        Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
