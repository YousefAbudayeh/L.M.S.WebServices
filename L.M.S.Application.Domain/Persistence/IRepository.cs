using System.Linq.Expressions;

namespace L.M.S.Application.Domain.Persistence;

public interface IRepository<T>
{
    IQueryable<T> GetQueryable();

    Task Add(T model);

    Task<int> Update(T model);

    Task<int> Update(ICollection<T> models);

    Task Delete(T model);
}