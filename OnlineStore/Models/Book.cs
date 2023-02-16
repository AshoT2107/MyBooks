using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models;

public class Book
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ShortDescription { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public Guid UserAccountId { get; set; }
    public virtual UserAccount? UserAccount { get; set; }
}
