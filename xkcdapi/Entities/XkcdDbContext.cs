using Microsoft.EntityFrameworkCore;

namespace xkcdapi.Entities
{
    public class XkcdDbContext : DbContext
    {
        public XkcdDbContext(DbContextOptions<XkcdDbContext> options) : base(options)
        {
            
        }

        public DbSet<Comic> Comics { get; set; }

    }
}
