using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;

namespace my_books.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions <AppDbContext> options):base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(book => book.Book)
                .WithMany(ba => ba.book_Authors)
                .HasForeignKey(bi => bi.Id);
            
            modelBuilder.Entity<Book_Author>()
                .HasOne(book => book.Author)
                .WithMany(ba => ba.book_Authors)
                .HasForeignKey(bi => bi.AuthorId);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book_Author> book_Authors { get; set; }


    }
}
