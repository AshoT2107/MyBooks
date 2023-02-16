using OnlineStore.Data;

namespace OnlineStore.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _dbContext;
        private ICategoryRepository _category;
        private IBookRepository _book;
        public RepositoryManager(AppDbContext dbContext) => _dbContext = dbContext;
        public ICategoryRepository Category
        {
            get
            {
                _category ??= new CategoryRepository(_dbContext);
                return _category;
            }
        }

        public IBookRepository Book
        {
            get
            {
                _book ??= new BookRepository(_dbContext);
                return _book;
            }
        }

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    }
}
