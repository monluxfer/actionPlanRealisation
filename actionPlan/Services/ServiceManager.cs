using Library.Domain.Repositories;
using Services.Interfaces;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthorService> _authorServiceLazy;
        private readonly Lazy<IBookService> _bookServiceLazy;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _authorServiceLazy = new Lazy<IAuthorService>(() => new AuthorService(repositoryManager));
            _bookServiceLazy = new Lazy<IBookService>(() => new BookService(repositoryManager));
        }


        public IAuthorService AuthorService => _authorServiceLazy.Value;

        public IBookService bookService => _bookServiceLazy.Value;
    }
}
