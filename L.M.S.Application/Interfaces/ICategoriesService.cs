using L.M.S.Application.Common.Dto;
using L.M.S.Application.Common.Responses;
using L.M.S.Application.Common.ViewModels;

namespace L.M.S.Application.Interfaces;

public interface ICategoriesService
{
    Task<Response<ICollection<CategoriesViewModel>>> GetAll();

    Task<Response<CategoriesViewModel>> Get(Guid uid);

    Task<Response<CategoriesResponse>> Create(CategoryCreateRequest request);

    Task<Response<CategoriesResponse>> Update(CategoryUpdateRequest request);

    Task<Response<string>> Delete(Guid uid);
}