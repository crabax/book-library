using webapi.Domain.Models;

namespace webapi.Domain.Contracts
{
    public interface IBookBusiness
    {
        IQueryable<Book> SearchBooks(string? filter, string? searchBy);
    }
}
