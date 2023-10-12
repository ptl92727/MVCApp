using System.ComponentModel.DataAnnotations; //data annotation related to data

namespace webApp_mvc.Models
{
    public class User
    {

        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime DOB { get; set; }
        public bool IsActive { get; set; }
    }
}
