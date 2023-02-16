using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Models;

public class UserAccount : IdentityUser<Guid> 
{
    [Display(Name = "First Name")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required")]
    public string? LastName { get; set; }
    public IEnumerable<Book>? Books { get; set; }
}
