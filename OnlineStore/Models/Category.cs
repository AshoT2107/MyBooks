using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models;

public class Category
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<Book>? Books { get; set; }
}