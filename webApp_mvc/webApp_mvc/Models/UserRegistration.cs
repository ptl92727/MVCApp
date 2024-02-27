using FinalProject.EntityF;
using System.ComponentModel.DataAnnotations;

namespace webApp_mvc
{
  public class UserRegisterationModel
  {

    public string First_Name { get; set; }
    public string Last_Name { get; set; }

    public UserType Type { get; set; }


    [Required(ErrorMessage = "Email Is Required")]
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password Is Required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Compare(nameof(Password),ErrorMessage = "Password Isn't Correct")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set;}
  }
}
