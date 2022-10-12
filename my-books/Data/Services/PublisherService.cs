using System;
using System.Linq;
using my_books.Data.Models;
using my_books.Data.VeiwModels;

namespace my_books.Data.Services
{
    
    public class PublisherService
    {
        private AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context; 

        }

        public void AddPusblisher(PublisherVm publisher)
        {
            var _Publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_Publisher);
            _context.SaveChanges(); 
        }
         
        public PublisherWithBooksAndAuthorsVM GetPublisherData(int id)
        {
            var _publisherData = _context.Publishers.Where(Publisher => Publisher.Id == id)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,                
                    BookAuthors = n.books.Select(book => new BookAuthorVM()
                    {
                        BookName = book.Title,
                        BookAuthors = book.Book_Authors.Select(book_author => book_author.Author.Name).ToList(),
                    }).ToList()
                }).FirstOrDefault() ;

            return _publisherData;
        }

        public void DeletePublisherById(int publisherId)
        {
            var _Publisher = _context.Publishers.
                FirstOrDefault(Publisher => Publisher.Id == publisherId);
            if(_Publisher != null )
            {
                _context.Publishers.Remove(_Publisher);
                _context.SaveChanges();
            }
        }
    }
}
