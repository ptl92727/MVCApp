using Microsoft.EntityFrameworkCore;
using webApp_mvc.Models;

namespace webApp_mvc.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options): base (options)
        {
            
        }
        public DbSet <User>

    }
}
