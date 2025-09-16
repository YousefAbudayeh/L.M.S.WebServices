using L.M.S.Application.Common.Dto;
using L.M.S.Application.Common.Helpers;
using L.M.S.Application.Domain.Entities;

namespace L.M.S.Application.Common.Factories;

public static class EntityFactory
{
    public static Book Create(BookCreateRequest request, ICollection<Category> categories)
    {
        return new()
        {
            Id = Generator.CreateV7Guid(),
            Uid = Generator.CreateV7Guid(),
            Title = request.Title,
            Description = request.Description,
            Author = request.Author,
            Categories = categories
        };
    }
}