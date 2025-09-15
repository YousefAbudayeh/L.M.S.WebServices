using L.M.S.Application.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace L.M.S.Application.Persistence.Sql;

public abstract class RepositoryBase<T> : IRepository<T> where T : class
{
    protected readonly LMSSqlContext context;

    protected RepositoryBase(LMSSqlContext context)
    {
        this.context = context;
    }

    public IQueryable<T> GetQueryable() => this.context.Set<T>().AsNoTracking();

    public async Task Add(T model)
    {
        this.context.Set<T>().Add(model);
        await this.context.SaveChangesAsync();
    }

    public async Task<int> Update(T model)
    {
        this.context.Set<T>().Update(model);
        return await this.context.SaveChangesAsync();
    }

    public async Task<int> Update(ICollection<T> models)
    {
        this.context.Set<T>().UpdateRange(models);
        return await this.context.SaveChangesAsync();
    }

    public async Task Delete(T model)
    {
        this.context.Set<T>().Remove(model);
        await this.context.SaveChangesAsync();
    }
}