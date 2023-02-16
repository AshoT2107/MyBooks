using OnlineStore.Models;

namespace OnlineStore.Repository
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll(bool trackChanges);
        Task<Category> GetById(Guid id,bool trackChanges);
        Task NewCategory(Category category);
        Task EditCategory(Category category);
        Task DeleteCategory(Category category);
    }
}
