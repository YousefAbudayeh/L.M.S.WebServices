using L.M.S.Application.Common.Dto;
using L.M.S.Application.Domain.Entities;

namespace L.M.S.Application.Common.Factories;

public static class EntityFactory
{
    public static Book Create(BookCreateRequest request)
    {
        return new()
        {

        };
    }
}