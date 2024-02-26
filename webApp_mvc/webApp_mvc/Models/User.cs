using System.ComponentModel.DataAnnotations; //data annotation related to data

namespace webApp_mvc.Models
{
    public class UserLoginModel
    {


        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress]
        public string Email { get; set; }



        [Required(ErrorMessage = "Password Is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
