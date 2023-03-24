using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using webapi.Application.Contracts;
using webapi.Application.Dto;
using webapi.Domain.Contracts;

namespace webapi.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookBusiness _bookBusiness;
        private readonly IMapper _mapper;

        public BookService(IMapper mapper, IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
            _mapper = mapper;
        }

        public async Task<PaginatedItems<List<BookDto>>> SearchBooks(int page, int pageSize, string? filter, string? searchBy)
        {
            page = page <= 0 ? 1 : page;
            var query = _bookBusiness.SearchBooks(filter, searchBy);

            var totalCount = query.Count();
            query = query.OrderBy(o => o.Title).Skip((page - 1) * pageSize).Take(pageSize);
            var items = await query.ProjectTo<BookDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginatedItems<List<BookDto>>(items, totalCount);
        }
    }
}
