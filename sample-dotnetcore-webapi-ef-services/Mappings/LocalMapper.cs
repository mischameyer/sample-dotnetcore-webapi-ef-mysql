using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using sample_dotnetcore_webapi_ef_infrastructure.Entities;
using sample_dotnetcore_webapi_ef_services.Dtos;

namespace sample_dotnetcore_webapi_ef_services.Mappings
{
    public class LocalMapper : Profile
    {
        public LocalMapper()
        {
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookDto>();
        }
    }
}
