using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<AuthorDto> GetByIdAsync(int authorId, CancellationToken cancellationToken = default);

        Task<AuthorDto> CreateAsync(AuthorCreationDto author, CancellationToken cancellationToken = default);

        Task DeleteAsync(int authorId, CancellationToken cancellationToken = default);
    }
}
