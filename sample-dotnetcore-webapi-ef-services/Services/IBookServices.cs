using sample_dotnetcore_webapi_ef_infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace sample_dotnetcore_webapi_ef_services.Services
{
    public interface IBookServices
    {
        Book GetSingle(int id);
        void Add(Book item);
        void Delete(int id);
        Book Update(int id, Book item);
        IQueryable<Book> GetAll(bool? read);
        int Count(Expression<Func<Book, bool>> predicate = null);
        bool Save();

    }
}
