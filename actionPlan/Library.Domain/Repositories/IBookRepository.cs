using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllByAuthorIdAsync(int authorId, CancellationToken cancellationToken = default);

        Task<Book> GetByIdAsync(int bookId, CancellationToken cancellationToken = default);

        void Insert(Book book);

        void Remove(Book book);
    }
}
