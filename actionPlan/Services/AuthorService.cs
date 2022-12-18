using Contracts;
using Library.Domain.Entities;
using Library.Domain.Repositories;
using Mapster;
using Services.Interfaces;

namespace Services
{
    internal sealed class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AuthorService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<AuthorDto> CreateAsync(AuthorCreationDto author, CancellationToken cancellationToken = default)
        {
            var newauthor = author.Adapt<Author>();

            _repositoryManager.AuthorRepository.Insert(newauthor);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return newauthor.Adapt<AuthorDto>();
        }

        public async Task DeleteAsync(int authorId, CancellationToken cancellationToken = default)
        {
            var author = await _repositoryManager.AuthorRepository.GetByIdAsync(authorId, cancellationToken);

            if (author is null)
            {
                throw new Exception();
            }

            _repositoryManager.AuthorRepository.Remove(author);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var authors = await _repositoryManager.AuthorRepository.GetAllAsync(cancellationToken);

            var authorDto = authors.Adapt<IEnumerable<AuthorDto>>();

            return authorDto;
        }

        public async Task<AuthorDto> GetByIdAsync(int authorId, CancellationToken cancellationToken = default)
        {
            var author = await _repositoryManager.AuthorRepository.GetByIdAsync(authorId, cancellationToken);

            if (author is null)
            {
                throw new Exception();
            }

            var authorDto = author.Adapt<AuthorDto>();

            return authorDto;
        }
    }
}
