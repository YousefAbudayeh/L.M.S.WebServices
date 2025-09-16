namespace L.M.S.Application.Common.Dto;

public class BookUpdateRequest
{
    public Guid Uid { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Author { get; set; }

    public List<Guid>? CategoryUids { get; set; }
}