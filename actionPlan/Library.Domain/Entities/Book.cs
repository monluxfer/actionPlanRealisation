namespace Library.Domain.Entities
{
    public class Book : Literature
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
