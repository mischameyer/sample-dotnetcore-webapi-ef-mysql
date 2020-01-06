using sample_dotnetcore_webapi_ef_infrastructure.Entities;
using sample_dotnetcore_webapi_ef_infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace sample_dotnetcore_webapi_ef_infrastructure.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(DbContext context) : base(context)
        {
        }

    }
}
