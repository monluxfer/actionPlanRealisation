namespace Services.Interfaces
{
    public interface IServiceManager
    {
        IAuthorService AuthorService { get; }

        IBookService BookService { get; }

        IMangaService MangaService { get; }
    }
}
