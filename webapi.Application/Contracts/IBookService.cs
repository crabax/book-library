using webapi.Application.Dto;

namespace webapi.Application.Contracts
{
    public interface IBookService
    {
        Task<PaginatedItems<List<BookDto>>> SearchBooks(int page, int pageSize, string? filter, string? searchBy);
    }
}
