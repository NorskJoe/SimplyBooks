using AutoMapper;
using SimplyBooks.Models.Dtos;

namespace SimplyBooks.Models.Mapping
{
    class BookMapping : Profile
    {
        public BookMapping()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
        }
    }
}
