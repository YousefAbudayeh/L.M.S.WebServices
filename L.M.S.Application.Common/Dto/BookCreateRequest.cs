namespace L.M.S.Application.Common.Dto;

public class BookCreateRequest
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Author { get; set; }

    public ICollection<Guid> CategoryUids { get; set; }
}