using Library.Domain.Repositories;
using Services.Interfaces;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthorService> _authorServiceLazy;
        private readonly Lazy<IBookService> _bookServiceLazy;
        private readonly Lazy<IMangaService> _mangaServiceLazy;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _authorServiceLazy = new Lazy<IAuthorService>(() => new AuthorService(repositoryManager));
            _bookServiceLazy = new Lazy<IBookService>(() => new BookService(repositoryManager));
            _mangaServiceLazy = new Lazy<IMangaService>(() => new MangaService(repositoryManager));
        }

        public IAuthorService AuthorService => _authorServiceLazy.Value;

        public IBookService BookService => _bookServiceLazy.Value;

        public IMangaService MangaService => _mangaServiceLazy.Value;
    }
}
