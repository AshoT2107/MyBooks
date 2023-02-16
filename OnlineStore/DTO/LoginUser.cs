using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineStore.DTO;

public class LoginUser
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "UserName is required")]
    [DataType(DataType.Text)]
    [Display(Name = "UserName")]
    public string? UserName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string? Password { get; set; }
    public bool RememberMe { get; set; }
}
