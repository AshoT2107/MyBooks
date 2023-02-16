namespace OnlineStore.Repository;

public interface IRepositoryManager
{
    ICategoryRepository Category { get; }
    IBookRepository Book { get; }
    Task SaveChangesAsync();
}
