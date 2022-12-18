using Library.Domain.Repositories;

namespace Library.Data.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IAuthorRepository> _authorRepositoryLazy;
        private readonly Lazy<IBookRepository> _bookRepositoryLazy;
        private readonly Lazy<IMangaRepository> _mangaRepositoryLazy;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(LibraryDbContext libraryDbContext)
        {
            _authorRepositoryLazy = new Lazy<IAuthorRepository>(() => new AuthorRepository(libraryDbContext));
            _bookRepositoryLazy = new Lazy<IBookRepository>(() => new BookRepository(libraryDbContext));
            _mangaRepositoryLazy = new Lazy<IMangaRepository>(() => new MangaRepository(libraryDbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(libraryDbContext));
        }
        public IBookRepository BookRepository => _bookRepositoryLazy.Value;

        public IMangaRepository MangaRepository => _mangaRepositoryLazy.Value;

        public IAuthorRepository AuthorRepository => _authorRepositoryLazy.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
