namespace my_books.Data.Models
{
    public class Book_Author
    {
        public int Id { get; set; }

        public int bookId { get; set; }

        public Book Book { get; set; }

        public int AuthorId { get; set; } = 0;

        public Author Author { get; set; }

    }
}
