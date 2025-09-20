using L.M.S.Application.Common.Dto;
using L.M.S.Application.Common.Responses;
using L.M.S.Application.Common.ViewModels;
using L.M.S.Application.Interfaces;
using L.M.S.Application.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace L.M.S.Application.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesService categoriesService;
    public CategoriesController(ICategoriesService categoriesService)
    {
        this.categoriesService = categoriesService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Response<CategoriesViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var results = await this.categoriesService.GetAll();

        return this.HttpContext.ToJsonResult(results);
    }

    [HttpGet("{uid}")]
    [ProducesResponseType(typeof(Response<CategoriesViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid uid)
    {
        var results = await this.categoriesService.Get(uid);

        return this.HttpContext.ToJsonResult(results);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Response<CategoriesResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CategoryCreateRequest request)
    {
        var results = await this.categoriesService.Create(request);

        return this.HttpContext.ToJsonResult(results);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Response<CategoriesResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(CategoryUpdateRequest request)
    {
        var results = await this.categoriesService.Update(request);

        return this.HttpContext.ToJsonResult(results);
    }

    [HttpDelete("{uid}")] 
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid uid)
    {
        var results = await this.categoriesService.Delete(uid);

        return this.HttpContext.ToJsonResult(results);
    }
}