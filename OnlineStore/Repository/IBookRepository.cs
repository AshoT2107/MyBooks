using OnlineStore.Models;

namespace OnlineStore.Repository
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAll(bool trackChanges);
        IQueryable<Book> GetBooksByCategoryId(Guid categoryId,bool trackChanges);
        Task<Book> GetById(Guid id, bool trackChanges);
        Task NewBook(Book book);
        Task EditBook(Book book);
        Task DeleteBook(Book book);
    }
}
