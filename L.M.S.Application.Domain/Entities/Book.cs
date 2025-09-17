namespace L.M.S.Application.Domain.Entities;

public class Book
{
    public Guid Id { get; set; }

    public Guid Uid { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Author { get; set; }

    public ICollection<BookCategory> BookCategories { get; set; }
}