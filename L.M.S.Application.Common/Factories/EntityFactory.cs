using L.M.S.Application.Common.Dto;
using L.M.S.Application.Common.Helpers;
using L.M.S.Application.Domain.Entities;

namespace L.M.S.Application.Common.Factories;

public static class EntityFactory
{
    public static Book Create(BookCreateRequest request, ICollection<Category> categories)
    {
        var book = new Book
        {
            Id = Generator.CreateV7Guid(),
            Uid = Generator.CreateV7Guid(),
            Title = request.Title,
            Description = request.Description,
            Author = request.Author,
            BookCategories = new List<BookCategory>()
        };

        book.BookCategories = CreateBookCategories(book.Id, categories);

        return book;
    }

    public static ICollection<BookCategory> CreateBookCategories(Guid bookId, ICollection<Category> categories)
    {
        return categories.Select(c => new BookCategory
        {
            BookId = bookId,
            CategoryId = c.Id
        }).ToList();
    }

    public static Category Create(CategoryCreateRequest request)
    {
        return new()
        {
            Id = Generator.CreateV7Guid(),
            Uid = Generator.CreateV7Guid(),
            Name = request.Name,
            BookCategories = new List<BookCategory>()
        };
    }
}