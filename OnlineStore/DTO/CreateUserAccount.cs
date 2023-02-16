using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineStore.DTO;

public class CreateUserAccount
{
    [Display(Name = "First Name")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required")]
    public string? LastName { get; set; }

    [Display(Name = "User Name")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "User name is required")]
    public string? UserName { get; set; }

    [Display(Name = "Phone number")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number is required")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Email")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
    public string? Password { get; set; }

    [NotMapped]
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
    public string? ConfirmPassword { get; set; }
}
