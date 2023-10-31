using N66_HT1.Domain.Entities;
using System.Linq.Expressions;

namespace N66_HT1.Application.Common.DbManager.Services;

public interface IBookService
{
    IQueryable<Book> Get(Expression<Func<Book, bool>> predicate);

    ValueTask<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<Book> CreateAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Book> UpdateAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
    
    ValueTask DeleteAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default);
}
