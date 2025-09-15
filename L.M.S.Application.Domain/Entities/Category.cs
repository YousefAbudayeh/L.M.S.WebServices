namespace L.M.S.Application.Domain.Entities;

public class Category
{
    public Guid Id { get; set; }

    public Guid Uid { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Book> Books { get; set; }
}