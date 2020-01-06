using Abp.AutoMapper;
using sample_dotnetcore_webapi_ef_infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sample_dotnetcore_webapi_ef_services.Dtos
{
    [AutoMap(typeof(Book))]
    public class BookCreateDto
    {

        public bool Read { get; set; }

        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }
}
