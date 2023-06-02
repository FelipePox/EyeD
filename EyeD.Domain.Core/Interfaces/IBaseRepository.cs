using System.Linq.Expressions;

namespace EyeD.Domain.Core.Interfaces;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> GetManyWhere(Expression<Func<T, bool>> condition);
    Task<T> GetOneWhere(Expression<Func<T, bool>> condition);
    Task<T> Insert(T entity);
    Task<T> Update(T entity);
    Task<bool> Delete(T entity);
}
