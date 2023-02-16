using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Models;

namespace OnlineStore.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task DeleteBook(Book book)
        {
            Delete(book);
        }

        public async Task EditBook(Book book)
        {
            Update(book);
        }

        public IQueryable<Book> GetAll(bool trackChanges) =>
            FindAll(trackChanges);

        public async Task<Book> GetById(Guid id, bool trackChanges) =>
            (await FindByCondition(x => x.Id.Equals(id), trackChanges).SingleOrDefaultAsync())!;

        public IQueryable<Book> GetBooksByCategoryId(Guid categoryId, bool trackChanges)=>
             FindByCondition(x => x.CategoryId.Equals(categoryId), trackChanges);

        public async Task NewBook(Book book)
        {
            Create(book);
        }
    }
}
