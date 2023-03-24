using AutoMapper;
using webapi.Application.Dto;
using webapi.Domain.Models;

namespace webapi.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Book, BookDto>()
                .ForMember(m => m.Authors, m => m.MapFrom(x => $"{x.FirstName} {x.LastName}"))
                .ForMember(m => m.AvailableCopies, m => m.MapFrom(x => $"{(x.TotalCopies - x.CopiesInUse)}/{x.TotalCopies}"));
        }
    }
}
