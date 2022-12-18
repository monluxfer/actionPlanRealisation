namespace Library.Domain.Entities
{
    public class Manga : Literature
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
