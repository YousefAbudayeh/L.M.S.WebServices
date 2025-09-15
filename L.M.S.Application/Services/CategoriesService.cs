using L.M.S.Application.Common.Dto;
using L.M.S.Application.Common.Responses;
using L.M.S.Application.Common.ViewModels;
using L.M.S.Application.Interfaces;

namespace L.M.S.Application.Services;

public class CategoriesService : ICategoriesService
{
    public Task<Response<ICollection<CategoriesViewModel>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Response<CategoriesResponse>> Create(CategoryCreateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<CategoriesResponse>> Update(CategoryUpdateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> Delete(Guid uid)
    {
        throw new NotImplementedException();
    }
}