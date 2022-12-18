using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repositories
{
    public interface IMangaRepository
    {
        Task<IEnumerable<Manga>> GetAllByAuthorIdAsync(int authorId, CancellationToken cancellationToken = default);

        Task<Manga> GetByIdAsync(int mangaId, CancellationToken cancellationToken = default);

        void Insert(Manga manga);

        void Remove(Manga manga);
    }
}
