using System.Linq;
using my_books.Data.Models;
using my_books.Data.VeiwModels;

namespace my_books.Data.Services
{
    
    public class AuthorsService
    {
        private AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context; 

        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                Name = author.Name
            };
            _context.Authors.Add(_author);
            _context.SaveChanges(); 
        }
        
        public AuthorWithBooksVM GetAuthorWithBooksVM(int authorId)
        {
            var _aurhorWithBooksVM = _context.Authors.Where(author => author.Id == authorId).Select(author => new AuthorWithBooksVM()
            {
                Name= author.Name,
                BookTitles = author.Book_Authors.Select(book_authors => book_authors.Book.Title).ToList()
            }).FirstOrDefault();

            return _aurhorWithBooksVM;
        }
    }
}
