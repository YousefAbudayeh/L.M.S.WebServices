using L.M.S.Application.Common.Dto;
using L.M.S.Application.Common.Responses;
using L.M.S.Application.Common.ViewModels;

namespace L.M.S.Application.Interfaces;

public interface IBooksService
{
    Task<Response<ICollection<BooksViewModel>>>GetAll();

    Task<Response<BooksViewModel>> Get(Guid uid);

    Task<Response<BookResponse>> Create(BookCreateRequest request);

    Task<Response<BookResponse>> Update(BookUpdateRequest request);

    Task<Response<string>> Delete(Guid uid);
}