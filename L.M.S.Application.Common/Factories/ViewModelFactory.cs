using L.M.S.Application.Common.ViewModels;
using L.M.S.Application.Domain.Entities;

namespace L.M.S.Application.Common.Factories;

public static class ViewModelFactory
{
    public static BooksViewModel CreateBook(Guid uid, string title, string description, string author, ICollection<string>? categories = null)
    {
        return new()
        {
            Uid = uid,
            Title = title,
            Description = description,
            Author = author,
            Categories = categories ?? new List<string>()
        };
    }

    public static BooksViewModel CreateBookWithCategoryDetails(Guid uid, string title, string description, string author, ICollection<CategoriesViewModel>? categories = null)
    {
        return new()
        {
            Uid = uid,
            Title = title,
            Description = description,
            Author = author,
            CategoryDetails = categories
        };
    }

    public static CategoriesViewModel Create(Category category)
    {
        return new CategoriesViewModel
        {
            Uid = category.Uid,
            Name = category.Name
        };
    }
}