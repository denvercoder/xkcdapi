using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
