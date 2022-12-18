using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IBookRepository BookRepository { get; }

        IMangaRepository MangaRepository { get; }

        IAuthorRepository AuthorRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
