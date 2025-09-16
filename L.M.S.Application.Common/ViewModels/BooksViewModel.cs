namespace L.M.S.Application.Common.ViewModels;

public class BooksViewModel
{
    public Guid Uid { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Author { get; set; }

    public ICollection<string> Categories { get; set; }
}