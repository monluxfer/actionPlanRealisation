using Contracts;
using Library.Domain.Entities;
using Library.Domain.Repositories;
using Mapster;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class BookService : IBookService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BookService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<BookDto> CreateAsync(BookCreationDto book, CancellationToken cancellationToken = default)
        {
            var newbook = book.Adapt<Book>();

            _repositoryManager.BookRepository.Insert(newbook);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return newbook.Adapt<BookDto>();
        }

        public async Task DeleteAsync(int bookId, CancellationToken cancellationToken = default)
        {
            var book = await _repositoryManager.BookRepository.GetByIdAsync(bookId, cancellationToken);

            if (book is null)
            {
                throw new Exception();
            }

            _repositoryManager.BookRepository.Remove(book); ;

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var books = await _repositoryManager.BookRepository.GetAllAsync(cancellationToken);

            var booksDto = books.Adapt<IEnumerable<BookDto>>();

            return booksDto;
        }

        public async Task<IEnumerable<BookDto>> GetAllByAuthorIdAsync(int authorId, CancellationToken cancellationToken = default)
        {
            var books = await _repositoryManager.BookRepository.GetAllByAuthorIdAsync(authorId, cancellationToken);

            var booksDto = books.Adapt<IEnumerable<BookDto>>();

            return booksDto;
        }

        public async Task<BookDto> GetByIdAsync(int bookId, CancellationToken cancellationToken = default)
        {
            var book = await _repositoryManager.BookRepository.GetByIdAsync(bookId, cancellationToken);

            if (book is null)
            {
                throw new Exception();
            }

            var bookDto = book.Adapt<BookDto>();

            return bookDto;
        }
    }
}
