using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineStore.DTO;

public class CategoryListingModel
{
    
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Please enter your name of the category")]
    [Display(Name = "Category name*")]
    [StringLength(20)]
    public string? Name { get; set; }

    [Display(Name = "Description")]
    public string? Description { get; set; }
}
