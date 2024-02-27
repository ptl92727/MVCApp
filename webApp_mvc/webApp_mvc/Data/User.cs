using Microsoft.AspNetCore.Identity
namespace webApp_mvc.Data
{
  public class User:IdentityUser<int>
  {
    // public int User_ID { get; set; }
    public string User_Name { get; set; }

    public UserType Type { get; set; }
    public int User_ID { get; set; }
  }
  public enum UserType
  {
    Staff,
    manager
    
  }
}
