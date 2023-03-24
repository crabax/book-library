using webapi.Domain.Contracts;
using webapi.Domain.Core;
using webapi.Domain.Models;

namespace webapi.Domain.Services
{
    public class BookBusiness : IBookBusiness
    {
        private readonly BookLibraryDbContext _context;
        public BookBusiness(BookLibraryDbContext context)
        {
            _context = context;
        }

        public IQueryable<Book> SearchBooks(string? filter, string? searchBy)
        {
            var query = _context.Books!.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.ToLower();

                if (searchBy == nameof(SearchByTypes.Type))
                {
                    query = query.Where(m => m.Type!.ToLower().Contains(filter));
                }

                if (searchBy == nameof(SearchByTypes.Authors))
                {
                    query = query.Where(m => m.FirstName.ToLower().Contains(filter) || m.LastName.ToLower().Contains(filter));
                }

                if (searchBy == nameof(SearchByTypes.ISBN))
                {
                    query = query.Where(m => m.ISBN!.ToLower().Contains(filter));
                }

                if (string.IsNullOrWhiteSpace(searchBy))
                {
                    query = query.Where(m =>
                    m.Type!.ToLower().Contains(filter) ||
                    m.ISBN!.ToLower().Contains(filter) ||
                    m.FirstName.ToLower().Contains(filter) || m.LastName.ToLower().Contains(filter)
                    );
                }
            }

            return query;
        }
    }
}
