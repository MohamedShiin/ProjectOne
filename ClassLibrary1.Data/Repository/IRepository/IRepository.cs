using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data.Repository.IRepository
{
   public interface IRepository<T> where T : class
    {
        // T- Category
        T GetFirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> filter,string? includeProperties=null);

        IEnumerable<T> GetAll(string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
