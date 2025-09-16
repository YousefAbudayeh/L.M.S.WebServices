using L.M.S.Application.Domain.Entities;
using L.M.S.Application.Domain.Persistence;

namespace L.M.S.Application.Persistence.Sql;

internal class BooksRepository : RepositoryBase<Book>, IBooksRepository
{
    public BooksRepository(LMSSqlContext context) : base(context)
    {
    }
}