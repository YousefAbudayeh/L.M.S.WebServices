using L.M.S.Application.Common.Constants;
using L.M.S.Application.Common.Factories;
using L.M.S.Application.Common.Settings;
using L.M.S.Application.Common.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace L.M.S.Application.Persistence.Sql;

public class BooksAdoRepository
{
    private readonly PersistenceSettings settings;

    public BooksAdoRepository(PersistenceSettings settings)
    {
        this.settings = settings;
    }

    public async Task<ICollection<BooksViewModel>> GetAllWithCategoriesAsync()
    {
        var books = new List<BooksViewModel>();

        using (var connection = new SqlConnection(settings.DefaultConnection))
        using (var command = new SqlCommand(ProcedureConstants.GetAllBooksWithCategories, connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            await connection.OpenAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var bookUid = reader.GetGuid(reader.GetOrdinal("BookUid"));
                    var title = reader.GetString(reader.GetOrdinal("Title"));
                    var description = reader.GetString(reader.GetOrdinal("Description"));
                    var author = reader.GetString(reader.GetOrdinal("Author"));
                    var categoryName = reader.IsDBNull(reader.GetOrdinal("CategoryName")) 
                        ? null 
                        : reader.GetString(reader.GetOrdinal("CategoryName"));

                    var book = books.FirstOrDefault(b => b.Uid == bookUid);

                    if (book is null)
                    {
                        book = ViewModelFactory.CreateBook(bookUid, title, description, author);
                        books.Add(book);
                    }

                    if (!string.IsNullOrEmpty(categoryName))
                    {
                        book.Categories.Add(categoryName);
                    }
                }

                return books;
            }
        }

    }

}