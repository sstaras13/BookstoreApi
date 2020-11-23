using Microsoft.EntityFrameworkCore;

namespace BookstoreApi.Models
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        public DbSet<BookstoreItem> BookstoreItems { get; set; }

        public DbSet<BookstoreOrder> BookstoreOrder { get; set; }
    }
}