using Library.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _libraryDbContext;

        public UnitOfWork(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
