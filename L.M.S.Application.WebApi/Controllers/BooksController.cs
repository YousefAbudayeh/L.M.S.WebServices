using L.M.S.Application.Common.Dto;
using L.M.S.Application.Common.Responses;
using L.M.S.Application.Common.ViewModels;
using L.M.S.Application.Interfaces;
using L.M.S.Application.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace L.M.S.Application.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBooksService booksService;
    public BooksController(IBooksService booksService)
    {
        this.booksService = booksService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Response<BooksViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var results = await this.booksService.GetAll();

        return this.HttpContext.ToJsonResult(results);
    }

    [HttpGet("{uid}")]
    [ProducesResponseType(typeof(Response<BooksViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid uid)
    {
        var results = await this.booksService.Get(uid);

        return this.HttpContext.ToJsonResult(results);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Response<BookResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(BookCreateRequest request)
    {
        var results = await this.booksService.Create(request);

        return this.HttpContext.ToJsonResult(results);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Response<BookResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(BookUpdateRequest request)
    {
        var results = await this.booksService.Update(request);

        return this.HttpContext.ToJsonResult(results);
    }

    [HttpDelete("{uid}")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid uid)
    {
        var results = await this.booksService.Delete(uid);

        return this.HttpContext.ToJsonResult(results);
    }
}