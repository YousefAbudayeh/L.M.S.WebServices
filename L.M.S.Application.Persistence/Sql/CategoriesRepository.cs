using L.M.S.Application.Domain.Entities;
using L.M.S.Application.Domain.Persistence;

namespace L.M.S.Application.Persistence.Sql;

internal class CategoriesRepository : RepositoryBase<Category>, ICategoriesRepository
{
    public CategoriesRepository(LMSSqlContext context) : base(context)
    {
    }
}