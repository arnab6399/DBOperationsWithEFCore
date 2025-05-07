using Microsoft.EntityFrameworkCore;

namespace DBOperationsWithEFCore.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
    }
}
