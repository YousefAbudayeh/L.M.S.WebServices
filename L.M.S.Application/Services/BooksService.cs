using L.M.S.Application.Common.Dto;
using L.M.S.Application.Common.Factories;
using L.M.S.Application.Common.Responses;
using L.M.S.Application.Common.ViewModels;
using L.M.S.Application.Domain.Entities;
using L.M.S.Application.Domain.Persistence;
using L.M.S.Application.Interfaces;
using L.M.S.Application.Persistence.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

namespace L.M.S.Application.Services;

public class BooksService : IBooksService
{
    private readonly IBooksRepository booksRepository;
    private readonly ICategoriesRepository categoriesRepository;
    private readonly BooksAdoRepository booksAdoRepository;
    public BooksService(IBooksRepository booksRepository,
        ICategoriesRepository categoriesRepository,
        BooksAdoRepository booksAdoRepository)
    {
        this.booksRepository = booksRepository;
        this.categoriesRepository = categoriesRepository;
        this.booksAdoRepository = booksAdoRepository;
    }

    public async Task<Response<ICollection<BooksViewModel>>> GetAll()
    {
        var books = await this.booksAdoRepository.GetAllWithCategoriesAsync();

        return Response<ICollection<BooksViewModel>>.Succeed(books);
    }

    public async Task<Response<BooksViewModel>> Get(Guid uid)
    {
        var book = await this.booksRepository
            .GetQueryable()
            .Include(b => b.BookCategories)
            .FirstOrDefaultAsync(b => b.Uid == uid);

        if (book is null)
        {
            return Response<BooksViewModel>.Fail("Book not found", HttpStatusCode.NotFound);
        }

        var categoryIds = book.BookCategories
            .Select(bc => bc.CategoryId)
            .ToList();

        var categories = await this.categoriesRepository
            .GetQueryable()
            .Where(c => categoryIds.Contains(c.Id))
            .Select(c => new CategoriesViewModel { Uid = c.Uid, Name =  c.Name })
            .ToListAsync();

        var vm = ViewModelFactory.CreateBookWithCategoryDetails(
            book.Uid,
            book.Title,
            book.Description,
            book.Author,
            categories.ToList()
        );

        return Response<BooksViewModel>.Succeed(vm);
    }

    public async Task<Response<BookResponse>> Create(BookCreateRequest request)
    {
        var existingBook = this.booksRepository
            .GetQueryable()
            .FirstOrDefault(b => b.Title == request.Title);

        if (existingBook is not null)
        {
            return Response<BookResponse>.Fail("A book with the same title already exists.", HttpStatusCode.BadRequest);
        }

        var categories = new List<Category>();

        if (request.CategoryUids.Any())
        {
            categories = this.categoriesRepository
                .GetQueryable()
                .Where(c => request.CategoryUids.Contains(c.Uid))
                .ToList();
        }

        var book = EntityFactory.Create(request, categories);

        await this.booksRepository.Add(book);

        return Response<BookResponse>.Succeed(new BookResponse { Uid = book.Uid }, "Book created successfully.");
    }

    public async Task<Response<BookResponse>> Update(BookUpdateRequest request)
    {
        var book = this.booksRepository
            .GetQueryable()
            .Include(b => b.BookCategories)
            .FirstOrDefault(b => b.Uid == request.Uid);

        if (book is null)
        {
            return Response<BookResponse>.Fail("Book not found.", HttpStatusCode.NotFound);
        }

        if (!string.IsNullOrWhiteSpace(request.Title))
        {
            var duplicate = await booksRepository
                .GetQueryable()
                .AnyAsync(b => b.Title == request.Title && b.Uid != request.Uid);

            if (duplicate)
            {
                return Response<BookResponse>.Fail("Another book with the same title already exists.", HttpStatusCode.BadRequest);
            }

            book.Title = request.Title;
        }

        if (!string.IsNullOrWhiteSpace(request.Description))
        {
            book.Description = request.Description;
        }

        if (!string.IsNullOrWhiteSpace(request.Author))
        {
            book.Author = request.Author;
        }

        if (request.CategoryUids is not null && request.CategoryUids.Any())
        {
            var categories = categoriesRepository
                .GetQueryable()
                .Where(c => request.CategoryUids.Contains(c.Uid))
                .ToList();

            book.BookCategories.Clear();

            foreach (var category in categories)
            {
                book.BookCategories.Add(new BookCategory
                {
                    BookId = book.Id,
                    CategoryId = category.Id
                });
            }
        }

        await this.booksRepository.Update(book);

        return Response<BookResponse>.Succeed(new BookResponse { Uid = book.Uid }, "Book updated successfully.");
    }

    public async Task<Response<string>> Delete(Guid uid)
    {
        var book = await booksRepository
            .GetQueryable()
            .FirstOrDefaultAsync(b => b.Uid == uid);

        if (book == null)
        {
            return Response<string>.Fail("Book not found", HttpStatusCode.NotFound);
        }

        await booksRepository.Delete(book);

        return Response<string>.Succeed("Book deleted successfully.");
    }
}