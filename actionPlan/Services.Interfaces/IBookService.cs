using Contracts;

namespace Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllByAuthorIdAsync(int authorId, CancellationToken cancellationToken = default);

        Task<BookDto> GetByIdAsync(int bookId, CancellationToken cancellationToken = default);

        Task<BookDto> CreateAsync(BookCreationDto book, CancellationToken cancellationToken = default);

        Task DeleteAsync(int bookId, CancellationToken cancellationToken = default);

        Task<IEnumerable<BookDto>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
