using N66_HT1.Application.Common.DbManager.Services;
using N66_HT1.Domain.Entities;
using N66_HT1.Persistence.DataAccess;
using System.Linq.Expressions;

namespace N66_HT1.Infrastructure.Common.DbManager.Services;

public class BookService : IBookService
{
    private readonly AppDbContext _dbContext;

    public BookService(AppDbContext appDbContext)
    {
        _dbContext = appDbContext;
    }

    public async ValueTask<Book> CreateAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(book);

        await _dbContext.Books.AddAsync(book, cancellationToken);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return book;
    }

    public async ValueTask DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var found = await GetByIdAsync(id);

        _dbContext.Books.Remove(found);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public ValueTask DeleteAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default)
        => DeleteAsync(book.Id, saveChanges, cancellationToken);

    public IQueryable<Book> Get(Expression<Func<Book, bool>> predicate)
        => _dbContext.Books.Where(predicate.Compile()).AsQueryable();

    public ValueTask<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => new(_dbContext.Books.FirstOrDefault(book => book.Id == id)
        ?? throw new InvalidOperationException("Book not found!"));

    public async ValueTask<Book> UpdateAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(book);

        var found = await GetByIdAsync(book.Id, cancellationToken);
        found.Title = book.Title;
        found.Description = book.Description;

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return found;
    }

    private void Validate(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("Invalid title!");

        if (string.IsNullOrWhiteSpace(book.Description))
            throw new ArgumentException("Invalid description!");
    }
}
