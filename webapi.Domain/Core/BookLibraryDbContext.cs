using Microsoft.EntityFrameworkCore;
using webapi.Domain.Models;

namespace webapi.Domain.Core
{
    public class BookLibraryDbContext : DbContext
    {
        public BookLibraryDbContext(DbContextOptions<BookLibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;
    }
}
