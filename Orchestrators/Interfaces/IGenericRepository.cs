using System.Linq.Expressions;

namespace OrdersManager.Orchestrators.Interfaces
{
    public interface IGenericRepository<T>
    {
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        T GetByID(int? id);
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null);

    }
}
