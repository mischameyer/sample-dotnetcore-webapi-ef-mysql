using sample_dotnetcore_webapi_ef_infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace sample_dotnetcore_webapi_ef_infrastructure.Interface
{
    public interface IBookRepository : IBaseRepository<Book>
    {
    }
}
