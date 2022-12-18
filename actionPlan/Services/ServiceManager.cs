using Library.Domain.Repositories;
using Services.Interfaces;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthorService> _authorServiceLazy;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _authorServiceLazy = new Lazy<IAuthorService>(() => new AuthorService(repositoryManager));
        }


        public IAuthorService AuthorService => _authorServiceLazy.Value;
    }
}
