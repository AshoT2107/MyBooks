using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DTO;

public class EditUserAccount
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required")]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

/*    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
    [Display(Name = "Password")]
    public string? Password { get; set; }

    [NotMapped]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
    public string? ConfirmPassword { get; set; }*/
}
