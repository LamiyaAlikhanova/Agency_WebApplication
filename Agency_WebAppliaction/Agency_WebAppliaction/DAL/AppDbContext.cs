using Agency_WebAppliaction.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Agency_WebAppliaction.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

         public DbSet <Service> services { get; set; }
    }
}
