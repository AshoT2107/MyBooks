using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.DTO;

public class CategoryIndexModel
{
    public IEnumerable<CategoryListingModel>? CategoryList { get; set; }
}