using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Author> GetByIdAsync(int authorId, CancellationToken cancellationToken = default);

        void Insert(Author author);

        void Remove(Author author);
    }
}
