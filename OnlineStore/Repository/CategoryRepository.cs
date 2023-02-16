using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Models;

namespace OnlineStore.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task DeleteCategory(Category category)
        {
            Delete(category);
        }

        public async Task EditCategory(Category category)
        {
            Update(category);
        }

        public IQueryable<Category> GetAll(bool trackChanges) =>
            FindAll(trackChanges);

        public async Task<Category> GetById(Guid id, bool trackChanges) =>
            (await FindByCondition(x => x.Id.Equals(id), trackChanges).Include(x => x.Books).SingleOrDefaultAsync())!;

        public async Task NewCategory(Category category)
        {
            Create(category);
        }
    }
}
