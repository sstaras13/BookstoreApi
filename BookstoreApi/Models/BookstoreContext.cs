using Microsoft.EntityFrameworkCore;
using BookstoreApi.Models;

namespace BookstoreApi.Models
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        public DbSet<BookstoreItem> BookstoreItems { get; set; }

        public DbSet<BookstoreApi.Models.BookstoreOrder> BookstoreOrder { get; set; }
    }
}