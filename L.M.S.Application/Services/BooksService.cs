using L.M.S.Application.Common.Dto;
using L.M.S.Application.Common.Responses;
using L.M.S.Application.Common.ViewModels;
using L.M.S.Application.Interfaces;

namespace L.M.S.Application.Services;

public class BooksService : IBooksService
{
    public Task<Response<ICollection<BooksViewModel>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Response<BooksViewModel>> Get(Guid uid)
    {
        throw new NotImplementedException();
    }

    public Task<Response<BookResponse>> Create(BookCreateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<BookResponse>> Update(BookUpdateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> Delete(Guid uid)
    {
        throw new NotImplementedException();
    }
}