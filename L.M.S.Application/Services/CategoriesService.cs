using L.M.S.Application.Common.Dto;
using L.M.S.Application.Common.Factories;
using L.M.S.Application.Common.Responses;
using L.M.S.Application.Common.ViewModels;
using L.M.S.Application.Domain.Persistence;
using L.M.S.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace L.M.S.Application.Services;

public class CategoriesService : ICategoriesService
{
    private ICategoriesRepository categoriesRepository;
    public CategoriesService(ICategoriesRepository categoriesRepository)
    {
        this.categoriesRepository = categoriesRepository;
    }

    public async Task<Response<ICollection<CategoriesViewModel>>> GetAll()
    {
        var categories = await categoriesRepository
            .GetQueryable()
            .ToListAsync();

        var result = categories.Select(ViewModelFactory.Create).ToList();

        return Response<ICollection<CategoriesViewModel>>.Succeed(result);
    }

    public async Task<Response<CategoriesViewModel>> Get(Guid uid)
    {
        var category = await this.categoriesRepository
            .GetQueryable()
            .FirstOrDefaultAsync(b => b.Uid == uid);

        if (category is null)
        {
            return Response<CategoriesViewModel>.Fail("Category not found", HttpStatusCode.NotFound);
        }

        var vm = ViewModelFactory.Create(category);

        return Response<CategoriesViewModel>.Succeed(vm);
    }

    public async Task<Response<CategoriesResponse>> Create(CategoryCreateRequest request)
    {
        var existingCategory = await this.categoriesRepository
            .GetQueryable()
            .AnyAsync(c => c.Name == request.Name);

        if (existingCategory)
        {
            return Response<CategoriesResponse>.Fail("Category already exists", HttpStatusCode.BadRequest);
        }

        var category = EntityFactory.Create(request);
        await this.categoriesRepository.Add(category);

        return Response<CategoriesResponse>.Succeed(new CategoriesResponse { Uid = category.Uid }, "Category created successfully.");
    }

    public async Task<Response<CategoriesResponse>> Update(CategoryUpdateRequest request)
    {
        var category = await this.categoriesRepository
            .GetQueryable()
            .FirstOrDefaultAsync(c => c.Uid == request.Uid);

        if (category is null)
        {
            return Response<CategoriesResponse>.Fail("Category not found", HttpStatusCode.NotFound);
        }

        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            var duplicate = await categoriesRepository
                .GetQueryable()
                .AnyAsync(b => b.Name == request.Name && b.Uid != request.Uid);

            if (duplicate)
            {
                return Response<CategoriesResponse>.Fail("Another Category with the same name already exists.", HttpStatusCode.BadRequest);
            }

            category.Name = request.Name;
        }

        await this.categoriesRepository.Update(category);

        return Response<CategoriesResponse>.Succeed(new CategoriesResponse { Uid = category.Uid }, "Category updated successfully.");
    }

    public async Task<Response<string>> Delete(Guid uid)
    {
        var category = await this.categoriesRepository
            .GetQueryable()
            .FirstOrDefaultAsync(c => c.Uid == uid);

        if (category is null)
        {
            return Response<string>.Fail("Category not found", HttpStatusCode.NotFound);
        }

        await this.categoriesRepository.Delete(category);

        return Response<string>.Succeed("Category deleted successfully");
    }
}