using System.Collections.Generic;

namespace my_books.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book_Author> book_Authors { get; set; }
    


    }
}
