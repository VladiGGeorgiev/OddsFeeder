using System.Collections.Generic;
using System.Linq;

namespace XmlFeeder.Data.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Find(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Delete(object id);

        void BulkMerge(IEnumerable<T> entities);
    }
}
